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
    public class ParticipanteRepository : IParticipanteRepository
    {
         private ApplicationDbContext context;
         public ParticipanteRepository(ApplicationDbContext context){
             this.context=context;
         }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Participante Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Participante entity)
        {
            Participante participante = new Participante {
                Cjugador = entity.Cjugador,
                Cequipo = entity.Cequipo,
                FesAdministrador = entity.FesAdministrador,
                DfechaUnion = entity.DfechaUnion,
            };
            try {
                context.Participante.Add(participante);
                context.SaveChanges();
                var equipo = context.Equipo.FirstOrDefault(x=>x.Cequipo == entity.Cequipo);
                context.Equipo.Update(equipo);
                context.SaveChanges();
            }
            catch (System.Exception) {
                return false;
            }
            return true;
        }

        public bool Update(Participante entity)
        {
            throw new NotImplementedException();
        }
    }
}
