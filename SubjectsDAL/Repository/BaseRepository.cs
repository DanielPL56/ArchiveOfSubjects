using SubjectsDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SubjectsDAL.Repository
{
    public abstract class BaseRepository<T> : IDisposable where T:class
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

        public T GetOne(int id) => table.Find(id);

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
            table.Remove(entity);
            return SaveChanges();
        }

        public int Save(T entity)
        {
            table.AddOrUpdate(entity);
            return SaveChanges();
        }
    }
}
