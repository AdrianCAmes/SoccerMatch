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
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Usuario where CUsuario=" + id , con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Usuario> FindAll()
        {
            List<Usuario> Lsta_usuarios = new List<Usuario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select u.cusuario, u.cdni, u.nusuario,u.numtelefono from usuario u", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuario usuario_temp = new Usuario();
                            usuario_temp.CUsuario = Convert.ToInt32(dr["cusuario"]);
                            usuario_temp.CDNI = Convert.ToInt64(dr["cdni"]);
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
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
            {
                con.Open();
                var query = new SqlCommand("select u.cusuario, u.cdni, u.nusuario,u.numtelefono from usuario u where u.CUsuario = '" + id + "'", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario_temp = new Usuario();
                        usuario_temp.CUsuario = Convert.ToInt32(dr["cusuario"]);
                        usuario_temp.CDNI = Convert.ToInt32(dr["cdni"]);
                        usuario_temp.NUsuario = dr["nusuario"].ToString();
                        usuario_temp.NumTelefono = Convert.ToInt32(dr["numtelefono"]);
                    }
                }
            }
            return usuario_temp;
        }

        public bool Insertar(Usuario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into usuario values (@CDNI,@NUsuario,@NumTelefono)", con);

                
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
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Usuario set CDNI=@cdni,NUsuario=@nusuario,NumTelefono=@numtelefono where CUsuario='"+t.CUsuario+"'", con);
                    query.Parameters.AddWithValue("@cdni", t.CDNI);
                    query.Parameters.AddWithValue("@nusuario", t.NUsuario);
                    query.Parameters.AddWithValue("@numtelefono", t.NumTelefono);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rpta;
        }
    }
}
