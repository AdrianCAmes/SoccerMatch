using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.ViewModel;
namespace Repository
{
    public interface ICanchaRepository : ICrudRepository<Cancha>
    {
        IEnumerable<CanchaViewModel> ListarTodos();
    }
}
