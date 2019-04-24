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
            return objUsuarioRepositorio.Delete(id);
        }

        public List<Usuario> FindAll()
        {
            return objUsuarioRepositorio.FindAll();
        }

        public Usuario FindById(int? id)
        {
            return objUsuarioRepositorio.FindById(id);
        }

        public bool Insertar(Usuario t)
        {
            return objUsuarioRepositorio.Insertar(t);
        }

        public bool Update(Usuario t)
        {
            return objUsuarioRepositorio.Update(t);
        }
    }
}
