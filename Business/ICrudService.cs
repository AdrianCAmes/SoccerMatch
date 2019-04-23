using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICrudService<T>
    {
        bool Delete(int id);
        bool Insertar(T t);
        bool Update(T t);
        List<T> FindAll();
        T FindById(int? id);
    }
}
