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

        public IEnumerable<Equipo> EquiposRecomendados(int  idUsuario)
        {   
            var participante=new List<Participante>();
            participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            List<int> ids=new List<int>();
            var equipo=new List<Equipo>();
            foreach(var part in participante)
                ids.Add(part.Cequipo);
            equipo=context.Equipo.Where(e=>!ids.Contains(e.Cequipo)).ToList();
            return equipo.Select (o => new Equipo {
                Cequipo=o.Cequipo,
                    Nequipo = o.Nequipo,
                    Tdescripcion = o.Tdescripcion,
                    NumParticipantes = o.NumParticipantes,
                   DfechaJuego = o.DfechaJuego,
                    Cdistrito = o.Cdistrito
            });
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

        public IEnumerable<Equipo> MisEquipos(int idUsuario)
        {
            var participante=new List<Participante>();
            participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            var equipo=new List<Equipo>();
            foreach(var par in participante)
                equipo.Add(context.Equipo.Single(e=>e.Cequipo==par.Cequipo));
                        return equipo.Select (o => new Equipo {
                Cequipo=o.Cequipo,
                    Nequipo = o.Nequipo,
                    Tdescripcion = o.Tdescripcion,
                    NumParticipantes = o.NumParticipantes,
                   DfechaJuego = o.DfechaJuego,
                    Cdistrito = o.Cdistrito
            });
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
