using Microsoft.EntityFrameworkCore;
using vlantana_wms_backend.Models.Auth;
using vlantana_wms_backend.Models.Business;

namespace vlantana_wms_backend.Data
{
    public class DataContext : DbContext
	{
        public DbSet<UserCredentials> Credentials { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<Client> ClientModels { get; set; }
        public DbSet<Order> OrderModels { get; set; }
        public DbSet<Pallete> PalleteModels { get; set; }
        public DbSet<Product> ProductModels { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
