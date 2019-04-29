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
    public class GrupoService : IGrupoService
    {
        private IGrupoRepository objGrupoService = new GrupoRepository();
        private IDistritoRepository objDistritoService = new DistritoRepository();
        public bool Delete(int id)
        {
            return objGrupoService.Delete(id);
        }

        public List<Grupo> FindAll()
        {
            return objGrupoService.FindAll();
        }

        public Grupo FindById(int? id)
        {
            return objGrupoService.FindById(id);
        }

        public bool Insertar(Grupo t)
        {
            Distrito distrito = objDistritoService.FindById(t.CDistrito.CDistrito);
            t.CDistrito = distrito;

            return objGrupoService.Insertar(t);
        }

        public bool Update(Grupo t)
        {
            return objGrupoService.Update(t);
        }
    }
}
