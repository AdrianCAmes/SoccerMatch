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
    public class ParticipanteRepository : IParticipanteRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Participante where CParticipante='" + id + "'", con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Participante> FindAll()
        {
            List<Participante> participantes = new List<Participante>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CParticipante,p.CJugador,p.CEquipo,j.CCalle,j.CJugador,j.TDireccion,e.CDistrito,e.CEquipo,e.DFechaJuego,e.NEquipo,e.NEquipo,e.NumParticipantes,e.TDescripcion from Participante p, Jugador j, Equipo e where p.CParticipante = p.CJugador and p.CEquipo = e.CEquipo");
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var participante = new Participante();
                            var jugador = new Jugador();
                            var grupo = new Grupo();
                            participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                            jugador.CCalle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            jugador.CDNI = Convert.ToInt32(dr["CDNI"]);
                            jugador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                            jugador.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                            jugador.NUsuario = Convert.ToString(dr["NUsuario"]);
                            jugador.TDireccion = Convert.ToString(dr["TDireccion"]);
                            grupo.CDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                            grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                            grupo.NGrupo = Convert.ToString(dr["NEquipo"]);
                            grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                            grupo.TDescripcion = Convert.ToString(dr["TDescripcion"]);
                            participante.CJugador = jugador;
                            participante.CGrupo = grupo;
                            participantes.Add(participante);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return participantes;
        }

        public Participante FindById(int? id)
        {
            var participante = new Participante();
            var jugador = new Jugador();
            var grupo = new Grupo();
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                var cmd = new SqlCommand("select p.CParticipante,p.CJugador,p.CEquipo,j.CCalle,j.CJugador,j.TDireccion,e.CDistrito,e.CEquipo,e.DFechaJuego,e.NEquipo,e.NEquipo,e.NumParticipantes,e.TDescripcion from Participante p, Jugador j, Equipo e where p.CParticipante='"+id+"' and "+" p.CParticipante = p.CJugador and p.CEquipo = e.CEquipo");
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                    jugador.CCalle.CCalle = Convert.ToInt32(dr["CCalle"]);
                    jugador.CDNI = Convert.ToInt32(dr["CDNI"]);
                    jugador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                    jugador.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                    jugador.NUsuario = Convert.ToString(dr["NUsuario"]);
                    jugador.TDireccion = Convert.ToString(dr["TDireccion"]);
                    grupo.CDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                    grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                    grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                    grupo.NGrupo = Convert.ToString(dr["NEquipo"]);
                    grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                    grupo.TDescripcion = Convert.ToString(dr["TDescripcion"]);
                    participante.CJugador = jugador;
                    participante.CGrupo = grupo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return participante;
        }

        public bool Insertar(Participante t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("insert into Participante values(@CJugador,@CEquipo)",con);
                cmd.Parameters.AddWithValue("@CJugador",t.CJugador);
                cmd.Parameters.AddWithValue("@CEquipo", t.CGrupo);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(Participante t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("update Participante set CJugador=@cjugador,CEquipo=@cequipo",con);
                cmd.Parameters.AddWithValue("@cjugador", t.CJugador);
                cmd.Parameters.AddWithValue("@cequipo", t.CGrupo);
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
