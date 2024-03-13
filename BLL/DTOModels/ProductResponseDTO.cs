using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductResponseDTO
    {
        public ProductResponseDTO(int id, string name, double price, string groupName)
        {
            Id = id;
            Name = name;
            Price = price;
            GroupName = groupName;
        }

        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        public string GroupName { get; }
    }
}
