using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectsDAL.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(List<T> entities);
        T GetOne(int? id);
        List<T> GetAll();
        int Delete(T entity);
        int Save(T entity);

    }
}
