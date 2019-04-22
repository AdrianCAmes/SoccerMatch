using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;

namespace Service.Implementacion
{
   public class BancoService : IBancoService
    {
        private IBancoRepository bancoRepository = new BancoRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Banco> FindAll()
        {
            return bancoRepository.FindAll();
        }

        public Banco FindById(int? id)
        {
            return bancoRepository.FindById(id);
        }

        public bool Insert(Banco t)
        {
            return bancoRepository.Insertar(t);
        }

        public bool Update(Banco t)
        {
            return bancoRepository.Update(t);
        }
    }
}
