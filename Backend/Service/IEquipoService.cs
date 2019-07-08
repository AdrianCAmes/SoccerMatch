using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository.ViewModel;

namespace Service
{
    public interface IEquipoService:ICrudService<Equipo>
    {
        IEnumerable<EquiposRecomendadosViewModel> EquiposRecomendados(int idUsuario);
        IEnumerable<EquiposRecomendadosViewModel> MisEquipos(int idUsuario);
        bool Guardar(EquiposInsertarViewModel entity);
        IEnumerable<DetalleEquipoViewModel> DetalleEquipo(int idEquipo);
    }
}
