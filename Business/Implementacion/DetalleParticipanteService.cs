using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;

namespace Business.Implementacion
{
    public class DetalleParticipanteService : IDetalleParticipanteService
    {
        private IDetalleParticipanteRepository objDetalleParticipante = new DetalleParticipanteRepository();
        private IParticipanteRepository objParticipante = new ParticipanteRepository();
        private IAlquilerRepository objAlquiler = new AlquilerRepository();
        public bool Delete(int id)
        {
            return objDetalleParticipante.Delete(id);
        }

        public List<DetalleParticipante> FindAll()
        {
            return objDetalleParticipante.FindAll();
        }

        public DetalleParticipante FindById(int? id)
        {
            return objDetalleParticipante.FindById(id);
        }

        public bool Insertar(DetalleParticipante t)
        {
            return objDetalleParticipante.Insertar(t);
        }

        public bool Update(DetalleParticipante t)
        {
            return objDetalleParticipante.Update(t);
        }
    }
}
