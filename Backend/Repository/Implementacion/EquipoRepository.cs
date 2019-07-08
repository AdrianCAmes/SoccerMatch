﻿using System;
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
            var participante=new List<Participante>();
            participante= context.Participante.Where(p=>p.Cjugador==idUsuario).ToList();
            List<int> ids=new List<int>();
            var equipo=new List<Equipo>();
            foreach(var part in participante)
                ids.Add(part.Cequipo);
            equipo=context.Equipo.Where(e=>!ids.Contains(e.Cequipo)).ToList();
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
