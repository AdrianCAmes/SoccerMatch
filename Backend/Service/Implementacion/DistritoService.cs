using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;
using Repository.Implementacion;

namespace Service.Implementacion
{
    public class DistritoService : IDistritoService
    {
        private IDistritoRepository distritoRepository;

        public DistritoService(IDistritoRepository distritoRepository)
        {
            this.distritoRepository = distritoRepository;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Distrito Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Distrito> GetAll()
        {
            return distritoRepository.GetAll();
        }
        
        public IEnumerable<string> GetAllNames()
        {
            return distritoRepository.GetAllNames();
        }

        public bool Save(Distrito entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Distrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
