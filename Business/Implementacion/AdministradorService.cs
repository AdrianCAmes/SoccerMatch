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
        private IJugadorService objJugadorService = new JugadorService();
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
            Jugador jugador = objJugadorService.FindById(t.CUsuario);
            t.CUsuario = jugador.CUsuario;

            return objAdministradorService.Insertar(t);
        }

        public bool Update(Administrador t)
        {
            return objAdministradorService.Update(t);
        }
    }
}
