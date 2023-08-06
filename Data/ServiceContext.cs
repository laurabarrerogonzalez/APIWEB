using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Reflection.Emit;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<OrderItem> Orders { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<CustomerItem> Customers { get; set; }
        public DbSet<RolItem> RolItem { get; set; }
        public DbSet<DetallePedidoItem> DetallesPedido { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("Products");
            });

            builder.Entity<UserItem>(entity =>
            {
                entity.ToTable("Users");
            });

            builder.Entity<CustomerItem>(entity =>
            {
                entity.ToTable("Customers");
            });

            builder.Entity<RolItem>(entity =>
            {
                entity.ToTable("Roltype");
                entity.HasKey(r => r.IdRol);
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasOne<CustomerItem>().WithMany().HasForeignKey(o => o.IdCustomer);
                entity.HasKey(o => o.IdOrder);


            });

            builder.Entity<DetallePedidoItem>(entity =>
            {
                entity.ToTable("Detalle");
                builder.Entity<DetallePedidoItem>()
            .HasKey(dp => dp.IdDetalle);

                builder.Entity<DetallePedidoItem>()
                    .HasOne<OrderItem>()
                    .WithMany()
                    .HasForeignKey(dp => dp.IdOrder);

                builder.Entity<DetallePedidoItem>()
                     .HasOne<ProductItem>() 
                     .WithMany()
                     .HasForeignKey(dp => dp.IdProduct);
            });




        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));
            return new ServiceContext(optionsBuilder.Options);
        }
    }

}

