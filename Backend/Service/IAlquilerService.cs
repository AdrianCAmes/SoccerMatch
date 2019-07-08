using Entity;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAlquilerService : ICrudService<Alquiler>
    {
        IEnumerable<AlquilerDetalleXEquipo> AlquilerDetalle(int idEquipo);
    }
}
