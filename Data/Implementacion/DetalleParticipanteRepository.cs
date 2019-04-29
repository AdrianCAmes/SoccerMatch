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
<<<<<<< HEAD
                    var cmd = new SqlCommand("select dp.CDetalleParticipante,dp.CAlquiler,dp.CParticipante,dp.MCuota,dp.FPartePagada,a.CCancha,a.CEquipo, a.DHoraInicio,a.FPagado,a.MDescuento,a.MTotal,a.NumHoras,p.CJugador from DetalleParticipante dp, Alquiler a, Participante p where dp.CAlquiler = a.CAlquiler and dp.CParticipante = p.CParticipante", con);
=======
                    var cmd = new SqlCommand("select dp.CDetalleParticipante,dp.CAlquiler,dp.CParticipante,dp.MCuota,dp.FPartePagada,a.CCancha,a.CEquipo, a.DFechaInicio,a.FPagado,a.MDescuento,a.MTotal,a.NumHoras,p.CJugador from DetalleParticipante dp, Alquiler a, Participante p where dp.CAlquiler = a.CAlquiler and dp.CParticipante = p.CParticipante", con);
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
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
                            jugador.CUsuario = Convert.ToInt32(dr["CJugador"]);
                            detalle.CDetalleParticipante = Convert.ToInt32(dr["CDetalleParticipante"]);
                            alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                            participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                            detalle.MCuota = Convert.ToDecimal(dr["MCuota"]);
                            detalle.FPartePagada = Convert.ToBoolean(dr["FPartePagada"]);
                            alquiler.CCancha = cancha;
                            alquiler.CGrupo = grupo;
<<<<<<< HEAD
                            alquiler.DHoraInicio = Convert.ToDateTime(dr["DHoraInicio"]);
=======
                            alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
                            alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                            alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                            alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                            alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                            participante.CJugador = jugador;
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
                var cmd = new SqlCommand("select dp.CDetalleParticipante,dp.CAlquiler,dp.CParticipante,dp.MCuota,dp.FPartePagada,a.CCancha,a.CEquipo, a.DFechaInicio,a.FPagado,a.MDescuento,a.MTotal,a.NumHoras,p.CJugador from DetalleParticipante dp, Alquiler a, Participante p where dp.CDetalleParticipante = '" + id + "' and dp.CAlquiler = a.CAlquiler and dp.CParticipante = p.CParticipante", con);
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
                    jugador.CUsuario = Convert.ToInt32(dr["CJugador"]);
                    detalle.CDetalleParticipante = Convert.ToInt32(dr["CDetalleParticipante"]);
                    alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                    participante.CParticipante = Convert.ToInt32(dr["CParticipante"]);
                    detalle.MCuota = Convert.ToDecimal(dr["MCuota"]);
                    detalle.FPartePagada = Convert.ToBoolean(dr["FPartePagada"]);
                    alquiler.CCancha = cancha;
                    alquiler.CGrupo = grupo;
                    alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
                    alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                    alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                    alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                    alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                    participante.CJugador = jugador;
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
                var cmd = new SqlCommand("insert into DetalleParticipante values(@CAlquiler,@CParticipante,@MCuota,@FPartePagada)");
                cmd.Parameters.AddWithValue("@CAlquiler", t.CAlquiler);
                cmd.Parameters.AddWithValue("@CParticipante", t.CParticipante);
                cmd.Parameters.AddWithValue("@MCuota", t.MCuota);
                cmd.Parameters.AddWithValue("@FPartePagada", t.FPartePagada);
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
                var cmd = new SqlCommand("update DetalleParticipante set CAlquiler=@calquiler,CParticipante=@cparticipante,MCuota=@cuota,FPartePagada=@fpartepagada");
                cmd.Parameters.AddWithValue("calquiler", t.CAlquiler);
                cmd.Parameters.AddWithValue("cparticipante", t.CParticipante);
                cmd.Parameters.AddWithValue("mcuota", t.MCuota);
                cmd.Parameters.AddWithValue("fpartepagada", t.FPartePagada);
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
