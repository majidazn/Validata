using System;
using System.Linq;

namespace Validata.DataAccess.Context
{
    public class ECommerceBoundedContextQuery : IDisposable
    {

        #region Fields

        private readonly ECommerceBoundedContextCommand _context;
        private bool _disposed = false;

        #endregion
        #region Properties

        public ECommerceBoundedContextQuery(ECommerceBoundedContextCommand context)
        {
            this._context = context;
        }

        internal IQueryable<Domain.CustomerAggregate.Entities.Customer> Customers
        {
            get { return _context.Customers; }
        }

        internal IQueryable<Domain.OrderAggregate.Entities.Order> Orders
        {
            get { return _context.Orders; }
        }

        internal IQueryable<Domain.OrderAggregate.Entities.OrderItem> OrderItems
        {
            get { return _context.OrderItems; }
        }

        internal IQueryable<Domain.ProductAggregate.Entities.Product> Products
        {
            get { return _context.Products; }
        }
        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
