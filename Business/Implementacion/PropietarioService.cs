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
    public class PropietarioService : IPropietarioService
    {
        private IPropietarioRepository objPropietarioRepository = new PropietarioRepository();
        private IUsuarioRepository objUsuarioRepository = new UsuarioRepository();

        public bool Delete(int id)
        {
            return objPropietarioRepository.Delete(id);
        }

        public List<Propietario> FindAll()
        {
            return objPropietarioRepository.FindAll();
        }

        public Propietario FindById(int? id)
        {
            return objPropietarioRepository.FindById(id);
        }

        public bool Insertar(Propietario t)
        {
                 return objPropietarioRepository.Insertar(t);
        }

        public bool Update(Propietario t)
        {
            return objPropietarioRepository.Update(t);
        }
    }
}
