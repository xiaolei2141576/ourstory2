using OurStory.EfRepository.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurStory.EfRepository.Base
{
    public class GenericUnitOfWork : IDisposable
    {
        private EfDbContext dbContext = null;

        public GenericUnitOfWork()
        {
            dbContext = new EfDbContext();
        }
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new GenericRepository<T>(dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
