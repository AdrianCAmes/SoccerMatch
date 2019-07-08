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
        IEnumerable<EquiposRecomendadosViewModel> MisEquipos(int idUsuario);
        bool Guardar(EquiposInsertarViewModel entity);
    }
}
