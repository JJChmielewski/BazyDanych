using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface ProductService
    {

        public List<ProductResponseDTO> getProducts();

        public List<ProductResponseDTO> getProducts(bool includeInactive);

        public List<ProductResponseDTO> filterProducts(List<ProductResponseDTO> products, string criteria, string value);

        public List<ProductResponseDTO> sortProducts(List<ProductResponseDTO> products, string criteria);

        public void deleteProduct(int productId, bool deletePermanently);

        public void reactivateProduct(int productId);

    }
}
