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

        public void addProductToBasket(int productId, int userId);

        public void updateProductQuantityInBasket(int productId, int basketId, int quantity);

        public void removeProductFromBasket(int productId, int basketId);

        public OrderResponseDTO generateOrder(int userId);

        public void payForOrder(int orderId, double payment);

    }
}
