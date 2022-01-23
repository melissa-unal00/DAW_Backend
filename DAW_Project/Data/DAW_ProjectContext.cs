using DAW_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Data
{
    public class DAW_ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        public DbSet<OrderProductRelation> OrderProductRelations { get; set; }

        public DAW_ProjectContext(DbContextOptions<DAW_ProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

            builder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithOne(d => d.Order)
                .HasForeignKey<DeliveryAddress>(d => d.OrderId);

            builder.Entity<OrderProductRelation>()
                .HasKey(op => new
                {
                    op.OrderId,
                    op.ProductId
                });


            builder.Entity<OrderProductRelation>()
                .HasOne<Order>(op => op.Order)
                .WithMany(o => o.OrderProductRelations)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProductRelation>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderProductRelations)
                .HasForeignKey(op => op.ProductId);


            base.OnModelCreating(builder);
        }
    }
}
