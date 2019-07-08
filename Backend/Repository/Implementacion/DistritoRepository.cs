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
            var distritos = new List<Distrito>();
            try {
                distritos = context.Distrito.ToList();
            }
            catch(System.Exception) {
                throw;
            }
            return distritos;            
        }

        public IEnumerable<string> GetAllNames()
        {
            var distritos = new List<Distrito>();
            var nombres = new List<string>();
            try {
                distritos = context.Distrito.ToList();
                foreach(var d in distritos)
                {
                    nombres.Add(d.Ndistrito);
                }
            }
            catch(System.Exception) {
                throw;
            }
            return nombres;
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
