using System.ComponentModel.DataAnnotations;

namespace vlantana_wms_backend.Models.Auth
{
    public class UserCredentials
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string? UserName { get; set;}
        [Required]
        [StringLength(20)]
        public string? Email { get; set;}
        [Required]
        [StringLength(20)]
        public string? Password { get; set;}
    }
}
