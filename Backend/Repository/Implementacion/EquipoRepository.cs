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

        public IEnumerable<EquiposRecomendadosViewModel> EquiposRecomendados(int  idUsuario)
        {
            var entity = context.Usuario.Single(o => o.Cusuario == idUsuario);
            var lstaDistritos = context.Distrito;
            

            var participantesEnMismoDistrito = (from participante in context.Participante
                                                join equipo in context.Equipo
                                                on participante.Cequipo equals equipo.Cequipo
                                                where equipo.Cdistrito == entity.Cdistrito
                                                select new { Participante = participante, Equipo = equipo });
            List<EquiposRecomendadosViewModel> lstaEquiposRecomendadosVista = new List<EquiposRecomendadosViewModel>();
            foreach (var item in participantesEnMismoDistrito)
            {              
                var objEquiposRecomendados = new EquiposRecomendadosViewModel();
                var equipo = item.Equipo;
                var participante = item.Participante;

                var objDistrito = new Distrito();
                objDistrito = context.Distrito.Single(x => x.Cdistrito == equipo.Cdistrito);


                objEquiposRecomendados.fechaJuego = equipo.DfechaJuego;
                objEquiposRecomendados.idEquipo = equipo.Cequipo;
                objEquiposRecomendados.NombreEquipo = equipo.Nequipo;
                objEquiposRecomendados.NombreDistrito = objDistrito.Ndistrito;
                lstaEquiposRecomendadosVista.Add(objEquiposRecomendados);
               // objEquiposRecomendados.CantidadVacantes
            }
            return lstaEquiposRecomendadosVista;
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
