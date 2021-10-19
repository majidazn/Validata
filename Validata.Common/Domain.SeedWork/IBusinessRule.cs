using System;
using System.Collections.Generic;
using System.Text;

namespace Validata.Common.Domain.SeedWork
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }

    }
}
