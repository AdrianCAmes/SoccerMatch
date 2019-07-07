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
    public class DetalleParticipanteRepository : IDetalleParticipanteRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from DetalleParticipante where CDetalleParticipante='" + id + "'", con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<DetalleParticipante> FindAll()
        {
            List<DetalleParticipante> detalles = new List<DetalleParticipante>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select dp.CDetalleParticipante,dp.CAlquiler,dp.CParticipante,dp.MCuota,dp.FPartePagada,dp.NCupos,a.CCancha,a.CEquipo, a.DFechaInicio,a.FPagado,a.MDescuento,a.MTotal,a.NumHoras,p.CParticipante, u.NUsuario, u.CUsuario from DetalleParticipante dp, Alquiler a, Participante p, Usuario u where dp.CAlquiler = a.CAlquiler and dp.CParticipante = p.CParticipante and p.CJugador = u.CUsuario", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var detalle = new DetalleParticipante();
                            var alquiler = new Alquiler();
                            var participante = new Participante();
                            var grupo = new Grupo();
                            var cancha = new Cancha();
                            var jugador = new Jugador();
                            cancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                            grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                            detalle.CDetalleParticipante = Convert.ToInt32(dr["CDetalleParticipante"]);
                            alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                            participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                            jugador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                            jugador.NUsuario = dr["NUsuario"].ToString();
                            participante.CJugador = jugador;
                            detalle.MCuota = Convert.ToDecimal(dr["MCuota"]);
                            detalle.FPartePagada = Convert.ToBoolean(dr["FPartePagada"]);
                            detalle.NCupos = Convert.ToInt32(dr["NCupos"]);
                            alquiler.CCancha = cancha;
                            alquiler.CGrupo = grupo;
                            alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
                            alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                            alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                            alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                            alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                            detalle.CAlquiler = alquiler;
                            detalle.CParticipante = participante;
                            detalles.Add(detalle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detalles;
        }

        public DetalleParticipante FindById(int? id)
        {
            DetalleParticipante detalle = null;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("select dp.CDetalleParticipante,dp.CAlquiler,dp.CParticipante,dp.MCuota,dp.FPartePagada,dp.NCupos,a.CCancha,a.CEquipo, a.DFechaInicio,a.FPagado,a.MDescuento,a.MTotal,a.NumHoras,p.CParticipante, u.NUsuario, u.CUsuario from DetalleParticipante dp, Alquiler a, Participante p, Usuario u where dp.CDetalleParticipante = '" + id + "' and dp.CAlquiler = a.CAlquiler and dp.CParticipante = p.CParticipante and p.CJugador = u.CUsuario", con);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    detalle = new DetalleParticipante();
                    var alquiler = new Alquiler();
                    var participante = new Participante();
                    var grupo = new Grupo();
                    var cancha = new Cancha();
                    var jugador = new Jugador();
                    cancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                    grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                    detalle.CDetalleParticipante = Convert.ToInt32(dr["CDetalleParticipante"]);
                    alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                    participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                    jugador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                    jugador.NUsuario = dr["NUsuario"].ToString();
                    participante.CJugador = jugador;
                    detalle.MCuota = Convert.ToDecimal(dr["MCuota"]);
                    detalle.FPartePagada = Convert.ToBoolean(dr["FPartePagada"]);
                    detalle.NCupos = Convert.ToInt32(dr["NCupos"]);
                    alquiler.CCancha = cancha;
                    alquiler.CGrupo = grupo;
                    alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
                    alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                    alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                    alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                    alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                    detalle.CAlquiler = alquiler;
                    detalle.CParticipante = participante;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detalle;
        }

        public bool Insertar(DetalleParticipante t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("insert into DetalleParticipante values(@CAlquiler,@CParticipante,@MCuota,@FPartePagada,@NCupos)",con);
                cmd.Parameters.AddWithValue("@CAlquiler", t.CAlquiler.CAlquiler);
                cmd.Parameters.AddWithValue("@CParticipante", t.CParticipante.CParticipante);
                cmd.Parameters.AddWithValue("@MCuota", t.MCuota);
                cmd.Parameters.AddWithValue("@FPartePagada", t.FPartePagada);
                cmd.Parameters.AddWithValue("@NCupos", t.NCupos);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(DetalleParticipante t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("update DetalleParticipante set CAlquiler=@calquiler,CParticipante=@cparticipante,MCuota=@mcuota,FPartePagada=@fpartepagada,NCupos=@ncupos where CDetalleParticipante='" + t.CDetalleParticipante + "'", con);
                cmd.Parameters.AddWithValue("calquiler", t.CAlquiler.CAlquiler);
                cmd.Parameters.AddWithValue("cparticipante", t.CParticipante.CParticipante);
                cmd.Parameters.AddWithValue("mcuota", t.MCuota);
                cmd.Parameters.AddWithValue("fpartepagada", t.FPartePagada);
                cmd.Parameters.AddWithValue("ncupos", t.NCupos);
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
