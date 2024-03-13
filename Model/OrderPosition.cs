using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderPosition
    {
        public OrderPosition() { }

        public OrderPosition(BasketPosition basketPosition) { 
            this.Amount = basketPosition.Amount;
            this.Product = basketPosition.Product;
            this.ProductId = basketPosition.ProductId;
            this.Price = basketPosition.Product.Price * this.Amount;
        }


        [Key]
        public int Id { get; set; }

        public int Amount { get; set; } 
        public double Price { get; set; }

        public int? OrderId { get; set; }

        public Order? Order { get; set; }

        public int? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
