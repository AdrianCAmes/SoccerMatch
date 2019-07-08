using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.dbcontext;
using System.Data.SqlClient;
using System.Configuration;

namespace Repository.Implementacion
{
    public class DistritoRepository : IDistritoRepository
    {
        private ApplicationDbContext context;
        public DistritoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Distrito Get(int id)
        {
            var entity = new Distrito();
            try{
                entity = context.Distrito.FirstOrDefault(x=>x.Cdistrito == id);
            }
            catch(System.Exception) {
                throw;
            }
            return entity;
        }

        public IEnumerable<Distrito> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Distrito entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Distrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
