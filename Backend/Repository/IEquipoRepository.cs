using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository.ViewModel;

namespace Repository
{
    public interface IEquipoRepository:ICrudRepository<Equipo>
    {
        IEnumerable<EquiposRecomendadosViewModel> EquiposRecomendados(int idUsuario);
    }
}
