using Course_API.Models;
using Course_API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_API.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        VfDbContext GetContext();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
