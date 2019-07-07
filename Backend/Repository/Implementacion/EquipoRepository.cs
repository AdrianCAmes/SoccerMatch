using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository.dbcontext;
using System.Linq;
using Repository.ViewModel;

namespace Repository.Implementacion
{
    public class EquipoRepository : IEquipoRepository
    {
        private ApplicationDbContext context;
        public EquipoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> EquiposRecomendados(int  idUsuario)
        {   var participante=new List<Participante>();
            participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            var equipo=new List<Equipo>();
            foreach(var par in participante)
                equipo.Add(context.Equipo.Single(e=>e.Cequipo==par.Cequipo));
            return equipo;
        }

        public Equipo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAll()
        {
            var result = new List<Equipo>();
            try
            {
                result = context.Equipo.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Equipo entity)
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

        public bool Update(Equipo entity)
        {
            throw new NotImplementedException();
        }
    }
}
