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
    public class CalleRepository : ICalleRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Calle where CCalle='" + id + "'", con);
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

        public List<Calle> FindAll()
        {
            var calles = new List<Calle>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.CCalle, c.NCalle, d.CDistrito, d.NDistrito, ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento from Calle c, Distrito d, Ciudad ci, Departamento de where c.CDistrito = d.CDistrito and d.CCiudad = ci.CCiudad and ci.CDepartamento = de.CDepartamento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var calle = new Calle();
                            var distrito = new Distrito();
                            var ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            distrito.CCiudad = ciudad;

                            calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            calle.NCalle = dr["NCalle"].ToString();
                            calle.CDistrito = distrito;

                            calles.Add(calle);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return calles;
        }

        public Calle FindById(int? id)
        {
            Calle calle = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select c.CCalle, c.NCalle, d.CDistrito, d.NDistrito, ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento from Calle c, Distrito d, Ciudad ci, Departamento de where c.CCalle = '" + id + "' and c.CDistrito = d.CDistrito and d.CCiudad = ci.CCiudad and ci.CDepartamento = de.CDepartamento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            calle = new Calle();
                            var distrito = new Distrito();
                            var ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            distrito.CCiudad = ciudad;

                            calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            calle.NCalle = dr["NCalle"].ToString();
                            calle.CDistrito = distrito;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return calle;
        }

        public bool Insertar(Calle t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Calle values(@NCalle,@CDistrito)");
                    cmd.Parameters.AddWithValue("@NCalle", t.NCalle);
                    cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito.CDistrito);
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

        public bool Update(Calle t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Calle set NCalle=@ncalle,CDistrito=@cdistrito where CCalle='"+t.CCalle+"'",con);
                    cmd.Parameters.AddWithValue("@ncalle", t.NCalle);
                    cmd.Parameters.AddWithValue("@cdistrito", t.CDistrito.CDistrito);
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
