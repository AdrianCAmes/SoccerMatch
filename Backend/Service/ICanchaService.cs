using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.ViewModel;
namespace Service
{
    public interface ICanchaService : ICrudService<Cancha>
    {
        IEnumerable<CanchaViewModel> ListarTodos();
    }
}
