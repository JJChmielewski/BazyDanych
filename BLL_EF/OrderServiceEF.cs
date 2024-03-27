using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderServiceEF : OrderService
    {

        private WebShopContext context= new WebShopContext();

        public void addProductToBasket(int productId, int userId)
        {
            User? user = context.Users.Where(u => u.Id == userId).FirstOrDefault();
            Product? product = context.Products.Where(p => p.Id == productId).FirstOrDefault();

            if (user != null && product != null && product.IsActive)
            {
                BasketPosition basketPosition = new BasketPosition();
                basketPosition.ProductId = productId;
                basketPosition.Product = product;
                basketPosition.UserId = userId;        
                basketPosition.User = user;

                if (user.BasketPosition == null) { 
                    user.BasketPosition = new List<BasketPosition>();
                }

                user.BasketPosition.Add(basketPosition);
                context.SaveChanges();
            }
            
        }

        public void removeProductFromBasket(int productId, int userId)
        {
            BasketPosition? basketPosition = context.BasketPositions.Where(b => b.ProductId == productId && b.UserId == userId).FirstOrDefault();

            if (basketPosition != null)
            {
                context.BasketPositions.Remove(basketPosition);
                context.SaveChanges();
            }

        }

        public void updateProductQuantityInBasket(int productId, int userId, int quantity)
        {
            if (quantity <= 0)
            {
                return;
            }

            BasketPosition? basketPosition = context.BasketPositions.Where(b => b.ProductId == productId && b.UserId == userId).FirstOrDefault();

            if (basketPosition != null)
            {
                basketPosition.Amount = quantity;
                context.SaveChanges();
            }
        }

        public OrderResponseDTO generateOrder(int userId)
        {
            User? user = context.Users.Where(u => u.Id == userId).FirstOrDefault();
            context.Entry(user).Collection(u => u.BasketPosition).Load();


            if (user != null)
            {
                Order order = new Order();
                OrderResponseDTO orderResponseDTO = new OrderResponseDTO();

                foreach(BasketPosition basketPosition in user.BasketPosition) {
                    context.Entry(basketPosition).Reference(b => b.Product).Load();
                    context.Entry(basketPosition.Product).Reference(p => p.ProductGroup).Load();


                    ProductResponseDTO prod = new ProductResponseDTO(
                        basketPosition.Product.Id, basketPosition.Product.Name, basketPosition.Product.Price,
                        basketPosition.Product.ProductGroup.Name);

                    OrderItemDTO orderItemDTO = new OrderItemDTO(prod, basketPosition.Amount);
                    orderResponseDTO.ItemDTOs.Add(orderItemDTO);


                    OrderPosition orderPosition = new OrderPosition(basketPosition);
                    orderPosition.Order = order;
                    orderPosition.OrderId = order.Id;
                    order.OrderPositions.Add(orderPosition);
                }

                context.Orders.Add(order);
                context.SaveChanges();
                orderResponseDTO.Total = order.getRequiredPayment();

                return orderResponseDTO;
            }


            return null;
        }

        public void payForOrder(int orderId, double payment)
        {
            Order? order = context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            context.Entry(order).Collection(o => o.OrderPositions).Load();

            foreach (OrderPosition position in order.OrderPositions)
            {
                context.Entry(position).Reference(o => o.Product).Load();
            }

            if (order != null && payment == order.getRequiredPayment())
            {
                order.isPayed = true;
                context.SaveChanges();
            }
        }

    }
}
