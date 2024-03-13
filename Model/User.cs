using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public bool isActive { get; set; }

        [ForeignKey(nameof(UserGroupId))]
        public UserGroup? UserGroup { get; set; }

        public int? UserGroupId { get; set; }

        public ICollection<BasketPosition>? BasketPosition { get; set; }

        public ICollection<Order>? Orders { get; set; } = new List<Order>();
        
    }

    public enum UserType
    {
        Admin, Casual
    }
}
