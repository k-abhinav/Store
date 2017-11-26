using Store.Core.Entities;
using Store.Core.Interfaces;
using System.Linq;

namespace Store.Infrastructure
{
    public class BaseEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TContext : EntityContext
        where TEntity : BaseEntity
    {
        EntityContext _db;

        public BaseEntityRepository(EntityContext entityContext)
        {
            _db = entityContext;
        }

        public IQueryable<TEntity> All
        {
            get { return ((IQueryable<TEntity>)_db.Set(typeof(TEntity))).Where(i => i.IsDeleted == false); }
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            entity.IsDeleted = true;
            _db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        private TEntity Find(int id)
        {
            return (TEntity)_db.Set(typeof(TEntity)).Find(id);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void InsertOrUpdate(TEntity entity)
        {
            if (entity.Id == default(int))
            {
                _db.Set(typeof(TEntity)).Add(entity);
            }
            else
            {
                _db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public IQueryable<TEntity> SqlQuery(string sql)
        {
            var obj = new object[1];
            return _db.Database.SqlQuery<TEntity>(sql, obj).AsQueryable<TEntity>();
        }
    }
}
