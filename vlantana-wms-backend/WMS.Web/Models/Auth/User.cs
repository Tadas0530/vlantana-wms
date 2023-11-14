using System.ComponentModel.DataAnnotations;
using vlantana_wms_backend.Models.Business;

namespace vlantana_wms_backend.Models.Auth
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? Role { get; set; }

        [Required]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string? PhotoPath { get; set; }

        [Required]
        // Foreign key
        public int? CompanyId {  get; set; }
        public int? UserCredentialsId { get; set; }

        // Belongs to
        public virtual UserCredentials? UserCredentials { get; set; }
        public virtual Company? Company { get; set; }

    }
}
