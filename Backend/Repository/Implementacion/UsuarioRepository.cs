using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Repository.dbcontext;

namespace Repository.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Usuario Get(int id)
        {
            var result = new Usuario();
            try
            {
                result = context.Usuario.Single(x => x.Cusuario == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Usuario> GetAll()
        {

            var result = new List<Usuario>();
            try
            {
                result = context.Usuario.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Usuario entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Usuario entity)
        {
            try
            {
                var UsuarioOriginal = context.Usuario.Single(
                    x => x.Cusuario == entity.Cusuario
                );

                UsuarioOriginal.Cusuario = entity.Cusuario;
                UsuarioOriginal.Nusuario = entity.Nusuario;
                UsuarioOriginal.NumTelefono = entity.NumTelefono;
                UsuarioOriginal.Propietario = entity.Propietario;
                UsuarioOriginal.Pswd = entity.Pswd;
                UsuarioOriginal.Usuario1 = entity.Usuario1;

                context.Update(UsuarioOriginal);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
