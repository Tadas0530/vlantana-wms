using vlantana_wms_backend.Contracts.Web;

namespace vlantana_wms_backend.Contracts.Web.UserCredentials
{
    public class UserCredentialsResponse : Response
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
