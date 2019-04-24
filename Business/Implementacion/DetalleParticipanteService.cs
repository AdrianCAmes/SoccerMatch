using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementacion
{
    public class DetalleParticipanteService : IDetalleParticipanteService
    {
        private IDetalleParticipanteService objDetalleParticipante = new DetalleParticipanteService();
        private IParticipanteService objParticipante = new ParticipanteService();
        private IAlquilerService objAlquiler = new AlquilerService();
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
            Participante participante = objParticipante.FindById(t.CParticipante.CParticipante);
            t.CParticipante = participante;
            Alquiler alquiler = objAlquiler.FindById(t.CAlquiler.CAlquiler);
            t.CAlquiler = alquiler;

            return objDetalleParticipante.Insertar(t);
        }

        public bool Update(DetalleParticipante t)
        {
            return objDetalleParticipante.Update(t);
        }
    }
}
