using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderItemDTO
    {
        public OrderItemDTO(ProductResponseDTO product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public ProductResponseDTO Product { get; }
        public int Quantity { get; }

    }
}
