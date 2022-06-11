using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();

        TEntity Get(int id);

        void Add(TEntity entity, bool isSaveChanges = true);

        void Change(TEntity entity, bool isSaveChanges = true);

        void Delete(int id, bool isSaveChanges = true);
        void RemoveRange(IEnumerable<TEntity> Entity);
        void AddRange(IEnumerable<TEntity> Entity);

        void Save();
    }
}
