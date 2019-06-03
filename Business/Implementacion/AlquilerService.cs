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
    public class AlquilerService : IAlquilerService
    {
        private IAlquilerRepository objAlquilerService = new AlquilerRepository();
        private IGrupoRepository objGrupoService = new GrupoRepository();
        private ICanchaRepository objCanchaService = new CanchaRepository();
        public bool Delete(int id)
        {
            return objAlquilerService.Delete(id);
        }

        public List<Alquiler> FindAll()
        {
            return objAlquilerService.FindAll();
        }

        public Alquiler FindById(int? id)
        {
            return objAlquilerService.FindById(id);
        }

        public bool Insertar(Alquiler t)
        {
            Grupo grupo = objGrupoService.FindById(t.CGrupo.CGrupo);
            t.CGrupo = grupo;
            Cancha cancha = objCanchaService.FindById(t.CCancha.CCancha);
            t.CCancha = cancha;

            return objAlquilerService.Insertar(t);
        }

        public bool Update(Alquiler t)
        {
            Grupo grupo = objGrupoService.FindById(t.CGrupo.CGrupo);
            t.CGrupo = grupo;
            Cancha cancha = objCanchaService.FindById(t.CCancha.CCancha);
            t.CCancha = cancha;

            return objAlquilerService.Update(t);
        }
    }
}
