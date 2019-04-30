using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementacion
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete from Departamento where CDepartamento = '" + id + "'", con);
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

        public List<Departamento> FindAll()
        {
            var departamentos = new List<Departamento>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select de.CDepartamento, de.NDepartamento from Departamento de", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            departamentos.Add(departamento);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return departamentos;
        }

        public Departamento FindById(int? id)
        {
            Departamento departamento = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select de.CDepartamento, de.NDepartamento from Departamento de where de.CDepartamento = '" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return departamento;
        }

        public bool Insertar(Departamento t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("insert into Departamento values (@NDepartamento)", con);
                    query.Parameters.AddWithValue("@NDepartamento", t.NDepartamento);
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

        public bool Update(Departamento t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("update Departamento set NDepartamento = @ndepartamento where CDepartamento='"+t.CDepartamento+"'", con);
                    query.Parameters.AddWithValue("@ndepartamento", t.NDepartamento);
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
