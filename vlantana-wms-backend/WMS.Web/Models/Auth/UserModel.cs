using vlantana_wms_backend.Models.Business;

namespace vlantana_wms_backend.Models.Auth
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        // Foreign key
        public string? ClientId {  get; set; }

        // Belongs to
        public virtual Client? Client { get; set; }
    }
}
