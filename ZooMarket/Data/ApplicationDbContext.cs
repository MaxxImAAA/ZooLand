using Microsoft.EntityFrameworkCore;
using ZooMarket.Models;

namespace ZooMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PetOrder> PetOrders { get;set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(x => x.Order).WithOne(x => x.User).HasForeignKey<Order>(x => x.UserId);

            modelBuilder.Entity<PetOrder>()
                .HasOne(x => x.Pet).WithMany(x => x.PetOrders).HasForeignKey(x => x.PetId);

            modelBuilder.Entity<PetOrder>()
                .HasOne(x => x.Order).WithMany(x => x.PetOrders).HasForeignKey(x => x.OrderId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
