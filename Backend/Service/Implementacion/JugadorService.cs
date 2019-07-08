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
    public class JugadorService : IJugadorService
    {
        private IJugadorRepository jugadorrepository;
        public JugadorService(IJugadorRepository jugadorrepository){
            this.jugadorrepository=jugadorrepository;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Jugador Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jugador> GetAll()
        {
            return jugadorrepository.GetAll();
        }

        public bool Save(Jugador entity)
        {
            return jugadorrepository.Save(entity);
        }

        public bool Update(Jugador entity)
        {
            throw new NotImplementedException();
        }
    }
}
