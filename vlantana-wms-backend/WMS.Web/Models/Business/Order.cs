using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Business
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        // Foreign key
        public int? ClientId { get; set; }

        // Belongs to client
        public virtual Client? Client { get; set; }

        // Has products
        public virtual ICollection<Product>? Products { get; set; }

        // Has Pallets full of products
        public virtual ICollection<Pallete>? Palletes { get; set; }
    }
}
