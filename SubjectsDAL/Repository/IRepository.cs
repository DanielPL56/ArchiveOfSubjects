using System.Collections.Generic;

namespace SubjectsDAL.Repository
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int AddRange(List<T> entities);
        T GetOne(int id);
        List<T> GetAll();
        int Delete(T entity);
        int Save(T entity);
    }
}
