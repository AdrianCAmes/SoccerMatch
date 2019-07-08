using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Repository.dbcontext;
namespace Repository.Implementacion
{
    public class JugadorRepository : IJugadorRepository
    {
         private ApplicationDbContext context;
         public JugadorRepository(ApplicationDbContext context){
             this.context=context;
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
             var result = new List<Jugador>();
            try
            {
                result = context.Jugador.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Jugador entity)
        {
            
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Jugador entity)
        {
            throw new NotImplementedException();
        }
    }
}
