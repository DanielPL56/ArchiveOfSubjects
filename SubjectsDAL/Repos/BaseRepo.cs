using SubjectsDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectsDAL.Repos
{
    public abstract class BaseRepo<T> : IDisposable where T:class
    {
        public SubjectEntities context { get; } = new SubjectEntities();

        public DbSet<T> table;

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        internal int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetOne(int? id) => table.Find(id);

        public List<T> GetAll() => table.ToList();

        public int Add(T entity)
        {
            table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(List<T> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Save(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
    }
}
