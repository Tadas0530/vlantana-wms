using vlantana_wms_backend.Models.Auth;

namespace vlantana_wms_backend.Models.Business
{
    public class Client
    {
        public int Id { get; set; }
        public string? OrganizationName { get; set; }
        public virtual ICollection<Product>? Products { get; set; } // Has a lot of products
        public virtual ICollection<Pallete>? Palletes { get; set; } // Has a lot of pallets that have the products
        public virtual ICollection<Order>? Orders { get; set; } // Has a lot of orders
        public virtual ICollection<UserModel>? Users { get; set; } // Has a lot of employees/users
    }
}
