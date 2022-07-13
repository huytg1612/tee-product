using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Repositories
{
    public interface IBaseRepository<E, K> where E : class
    {
        EntityEntry<E> Create(E entity);
        EntityEntry<E> Update(E entity);
        int SaveChanges();
        EntityEntry<E> Remove(E entity);
        DbSet<E> Get();
    }

    public class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
    {
        DbContext _dbContext;
        DbSet<E> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<E>();
        }
        public EntityEntry<E> Create(E entity)
        {
            return _dbSet.Add(entity);
        }

        public DbSet<E> Get()
        {
            return _dbSet;
        }

        public EntityEntry<E> Remove(E entity)
        {
            return _dbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public EntityEntry<E> Update(E entity)
        {
            return _dbSet.Update(entity);
        }
    }
}
