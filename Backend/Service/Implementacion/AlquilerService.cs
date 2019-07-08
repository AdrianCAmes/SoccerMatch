using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;
using Repository.dbcontext;
using Repository.Implementacion;
using Repository.ViewModel;

namespace Service.Implementacion
{
    public class AlquilerService : IAlquilerService
    {
        
        private IAlquilerRepository alquilerRepository;

        public AlquilerService(IAlquilerRepository alquilerRepository)
        {
            this.alquilerRepository = alquilerRepository;
        }

     

        public IEnumerable<AlquilerDetalleXEquipo> AlquilerDetalle(int idEquipo)
        {
            return alquilerRepository.AlquilerDetalle(idEquipo);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Alquiler Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alquiler> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Alquiler entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Alquiler entity)
        {
            throw new NotImplementedException();
        }
    }
}
