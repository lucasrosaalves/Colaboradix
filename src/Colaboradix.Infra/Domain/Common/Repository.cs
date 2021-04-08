using System;
using Colaboradix.Domain.Common;

namespace Colaboradix.Infra.Data.Domain.Common
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
