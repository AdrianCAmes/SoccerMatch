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
    public class ParticipanteService : IParticipanteService
    {
        IParticipanteRepository objParticipanteRepository = new ParticipanteRepository();
        IJugadorRepository objJugadorRepository = new JugadorRepository();
        IGrupoRepository objGrupoRepository = new GrupoRepository();
        public bool Delete(int id)
        {
            return objParticipanteRepository.Delete(id);
        }

        public List<Participante> FindAll()
        {
            return objParticipanteRepository.FindAll();
        }

        public Participante FindById(int? id)
        {
            return objParticipanteRepository.FindById(id);
        }

        public bool Insertar(Participante t)
        {
            Jugador jugador = objJugadorRepository.FindById(t.CJugador.CUsuario);
            t.CJugador = jugador;
            Grupo grupo = objGrupoRepository.FindById(t.CGrupo.CGrupo);
            t.CGrupo = grupo;

            return objParticipanteRepository.Insertar(t);
        }

        public bool Update(Participante t)
        {
            return objParticipanteRepository.Update(t);
        }
    }
}
