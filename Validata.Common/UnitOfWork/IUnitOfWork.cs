using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
