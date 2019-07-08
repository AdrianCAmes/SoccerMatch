using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository;
using Repository.ViewModel;

namespace Service.Implementacion
{
    public class EquipoService : IEquipoService
    {
        private IEquipoRepository equiporepository;
        public EquipoService(IEquipoRepository equiporepository)
        {
            this.equiporepository = equiporepository;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquiposRecomendadosViewModel> EquiposRecomendados(int idUsuario)
        {
            return equiporepository.EquiposRecomendados(idUsuario);
        }

        public Equipo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return equiporepository.GetAll();
        }

        public bool Guardar(EquiposInsertarViewModel entity)
        {
            return equiporepository.Guardar(entity);
        }

        public IEnumerable<EquiposRecomendadosViewModel> MisEquipos(int idUsuario)
        {
            return equiporepository.MisEquipos(idUsuario);
        }

        public bool Save(Equipo entity)
        {
            return equiporepository.Save(entity);
        }

        public bool Update(Equipo entity)
        {
            throw new NotImplementedException();
        }
    }
}
