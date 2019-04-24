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
    public class JugadorRepository : IJugadorRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Jugador where CJugador='" + id + "'", con);
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

        public List<Jugador> FindAll()
        {
            List<Jugador> jugadores = new List<Jugador>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select j.CJugador,j.CCalle,j.TDireccion,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono,c.CCalle,c.CDistrito,c.NCalle from Jugador j, Usuario u, Calle c where j.CJugador = u.CUsuario and c.CCalle = j.CCalle", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var usuario = new Jugador();
                        var calle = new Calle();
                        calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                        calle.NCalle = dr["NCalle"].ToString();
                        calle.CDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                        usuario.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                        usuario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        usuario.NUsuario = dr["NUsuario"].ToString();
                        usuario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        usuario.CCalle = calle;
                        jugadores.Add(usuario);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jugadores;
        }

        public Jugador FindById(int? id)
        {
            var usuario = new Jugador();
            var calle = new Calle();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select j.CJugador,j.CCalle,j.TDireccion,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono,c.CCalle,c.CDistrito,c.NCalle from Jugador j, Usuario u, Calle c where j.CJugador='"+id+"'"+" and j.CJugador = u.CUsuario and c.CCalle = j.CCalle", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                        calle.NCalle = dr["NCalle"].ToString();
                        calle.CDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                        usuario.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                        usuario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        usuario.NUsuario = dr["NUsuario"].ToString();
                        usuario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        usuario.CCalle = calle;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }

        public bool Insertar(Jugador t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Jugador values(@CCalle,@TDireccion)",con);
                    cmd.Parameters.AddWithValue("@CCalle", t.CCalle.CCalle);
                    cmd.Parameters.AddWithValue("@TDireccion", t.TDireccion);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(Jugador t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Jugador set CCalle=@ccalle,TDireccion=@tdireccion",con);
                    cmd.Parameters.AddWithValue("@ccalle", t.CCalle.CCalle);
                    cmd.Parameters.AddWithValue("@tdireccion", t.TDireccion);
                    cmd.ExecuteNonQuery();
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
