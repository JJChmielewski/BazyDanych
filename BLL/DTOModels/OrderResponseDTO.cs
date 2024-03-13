using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public ICollection<OrderItemDTO> ItemDTOs { get; }
        public double Total { get; }
    }
}
