using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;
using Repository.Implementacion;
using Repository.ViewModel;

namespace Service.Implementacion
{
    public class CanchaService : ICanchaService
    {   
        private ICanchaRepository cancharepository;
        public CanchaService(ICanchaRepository cancharepository){
            this.cancharepository=cancharepository;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cancha Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cancha> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CanchaViewModel> ListarTodos()
        {
            return cancharepository.ListarTodos();
        }

        public bool Save(Cancha entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cancha entity)
        {
            throw new NotImplementedException();
        }
    }
}
