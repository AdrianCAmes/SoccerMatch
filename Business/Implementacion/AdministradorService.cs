using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementacion
{
    public class AdministradorService : IAdministradorService
    {
        private IAdministradorService objAdministradorService = new AdministradorService();
        private ICalleService objCalleService = new CalleService();
        public bool Delete(int id)
        {
            return objAdministradorService.Delete(id);
        }

        public List<Administrador> FindAll()
        {
            return objAdministradorService.FindAll();
        }

        public Administrador FindById(int? id)
        {
            return objAdministradorService.FindById(id);
        }

        public bool Insertar(Administrador t)
        {
            Calle calle = objCalleService.FindById(t.CCalle.CCalle);
            t.CCalle = calle;

            return objAdministradorService.Insertar(t);
        }

        public bool Update(Administrador t)
        {
            return objAdministradorService.Update(t);
        }
    }
}
