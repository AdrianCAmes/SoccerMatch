using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace Data.Implementacion
{
    public class CiudadRepository : ICiudadRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    var query = new SqlCommand("delete from Ciudad where CCiudad = '" + id + "'", con);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public List<Ciudad> FindAll()
        {
            var ciudades = new List<Ciudad>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento from Ciudad ci, Departamento de where ci.CDepartamento = de.CDepartamento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                            ciudades.Add(ciudad);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ciudades;
        }

        public Ciudad FindById(int? id)
        {
            Ciudad ciudad = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento from Ciudad ci, Departamento de where ci.CCiudad = '" + id + "' and ci.CDepartamento = de.CDepartamento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ciudad;
        }

        public bool Insertar(Ciudad t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("insert intro Ciudad values (@NCiudad,@CDepartamento)", con);
                    query.Parameters.AddWithValue("@NCiudad", t.NCiudad);
                    query.Parameters.AddWithValue("@CDepartamento", t.CDepartamento.CDepartamento);
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

        public bool Update(Ciudad t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    var query = new SqlCommand("update Ciudad set NCiudad = @nciudad, CDepartamento = @cdepartamento where CCiudad='"+t.CCiudad+"'", con);
                    query.Parameters.AddWithValue("@nciudad", t.NCiudad);
                    query.Parameters.AddWithValue("@cdepartamento", t.CDepartamento.CDepartamento);
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
    }
}
