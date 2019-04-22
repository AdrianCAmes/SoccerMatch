using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICrudService<T>
    {
        bool Delete(int id);
        bool Insert(T t);
        bool Update(T t);
        List<T> FindAll();
        T FindById(int? id);
    }
}
