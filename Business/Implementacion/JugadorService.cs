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
    public class JugadorService : IJugadorService
    {
        private IJugadorRepository objJugadorService = new JugadorRepository();
        private IUsuarioRepository objUsuarioService = new UsuarioRepository();
        private ICalleRepository objCalleService = new CalleRepository();
        public bool Delete(int id)
        {
            return objJugadorService.Delete(id);
        }

        public List<Jugador> FindAll()
        {
            return objJugadorService.FindAll();
        }

        public Jugador FindById(int? id)
        {
            return objJugadorService.FindById(id);
        }

        public bool Insertar(Jugador t)
        {
            Usuario usuario = objJugadorService.FindById(t.CUsuario);
            t.CUsuario = usuario.CUsuario;
            Calle calle = objCalleService.FindById(t.CCalle.CCalle);
            t.CCalle = calle;

            return objJugadorService.Insertar(t);
        }

        public bool Update(Jugador t)
        {
            return objJugadorService.Update(t);
        }
    }
}
