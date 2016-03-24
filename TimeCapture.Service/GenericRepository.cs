using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCapture.Models;
using TimeCapture.Service.UnitOfWork;
using System.Data.Entity.Infrastructure;

namespace TimeCapture.Service
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        //    internal TCEntity db;
        //    internal IDbSet<TEntity> dbSet;
        //    private IUnitOfWork unw = new UnitOfWork();

        //    public GenericRepository(UnitOfWork db)
        //    {
        //        this.unw = db;
        //        this.dbSet = unw.Set<TEntity>();
        //    }

        //    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "")
        //    {
        //        IQueryable<TEntity> query = dbSet;

        //        if (filter != null)
        //        {
        //            query = query.Where(filter);
        //        }

        //        foreach (var includeProperty in includeProperties.Split
        //            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }

        //        if (orderBy != null)
        //        {
        //            return orderBy(query).ToList();
        //        }
        //        else
        //        {
        //            return query.ToList();
        //        }
        //    }

        //    public virtual TEntity GetById(object id)
        //    {
        //        return dbSet.Find(id);
        //    }

        //    public virtual void Insert(TEntity entity)
        //    {
        //        dbSet.Add(entity);
        //    }

        //    public virtual bool Any(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "")
        //    {
        //        IQueryable<TEntity> query = dbSet;
        //        if (filter != null)
        //        {
        //            query = query.Where(filter);
        //        }

        //        foreach (var includeProperty in includeProperties.Split
        //            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }

        //        if (orderBy != null)
        //        {
        //            return orderBy(query).Any();
        //        }
        //        else
        //        {
        //            return query.Any();
        //        }
        //    }

        //    public virtual void Delete(object id)
        //    {
        //        TEntity entityToDelete = dbSet.Find(id);
        //        Delete(entityToDelete);
        //    }

        //    public virtual void Delete(TEntity entityToDelete)
        //    {
        //        if (db.Entry(entityToDelete).State == EntityState.Detached)
        //        {
        //            dbSet.Attach(entityToDelete);
        //        }
        //        dbSet.Remove(entityToDelete);
        //    }

        //    public virtual void Update(TEntity entityToUpdate)
        //    {
        //        var entry = db.Entry<TEntity>(entityToUpdate);

        //        if (entry.State == EntityState.Detached)
        //        {
        //            db.Set<TEntity>().Attach(entityToUpdate);
        //            entry.State = EntityState.Modified;
        //        }
        //    }
    }
}
