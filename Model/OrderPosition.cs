﻿using System;
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
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; } 
        public double Price { get; set; }

        public int? OrderId { get; set; }

        public Order? Order { get; set; }
    }
}
