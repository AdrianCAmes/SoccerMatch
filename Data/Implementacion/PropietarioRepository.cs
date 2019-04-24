using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementacion
{
    public class PropietarioRepository : IPropietarioRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Propietario where id='" + id + "'", con);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Propietario> FindAll()
        {
            List<Propietario> propietarios = new List<Propietario>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CPropietario,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono from Propietario p, Usuario u where p.CPropietario = u.CUsuario", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var propietario = new Propietario();
                        propietario.CUsuario = Convert.ToInt32(dr["CJugador"]);
                        propietario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        propietario.NUsuario = Convert.ToString(dr["NUsuario"]);
                       propietarios.Add(propietario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propietarios;
        }

        public Propietario FindById(int? id)
        {
            Propietario propietarios = new Propietario();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CPropietario,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono from Propietario p, Usuario u where p.CPropietario='"+id+"' and "+" p.CPropietario = u.CUsuario", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var propietario = new Propietario();
                        propietario.CUsuario = Convert.ToInt32(dr["CJugador"]);
                        propietario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        propietario.NUsuario = Convert.ToString(dr["NUsuario"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propietarios;
        }

        public bool Insertar(Propietario t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("insert into Propietario values(@CUsuario,@CDNI,@NUsuario,@NumTelefono)");
                cmd.Parameters.AddWithValue("@CUsuario", t.CUsuario);
                cmd.Parameters.AddWithValue("@CDNI", t.CDNI);
                cmd.Parameters.AddWithValue("NUsuario", t.NUsuario);
                cmd.Parameters.AddWithValue("NumTelefono", t.NumTelefono);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(Propietario t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("update Propietario set CUsuario=@cusuario,CDNI=@cdni,NUsuario=@nusuario,NumTelefono=@numtelefono");
                cmd.Parameters.AddWithValue("@cusuario", t.CUsuario);
                cmd.Parameters.AddWithValue("@cdni", t.CDNI);
                cmd.Parameters.AddWithValue("nusuario", t.NUsuario);
                cmd.Parameters.AddWithValue("numtelefono", t.NumTelefono);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }
    }
}
