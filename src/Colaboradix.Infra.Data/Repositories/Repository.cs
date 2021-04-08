using System;
using Colaboradix.Domain.Common;
using Colaboradix.Infra.Data.Context;

namespace Colaboradix.Infra.Data.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext
                ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
    }
}
