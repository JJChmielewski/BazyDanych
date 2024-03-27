using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class ProductServiceDB : ProductService
    {

        public void deleteProduct(int productId, bool deletePermanently)
        {
            if (deletePermanently)
            {
                executeSql(String.Format("delete from dbo.Products where Id = {0}", productId));
            }

            executeSql(String.Format("exec dbo.DeactivateProduct {0}", productId));
        }

        public void reactivateProduct(int productId)
        {
            executeSql(String.Format("exec dbo.ActivateProduct {0}", productId));
        }

        public List<ProductResponseDTO> getProducts()
        {
            return getProducts(false);
        }

        public List<ProductResponseDTO> getProducts(bool includeInactive)
        {
            string[] productsDataRaw = executeSql(String.Format("exec dbo.GetProducts {0}", includeInactive)).Split('\n');

            List<ProductResponseDTO> products = new List<ProductResponseDTO>();

            foreach(string productRaw in productsDataRaw)
            {
                string[] productData = productRaw.Split(';');

                if (productData.Length < 4 )
                {
                    return products;
                }

                products.Add(new ProductResponseDTO(int.Parse(productData[0]), productData[1], Double.Parse(productData[2]), productData[3]));
            }
            return products;
        }

        public List<ProductResponseDTO> filterProducts(List<ProductResponseDTO> products, string criteria, string value)
        {
            switch (criteria)
            {
                case "Name":
                    products = products.Where(p => p.Name.Equals(value)).ToList();
                    break;
                case "Price":
                    products = products.Where(p => p.Price.ToString().Equals(value)).ToList();
                    break;
                case "GroupName":
                    products = products.Where(p => p.GroupName.Equals(value)).ToList();
                    break;
                default:
                    throw new Exception("Unknown criteria");
            }

            return products;
        }

        public List<ProductResponseDTO> sortProducts(List<ProductResponseDTO> products, string criteria)
        {
            switch (criteria)
            {
                case "Name":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "GroupName":
                    products = products.OrderBy(p => p.GroupName).ToList();
                    break;
                default:
                    throw new Exception("Unknown criteria");
            }



            return products;
        }

        public String getGroupName(ProductGroup productGroup)
        {
            string groupName = "";

            if (productGroup.Parent != null)
            {
                groupName += getGroupName(productGroup.Parent) + " / " + productGroup.Name;
            }

            return groupName;
        }

        public void addProduct(string name, double price, int groupId)
        {
            executeSql(String.Format("exec dbo.AddProduct {0}, {1}, {2}", name, price, groupId));
        }

        private string executeSql(string sql)
        {
            string output = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i=0; i < reader.FieldCount; i++)
                        {
                            output += reader[i] + ";";
                        }
                        output += '\n';
                    }
                }
            }
            return output;
        }
    }
}
