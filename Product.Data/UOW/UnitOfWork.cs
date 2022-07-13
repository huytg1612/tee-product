using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.UOW
{
    public interface IUnitOfWork
    {
        T GetService<T>();
        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        IServiceProvider _serviceProvider;
        private DbContext _dbContext;

        public UnitOfWork(IServiceProvider serviceProvider, DbContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;
        }
        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
