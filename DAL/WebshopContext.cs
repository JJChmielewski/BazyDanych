using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class WebshopContext : DbContext
    {
        public DbSet<BasketPosition> BasketPositions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketPosition>()
                .HasOne(bp => bp.Product)
                .WithMany()
                .HasForeignKey(bp => bp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BasketPosition>()
                .HasOne(bp => bp.User)
                .WithMany()
                .HasForeignKey(bp => bp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProductGroup>()
                .HasMany(pg => pg.Products)
                .WithOne(p => p.ProductGroup)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserGroup>()
                .HasMany(ug => ug.Users)
                .WithOne(u => u.UserGroup)
                .HasForeignKey(u => u.UserGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderPosition>()
                .HasOne(op => op.Order)
                .WithOne(o => o.OrderPosition)
                .HasForeignKey<OrderPosition>(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
