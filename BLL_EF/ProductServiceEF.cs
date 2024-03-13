using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;

namespace BLL_EF
{
    public class ProductServiceEF : ProductService
    {

        private WebShopContext context;

        public void deleteProduct(int productId, bool deletePermanently)
        {
            Product prod = context.Products.Where(p => p.Id == productId).First();

            if (prod == null)
            {
                return;
            }

            prod.IsActive = false;

            if (deletePermanently)
            {
                context.Products.Remove(prod);
            }
            context.SaveChanges();
        }

        public void reactivateProduct(int productId)
        {
            Product prod = context.Products.Where(p => p.Id == productId).First();

            if (prod != null)
            {
                prod.IsActive = true;
            }
            context.SaveChanges();
        }

        public List<ProductResponseDTO> getProducts()
        {
            return getProducts(false);
        }

        public List<ProductResponseDTO> getProducts(bool includeInactive)
        {
            List<Product> products;

            if (includeInactive)
            {
               products = context.Products.ToList();
            } else
            {
                products = context.Products.Where(p => p.IsActive).ToList();
            }

            List<ProductResponseDTO> responseProducts = new List<ProductResponseDTO>();

            foreach (Product prod in products)
            {
                ProductResponseDTO responseProductDTO = new ProductResponseDTO(
                    prod.Id, prod.Name, prod.Price, prod.ProductGroup == null ? "" : prod.ProductGroup.Name);

                responseProducts.Add(responseProductDTO);
            }

            return responseProducts;
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
    }
}
