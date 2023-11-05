using System;
using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Business
{
    public record class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        // Foreign key
        public int? PalleteId { get; set; }
        public int? OrderId { get; set; }
        public int? ClientId {  get; set; }

        // Belongs to
        public virtual Pallete? Pallete { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Client? Client { get; set; }

    }
}
