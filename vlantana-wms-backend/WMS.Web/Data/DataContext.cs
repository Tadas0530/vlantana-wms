using Microsoft.EntityFrameworkCore;
using vlantana_wms_backend.Models.Auth;
using vlantana_wms_backend.Models.Business;

namespace vlantana_wms_backend.Data
{
    public class DataContext : DbContext
	{
        public DbSet<UserCredentials> Credentials { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Company> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Pallete> Pallete { get; set; }
        public DbSet<Product> Product { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=vlantana_wms;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-one relationship between User and UserCredentials
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserCredentials) // User has one UserCredentials
                .WithOne(uc => uc.User)        // UserCredentials has one User
                .HasForeignKey<UserCredentials>(uc => uc.UserId); // The foreign key is UserId in UserCredentials
        }
    }
}
