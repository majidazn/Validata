using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Common.Enums;
using Validata.DataAccess.Configurations.Customer;
using Validata.DataAccess.Configurations.Order;
using Validata.DataAccess.Configurations.Product;
using Validata.Domain.CustomerAggregate.Entities;
using Validata.Domain.OrderAggregate.Entities;
using Validata.Domain.ProductAggregate.Entities;

namespace Validata.DataAccess.Context
{
    // Add-Migration init -Project src\Infrastrutures\DataAccess\Validata.DataAccess -Context ECommerceBoundedContextCommand

    public class ECommerceBoundedContextCommand : DbContext
    {
        public ECommerceBoundedContextCommand(DbContextOptions<ECommerceBoundedContextCommand> options,
         IHttpContextAccessor httpContextAccessor)
         : base(options)
        {
            //this._httpContextAccessor = httpContextAccessor;
        }



        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());



            modelBuilder.Entity<Customer>().HasQueryFilter(p => p.Status != EntityStateType.Deleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => p.Status != EntityStateType.Deleted);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(p => p.Status != EntityStateType.Deleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.Status != EntityStateType.Deleted);
        }
    }
}
