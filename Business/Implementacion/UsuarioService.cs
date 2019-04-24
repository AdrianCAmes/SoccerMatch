using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Entity;
namespace Business.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository objUsuarioRepositorio = new UsuarioRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            return objUsuarioRepositorio.FindAll();
        }

        public Usuario FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
