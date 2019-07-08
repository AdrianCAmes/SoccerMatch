using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Repository.ViewModel;
using Repository.dbcontext;

namespace Repository.Implementacion
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private ApplicationDbContext context;
        public AlquilerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<AlquilerDetalleXEquipo> AlquilerDetalle(int idEquipo)
        {
            var tablaAlquilerDetalle = from a in context.Alquiler
                       join e in context.Equipo
                       on a.Cequipo equals e.Cequipo
                      join d in context.Distrito
                      on e.Cdistrito equals d.Cdistrito
                      join c in context.Cancha
                      on a.Ccancha equals c.Ccancha
                      where a.Cequipo == idEquipo
                       select new
                       {
                           ncancha = c.Ncancha,
                           fInicio = a.DfechaInicio,
                           direccion = c.Tdireccion,
                           ndistrito = d.Ndistrito,
                           numParticipante = e.NumParticipantes,
                           horas = a.NumHoras
                       };
            var listaAlquilerDetalle = new List<AlquilerDetalleXEquipo>();

            foreach(var campo in tablaAlquilerDetalle)
            {
                var objAlquilerDetalle = new AlquilerDetalleXEquipo();
                objAlquilerDetalle.ncancha = campo.ncancha;
                objAlquilerDetalle.fInicio= campo.fInicio;
                objAlquilerDetalle.tdireccion= campo.direccion;
                objAlquilerDetalle.ndistrito= campo.ndistrito;
                objAlquilerDetalle.numparticipantes= campo.numParticipante;
                objAlquilerDetalle.numhoras= campo.horas;
                listaAlquilerDetalle.Add(objAlquilerDetalle);
            }
            return listaAlquilerDetalle;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    

        public Alquiler Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alquiler> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(AlquilerInsertarViewModel entity)
        {
            Cancha cancha = new Cancha();
            for(var i = 0; i < 1; i++)
            {
                cancha = context.Cancha.FirstOrDefault(x=>x.Ccancha == entity.canchas.ElementAt(i).Ccancha);
            }
            Alquiler alquiler = new Alquiler {
                Cequipo = entity.Cequipo,
                Ccancha = cancha.Ccancha,
                DfechaInicio = entity.DfechaInicio,
                DfechaRegistro = entity.DfechaRegistro,
                NumHoras  = entity.NumHoras,
                Mdescuento  = 0,
                Mtotal  = entity.NumHoras*cancha.MprecioHora,
                Fpagado = false,
            };
            try {
                context.Alquiler.Add(alquiler);
                context.SaveChanges();
                foreach(var p in entity.participantes)
                {
                    DetalleParticipante dp = new DetalleParticipante{
                        Calquiler = alquiler.Calquiler,
                        Cparticipante = p.Cparticipante,
                        Mcuota = alquiler.Mtotal/entity.participantes.Count(),
                        FpartePagada = false,
                        Ncupos = 1,
                    };
                    context.DetalleParticipante.Add(dp);
                }
                context.SaveChanges();
            }
            catch (System.Exception) {
                return false;
            }
            return true;
            
              
        }

        public bool Save(Alquiler entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Alquiler entity)
        {
            throw new NotImplementedException();
        }
    }
}
