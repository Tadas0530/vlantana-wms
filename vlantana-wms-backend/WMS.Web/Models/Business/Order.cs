using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Business
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        // Foreign key
        public int? CompanyId { get; set; }

        // Belongs to client
        public virtual Company? Company { get; set; }

        // Has products
        public virtual ICollection<Product>? Products { get; set; }

        // Has Pallets full of products
        public virtual ICollection<Pallete>? Palletes { get; set; }
    }
}
