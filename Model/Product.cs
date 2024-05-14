using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Image {  get; set; }
        public bool IsActive { get; set; }

        public int? GroupId { get; set; }
        public ProductGroup? ProductGroup { get; set; }

        public BasketPosition? BasketPosition { get; set; }

        public OrderPosition? OrderPosition { get; set; }

    }
}
