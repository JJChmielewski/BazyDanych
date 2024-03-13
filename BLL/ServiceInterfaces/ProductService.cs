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

        public ICollection<ProductResponseDTO> getProducts();

        public ICollection<ProductResponseDTO> getProducts(bool includeInactive);

        public ICollection<ProductResponseDTO> getProducts(ICollection<ProductResponseDTO> products, string criteria, string value);

        public ICollection<ProductResponseDTO> sortProducts(ICollection<ProductResponseDTO> products, string criteria, string value);

        public void deleteProduct(ProductRequestDTO product, bool deletePermanently);

        public void reactivateProduct(ProductRequestDTO product);

    }
}
