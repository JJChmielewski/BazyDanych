using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductRequestDTO
    {
        public string Name { get; }
        public double Price { get; }
        public int GroupId { get; }
    }
}
