using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementacion
{
    public class GrupoService : IGrupoService
    {
        private IGrupoService objGrupoService = new GrupoService();
        private IDistritoService objDistritoService = new DistritoService();
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
