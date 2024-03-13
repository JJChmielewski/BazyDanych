using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface OrderService
    {

        public void addProductToBasket(ProductRequestDTO product, int orderId);

        public void updateProductQuantityInBasket(ProductRequestDTO product, int orderId, int quantity);

        public void removeProductFromBasket(ProductRequestDTO product, int orderId);

        public OrderResponseDTO getOrder(int orderId);

        public void payForOrder(int orderId);

    }
}
