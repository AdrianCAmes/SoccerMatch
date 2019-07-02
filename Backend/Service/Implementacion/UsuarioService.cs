using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Implementacion;
using Entity;
namespace Service.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository UsuarioRepository;
        public UsuarioService(IUsuarioRepository UsuarioRepository)
        {
            this.UsuarioRepository = UsuarioRepository;
        }

        public bool Delete(int id)
        {
            return UsuarioRepository.Delete(id);
        }

        public Usuario Get(int id)
        {
            return UsuarioRepository.Get(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioRepository.GetAll();
        }

        public bool Save(Usuario entity)
        {
            return UsuarioRepository.Save(entity);
        }

        public bool Update(Usuario entity)
        {
            return UsuarioRepository.Update(entity);
        }
    }
}
