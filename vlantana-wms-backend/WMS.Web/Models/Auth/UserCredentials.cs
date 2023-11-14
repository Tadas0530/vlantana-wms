using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Auth
{
    public class UserCredentials
    {
        [Key]
        public int UserCredentialsId { get; set; }
        [Required]
        [StringLength(50)]
        public string? UserName { get; set;}
        [Required]
        [StringLength(50)]
        public string? Email { get; set;}
        [Required]
        [StringLength(50)]
        public string? Password { get; set;}

        // foreign key
        public int? UserId { get; set; }

        // belongs to
        public virtual User? User { get; set; }
    }
}
