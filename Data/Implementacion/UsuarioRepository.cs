using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Configuration;

namespace Data.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            List<Usuario> Lsta_usuarios = new List<Usuario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select u.cusuario, u.cdni, u.nusuario,u.numtelefono from usuario u",con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuario usuario_temp = new Usuario();
                            usuario_temp.CUsuario = Convert.ToInt16(dr["cusuario"]);
                            usuario_temp.CDNI = Convert.ToInt32(dr["cdni"]);
                            usuario_temp.NUsuario = dr["nusuario"].ToString();
                            usuario_temp.NumTelefono = Convert.ToInt32(dr["numtelefono"]);
                            Lsta_usuarios.Add(usuario_temp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Lsta_usuarios;
        }

        public Usuario FindById(int? id)
        {
            Usuario usuario_temp = null;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
            {
                con.Open();
                var query = new SqlCommand("select u.cusuario, u.cdni, u.nusuario,u.numtelefono from usuario u where u.cusuario=@id",con);
                using (var dr = query.ExecuteReader())
                {
                    query.Parameters.AddWithValue("@id", id);
                    usuario_temp = new Usuario();
                    usuario_temp.CUsuario = Convert.ToInt16(dr["cusuario"]);
                    usuario_temp.CDNI = Convert.ToInt32(dr["cusuario"]);
                    usuario_temp.NumTelefono = Convert.ToInt32(dr["numtelefono"]);
                    usuario_temp.NUsuario = dr["nusuario"].ToString();
                }
            }
            return usuario_temp;
        }

        public bool Insertar(Usuario t)
        {
            bool rpta = false;
            try
            { 
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into usuario values (@CUsuario, @CDNI,@NUsuario,@NumTelefono)", con);

                    query.Parameters.AddWithValue("@CUsuario", t.CUsuario);
                    query.Parameters.AddWithValue("@CDNI", t.CDNI);
                    query.Parameters.AddWithValue("@NUsuario", t.NUsuario);
                    query.Parameters.AddWithValue("@NumTelefono", t.NumTelefono);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }

        public bool Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
