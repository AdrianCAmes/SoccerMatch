using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.ViewModel;

namespace Repository
{
    public interface IAlquilerRepository : ICrudRepository<Alquiler>
    {
        IEnumerable<AlquilerDetalleXEquipo> AlquilerDetalle(int idEquipo);
        bool Guardar(AlquilerInsertarViewModel entity);
    }
}
