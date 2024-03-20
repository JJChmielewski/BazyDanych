using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<OrderPosition>? OrderPositions { get; set; }
        public bool isPayed { get; set; }

        public double getRequiredPayment()
        {
            double payment = 0;
            foreach (OrderPosition orderPosition in OrderPositions)
            {
                payment += orderPosition.Price;
            }
            return payment;
        }
    }
}
