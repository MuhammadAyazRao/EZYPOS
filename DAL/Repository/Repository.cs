using DAL.DBModel;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            this.ctx = _dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity, bool isSaveChanges = true)
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (isSaveChanges)
            {
                Save();
            }
        }


        public void Change(TEntity entity, bool isSaveChanges = true)
        {
            _dbContext.Set<TEntity>().Update(entity);
            if (isSaveChanges)
            {
                Save();
            }
        }

        public void Delete(int id, bool isSaveChanges = true)
        {
            var entity = Get(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                if (isSaveChanges)
                {
                    _dbContext.SaveChanges();
                }
            }

        }

        public IQueryable<TEntity> GetAll_NoTracking()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public DbContext ctx { get; set; }

    }
}
