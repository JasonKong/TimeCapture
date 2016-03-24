using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCapture.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
