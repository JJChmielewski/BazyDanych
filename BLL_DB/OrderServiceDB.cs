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
    public class OrderServiceDB : OrderService
    {

        public void addProductToBasket(int productId, int userId)
        {
            executeSql(String.Format("exec dbo.AddProductToBasket {0}, {1}", productId, userId));
        }

        public void removeProductFromBasket(int productId, int userId)
        {
            executeSql(String.Format("exec dbo.RemoveProductFromBasket {0}, {1}", userId, productId));
        }

        public void updateProductQuantityInBasket(int productId, int userId, int quantity)
        {
            executeSql(String.Format("exec dbo.ChangeBasketPositionQuantity {0}, {1}, {2}", productId, userId, quantity));
        }

        public OrderResponseDTO generateOrder(int userId)
        {
            string[] orderRawSplit = executeSql(String.Format("exec dbo.GenerateOrderFromBasket {0}", userId)).Split('\n');
            List<OrderItemDTO> items = new List<OrderItemDTO>();
            ProductServiceDB productService = new ProductServiceDB();
            List<ProductResponseDTO> prods = productService.getProducts();
            double total = 0;
            int orderId = 0;
            foreach (string orderPositionDataRaw in orderRawSplit)
            {
                if (orderPositionDataRaw.Equals("")) {
                    break;
                }
                
                string[] orderPositionData = orderPositionDataRaw.Split(';');
                if (orderId == 0)
                {
                    orderId = int.Parse(orderPositionData[3]);
                }


                OrderItemDTO orderItem = new OrderItemDTO(prods.Where(p => p.Id == int.Parse(orderPositionData[4])).FirstOrDefault(), int.Parse(orderPositionData[1]));
                total = orderItem.Product.Price * orderItem.Quantity;
                items.Add(orderItem);
            }
            return new OrderResponseDTO(orderId, items, total);
        }

        public void payForOrder(int orderId, double payment)
        {
            executeSql(String.Format("exec dbo.PayOrder {0}, {1}", orderId, payment));
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
                        for (int i = 0; i < reader.FieldCount; i++)
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
