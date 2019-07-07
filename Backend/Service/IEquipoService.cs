using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository.ViewModel;

namespace Service
{
    public interface IEquipoService:ICrudService<Equipo>
    {
        IEnumerable<Equipo> EquiposRecomendados(int idUsuario);
        IEnumerable<Equipo> MisEquipos(int idUsuario);
    }
}
