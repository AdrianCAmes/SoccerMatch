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
    public class GrupoRepository : IGrupoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Equipo where CEquipo='" + id + "'",con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Grupo> FindAll()
        {
            List<Grupo> grupos = new List<Grupo>();
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("select e.CEquipo,e.NEquipo,e.TDescripcion,e.NumParticipantes,e.DFechaJuego,e.CDistrito,d.CCiudad,d.NDistrito from Equipo e, Distrito d where e.CDistrito = d.CDistrito", con);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var grupo = new Grupo();
                        var distrito = new Distrito();
                        var ciudad = new Ciudad();
                        grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                        grupo.NGrupo = Convert.ToString(dr["NEquipo"]);
                        grupo.TDescripcion = Convert.ToString(dr["TDescripcion"]);
                        grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                        grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                        distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                        ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                        distrito.CCiudad = ciudad;
                        distrito.NDistrito = Convert.ToString(dr["NDistrito"]);
                        grupo.CDistrito = distrito;
                        grupos.Add(grupo);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupos;
        }

        public Grupo FindById(int? id)
        {
            Grupo grupo = new Grupo();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select e.CEquipo,e.NEquipo,e.TDescripcion,e.NumParticipantes,e.DFechaJuego,e.CDistrito,d.CCiudad,d.NDistrito from Equipo e, Distrito d where e.CEquipo = '" + id + "' and e.CDistrito = d.CDistrito", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            grupo = new Grupo();
                            var distrito = new Distrito();
                            var ciudad = new Ciudad();
                            grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                            grupo.NGrupo = Convert.ToString(dr["NEquipo"]);
                            grupo.TDescripcion = Convert.ToString(dr["TDescripcion"]);
                            grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                            grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            distrito.CCiudad = ciudad;
                            distrito.NDistrito = Convert.ToString(dr["NDistrito"]);
                            grupo.CDistrito = distrito;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupo;
        }

        public bool Insertar(Grupo t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("insert into Equipo values(@NGrupo,@TDescripcion,@NumParticipantes,@DFechaJuego,@CDistrito)", con);
                cmd.Parameters.AddWithValue("@NGrupo", t.NGrupo);
                cmd.Parameters.AddWithValue("@TDescripcion", t.TDescripcion);
                cmd.Parameters.AddWithValue("@NumParticipantes", t.NumParticipantes);
                cmd.Parameters.AddWithValue("@DFechaJuego", t.DFechaJuego);
                cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito.CDistrito);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(Grupo t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("update Equipo set NEquipo=@ngrupo,TDescripcion=@tdescripcion,NumParticipantes=@numparticipantes,DFechaJuego=@dfechajuego,CDistrito=@cdistrito where CEquipo='"+t.CGrupo+"'", con);
                cmd.Parameters.AddWithValue("@ngrupo", t.NGrupo);
                cmd.Parameters.AddWithValue("@tdescripcion", t.TDescripcion);
                cmd.Parameters.AddWithValue("@numparticipantes", t.NumParticipantes);
                cmd.Parameters.AddWithValue("@dfechajuego", t.DFechaJuego);
                cmd.Parameters.AddWithValue("@cdistrito", t.CDistrito.CDistrito);
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
