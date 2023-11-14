using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Business
{
    public record Pallete
    {
        [Key]
        public int PalleteId { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public bool? IsDefective { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        public DateTime? DateArrived { get; set; }

        [Required]
        public DateTime? DateExported { get; set; }

        // Foreign key
        public virtual int? CompanyId { get; set; }
        public virtual int? OrderId { get; set; }

        // Has
        public virtual ICollection<Product>? Products { get; set; }

        // Belongs To
        public virtual Company? Company { get; set; }
        public virtual Order? Order { get; set; }
    }
}
