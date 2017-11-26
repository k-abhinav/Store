using System;
using System.Linq;

namespace Store.Core.Interfaces
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
        IQueryable<T> SqlQuery(string sql);
    }
}
