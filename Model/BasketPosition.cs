﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BasketPosition
    {
        [Key]
        public int Id { get; set; }

        public Product? Product { get; set; }
        public int? ProductId { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }

        public int Amount { get; set; }
    }
}
