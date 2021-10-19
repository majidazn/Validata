using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.CustomerAggregate.Entities;
using Validata.Domain.OrderAggregate.Entities;
using Validata.Domain.ProductAggregate.Entities;

namespace Validata.DataAccess.Context
{
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

            //modelBuilder.ApplyConfiguration(new CenterConfiguration());
        }
    }
}
