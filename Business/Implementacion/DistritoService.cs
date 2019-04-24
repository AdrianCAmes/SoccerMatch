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
    public class DistritoService : IDistritoService
    {
        private IDistritoRepository objDistritoRep = new DistritoRepository();
        private ICiudadRepository objCiudadRep = new CiudadRepository();
        public bool Delete(int id)
        {
            return objDistritoRep.Delete(id);
        }

        public List<Distrito> FindAll()
        {
            return objDistritoRep.FindAll();
        }

        public Distrito FindById(int? id)
        {
            return objDistritoRep.FindById(id);
        }

        public bool Insertar(Distrito t)
        {
            Ciudad ciudad = objCiudadRep.FindById(t.CCiudad.CCiudad);
            t.CCiudad = ciudad;

            return objDistritoRep.Insertar(t);
        }

        public bool Update(Distrito t)
        {
            return objDistritoRep.Update(t);
        }
    }
}
