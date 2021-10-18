﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Validata.Common.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        Task<T> CreateAsync(T item, CancellationToken cancellationToken = default);

        void Update(T item);

        Task<T> UpdateAsync(T item);

        void Delete(T item);
        void DeleteAsync(T item, CancellationToken cancellationToken = default);

        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void SaveChanges();
    }

}
