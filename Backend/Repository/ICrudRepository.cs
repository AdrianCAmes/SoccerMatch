using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICrudRepository<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
