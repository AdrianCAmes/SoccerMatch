using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository.dbcontext;
using System.Linq;
using Repository.ViewModel;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<DetalleEquipoViewModel> DetalleEquipo(int idEquipo)
        {
            var jugadoresDelEquipo = (from p in context.Participante
                                where p.Cequipo == idEquipo
                                select p.Cjugador
                                );
            var lstaJugadores = new List<Jugador>();
            var lstaDetalleEquipo = new List<DetalleEquipoViewModel>();
            foreach(var item in jugadoresDelEquipo)
            {
                var objJugador = context.Jugador.Include(o =>o.CjugadorNavigation).Single(obj => obj.Cjugador == item);
                lstaDetalleEquipo.Add(new DetalleEquipoViewModel()
                {
                    nombreUsuario = objJugador.CjugadorNavigation.Nusuario,
                    numeroContacto = objJugador.CjugadorNavigation.NumTelefono,
                    userUsuario = objJugador.CjugadorNavigation.Usuario1
                });
            }
            return lstaDetalleEquipo;

        }

        public IEnumerable<EquiposRecomendadosViewModel> EquiposRecomendados(int  idUsuario)
        { 
            var lstaEquiposQuePertenece = from p in context.Participante
                                          join e in context.Equipo
                                          on p.Cequipo equals e.Cequipo
                                          where p.Cjugador == idUsuario
                                          // group p by p.Cequipo into equiposDelJugador
                                          group p by p.Cequipo into equiposDelJugador
                                          select new {cequipo=equiposDelJugador.Key};

          
            var lstaEquiposRecomendados = new List<EquiposRecomendadosViewModel>();
            foreach (var equipo in context.Equipo)
            {
                var ParticipantesDelEquipo = from p in context.Participante
                                               where p.Cequipo == equipo.Cequipo
                                               select p.Cjugador;
                int numParticipantes = ParticipantesDelEquipo.Count();

                //if (numParticipantes<12 && lstaEquiposQuePertenece.Where(o=> o==4).Count()==0)
                if (numParticipantes < equipo.NumParticipantes && lstaEquiposQuePertenece.Where(o => o.cequipo == equipo.Cequipo).Count() == 0)
                {
                    var objDistrito = new Distrito();
                    objDistrito = context.Distrito.Single(o => o.Cdistrito == equipo.Cdistrito);
                    var objEquipoRecomendado = new EquiposRecomendadosViewModel();
                    objEquipoRecomendado.NumParticipantesActual = numParticipantes;
                    objEquipoRecomendado.Cequipo = equipo.Cequipo;
                    objEquipoRecomendado.Ndistrito = objDistrito.Ndistrito;
                    objEquipoRecomendado.Nequipo = equipo.Nequipo;
                    objEquipoRecomendado.NumParticipantes = equipo.NumParticipantes;
                    objEquipoRecomendado.DfechaJuego = equipo.DfechaJuego;
                    objEquipoRecomendado.Tdescripcion = equipo.Tdescripcion;
                    lstaEquiposRecomendados.Add(objEquipoRecomendado);
                }
            }
            return lstaEquiposRecomendados;
        }

        public Equipo Get(int id)
        {
            var equipo = new Equipo();
            try {
                equipo =  context.Equipo.FirstOrDefault(x=>x.Cequipo==id);
            }
            catch (System.Exception) {
                throw;
            }
            return equipo;  
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

        public IEnumerable<Participante> GetAllParticipantes(int idEqpo)
        {
            var participantes = context.Participante.ToList().Where(x=>x.Cequipo == idEqpo);

            return participantes;
        }

        public bool Guardar(EquiposInsertarViewModel entity)
        {
            var id_distrito = context.Distrito.FirstOrDefault(x=>x.Ndistrito == entity.Ndistrito);
            Equipo equipo = new Equipo {
                Nequipo = entity.Nequipo,
                Tdescripcion = entity.Tdescripcion,
                DfechaJuego = entity.DfechaJuego,
                NumParticipantes = entity.NumParticipantes,
                Cdistrito = id_distrito.Cdistrito,
            };
             
            context.Add(equipo);
            context.SaveChanges();
            Participante participante = new Participante {
                Cjugador = entity.idJugador,
                Cequipo = equipo.Cequipo,
                FesAdministrador = true,
                DfechaUnion = entity.DfechaRegistro,
            };
            context.Participante.Add(participante);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<EquiposRecomendadosViewModel> MisEquipos(int idUsuario)
        {
            var lstaEquiposQuePertenece = from p in context.Participante
                                          join e in context.Equipo
                                          on p.Cequipo equals e.Cequipo
                                          where p.Cjugador == idUsuario
                                          // group p by p.Cequipo into equiposDelJugador
                                          group p by p.Cequipo into equiposDelJugador
                                          select new { cequipo = equiposDelJugador.Key };




            var lstaEquiposDeUsuario = new List<EquiposRecomendadosViewModel>();
            foreach (var equipo in lstaEquiposQuePertenece)
            {
                var ParticipantesDelEquipo = from p in context.Participante
                                             where p.Cequipo == equipo.cequipo
                                             select p.Cjugador;
                int numParticipantes = ParticipantesDelEquipo.Count();

                var objEquipo = context.Equipo.Single(o => o.Cequipo == equipo.cequipo);

                   var objDistrito = new Distrito();
                   objDistrito = context.Distrito.Single(o => o.Cdistrito == objEquipo.Cdistrito);
                   var objEquipoDeUsuario = new EquiposRecomendadosViewModel();
                       objEquipoDeUsuario.NumParticipantesActual = numParticipantes ;
                       objEquipoDeUsuario.Cequipo = objEquipo.Cequipo;
                       objEquipoDeUsuario.Ndistrito = objDistrito.Ndistrito;
                       objEquipoDeUsuario.Nequipo = objEquipo.Nequipo;
                       objEquipoDeUsuario.NumParticipantes = objEquipo.NumParticipantes;
                       objEquipoDeUsuario.DfechaJuego = objEquipo.DfechaJuego;
                       objEquipoDeUsuario.Tdescripcion = objEquipo.Tdescripcion;
                lstaEquiposDeUsuario.Add(objEquipoDeUsuario);
            }
            return lstaEquiposDeUsuario;
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
            try {
                var equipoOriginal = context.Equipo.Single (
                    x=>x.Cequipo == entity.Cequipo
                );
                equipoOriginal.Cequipo = entity.Cequipo;
                equipoOriginal.Nequipo = entity.Nequipo;
                equipoOriginal.Tdescripcion = entity.Tdescripcion;
                equipoOriginal.DfechaJuego = entity.DfechaJuego;
                equipoOriginal.Cdistrito = entity.Cdistrito;
                equipoOriginal.NumParticipantes = entity.NumParticipantes;
                

                context.Equipo.Update(equipoOriginal);
                context.SaveChanges();
            }
            catch (System.Exception) {
                return false;
            }
            return true;
        }
    }
}
