using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Business
{
    public record Pallete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public bool? IsDefective { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public DateTime? DateArrived { get; set; }

        [Required]
        public DateTime? DateExported { get; set; }

        // Foreign key
        public virtual int? ClientId { get; set; }
        public virtual int? OrderId { get; set; }

        // Has
        public virtual ICollection<Product>? Products { get; set; }

        // Belongs To
        public virtual Client? Client { get; set; }
        public virtual Order? Order { get; set; }
    }
}
