using System.ComponentModel.DataAnnotations;
using vlantana_wms_backend.Models.Auth;

namespace vlantana_wms_backend.Models.Business
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CompanyName { get; set; }
        public virtual ICollection<Product>? Products { get; set; } // Has a lot of products
        public virtual ICollection<Pallete>? Palletes { get; set; } // Has a lot of pallets that have the products
        public virtual ICollection<Order>? Orders { get; set; } // Has a lot of orders
        public virtual ICollection<User>? Users { get; set; } // Has a lot of employees/users
    }
}
