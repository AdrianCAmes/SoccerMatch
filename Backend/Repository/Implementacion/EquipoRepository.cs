﻿using System;
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
                if (numParticipantes < 12 && lstaEquiposQuePertenece.Where(o => o.cequipo == equipo.Cequipo).Count() == 0)
                {
                    var objDistrito = new Distrito();
                    objDistrito = context.Distrito.Single(o => o.Cdistrito == equipo.Cdistrito);
                    var objEquipoRecomendado = new EquiposRecomendadosViewModel();
                    objEquipoRecomendado.Cequipo = equipo.Cequipo;
                    objEquipoRecomendado.Ndistrito = objDistrito.Ndistrito;
                    objEquipoRecomendado.Nequipo = equipo.Nequipo;
                    objEquipoRecomendado.NumParticipantes = numParticipantes;
                    objEquipoRecomendado.DfechaJuego = equipo.DfechaJuego;
                    objEquipoRecomendado.Tdescripcion = equipo.Tdescripcion;
                    lstaEquiposRecomendados.Add(objEquipoRecomendado);
                }
            }
            return lstaEquiposRecomendados;                          
                                         




            //var participante=new List<Participante>();
            //participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            //List<int> ids=new List<int>();
            //var equipo=new List<Equipo>();
            //foreach(var part in participante)
            //    ids.Add(part.Cequipo);
            //equipo=context.Equipo.Where(e=>!ids.Contains(e.Cequipo)).ToList();
            //var ndistritos = new List<string>();
            //foreach(var e in equipo)
            //{
            //    var distrito = context.Distrito.FirstOrDefault(x=>x.Cdistrito == e.Cdistrito);
            //    var nombre = distrito.Ndistrito;
            //    ndistritos.Add(nombre);
            //}
            //List<EquiposRecomendadosViewModel> equipoVM = new List<EquiposRecomendadosViewModel>();
            //foreach(var e in equipo)
            //{
            //    equipoVM.Add(new EquiposRecomendadosViewModel{
            //        Cequipo = e.Cequipo,
            //        Nequipo = e.Nequipo,
            //        Tdescripcion = e.Tdescripcion,
            //        DfechaJuego = e.DfechaJuego,
            //    });
            //}
            //for(var i = 0; i < equipoVM.Count(); i++)
            //{
            //    equipoVM.ElementAt(i).Ndistrito = ndistritos.ElementAt(i);
            //}

            //return equipoVM;
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
            var participante=new List<Participante>();
            participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            var equipo=new List<Equipo>();
            foreach(var par in participante)
                equipo.Add(context.Equipo.Single(e=>e.Cequipo==par.Cequipo));
            
            
            var ndistritos = new List<string>();
            foreach(var e in equipo)
            {
                var distrito = context.Distrito.FirstOrDefault(x=>x.Cdistrito == e.Cdistrito);
                var nombre = distrito.Ndistrito;
                ndistritos.Add(nombre);
            }
            List<EquiposRecomendadosViewModel> equipoVM = new List<EquiposRecomendadosViewModel>();
            foreach(var e in equipo)
            {
                equipoVM.Add(new EquiposRecomendadosViewModel{
                    Cequipo = e.Cequipo,
                    Nequipo = e.Nequipo,
                    Tdescripcion = e.Tdescripcion,
                    DfechaJuego = e.DfechaJuego,
                });
            }
            for(var i = 0; i < equipoVM.Count(); i++)
            {
                equipoVM.ElementAt(i).Ndistrito = ndistritos.ElementAt(i);
            }

            return equipoVM;
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
