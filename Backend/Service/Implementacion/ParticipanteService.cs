using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;
using Repository.Implementacion;

namespace Service.Implementacion
{
    public class ParticipanteService : IParticipanteService
    {
        private IParticipanteRepository participanteRepository;
        public ParticipanteService(IParticipanteRepository participanteRepository){
            this.participanteRepository=participanteRepository;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Participante Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Participante entity)
        {
            return participanteRepository.Save(entity);
        }

        public bool Update(Participante entity)
        {
            throw new NotImplementedException();
        }
    }
}
