using Colaboradix.Application.Common.Interfaces;
using Colaboradix.Infra.Context;
using System;
using System.Threading.Tasks;

namespace Colaboradix.Infra.Services
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
