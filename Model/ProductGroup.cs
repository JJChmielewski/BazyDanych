using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductGroup
    {
        [Key]
        public int ProductGroupId { get; set; }

        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }

        public int? ParentId { get; set; }

        public ProductGroup? Parent { get; set; }
    }
}
