using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;

namespace Business.Implementacion
{
    public class CalleService : ICalleService
    {
        private ICalleRepository objCalleService = new CalleRepository();
        private IDistritoRepository objDistritoService = new DistritoRepository();
        public bool Delete(int id)
        {
            return objCalleService.Delete(id);
        }

        public List<Calle> FindAll()
        {
            return objCalleService.FindAll();
        }

        public Calle FindById(int? id)
        {
            return objCalleService.FindById(id);
        }

        public bool Insertar(Calle t)
        {
            Distrito distrito = objDistritoService.FindById(t.CDistrito.CDistrito);
            t.CDistrito = distrito;

            return objCalleService.Insertar(t);
        }

        public bool Update(Calle t)
        {
            return objCalleService.Update(t);
        }
    }
}
