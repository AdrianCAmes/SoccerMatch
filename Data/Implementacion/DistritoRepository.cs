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
    public class DistritoRepository : IDistritoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Distrito where CDistrito='" + id + "'", con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Distrito> FindAll()
        {
            List<Distrito> lstaDistrito = new List<Distrito>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
            {
                con.Open();
                var query = new SqlCommand("select d.CDistrito, d.NDistrito 'NDistrito',c.NCiudad 'NCiudad' from Distrito d join Ciudad c on c.CCiudad = d.CCiudad", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Distrito objDistrito = new Distrito();
                        Ciudad objCiudad = new Ciudad();
                        
                        objCiudad.NCiudad = dr["NCiudad"].ToString();
                        objDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                        objDistrito.NDistrito = dr["NDistrito"].ToString();
                        objDistrito.CCiudad = objCiudad;
                        lstaDistrito.Add(objDistrito);
                    }
                }

            }
            return lstaDistrito;

        }

        public Distrito FindById(int? id)
        {
            Distrito objDistrito = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select d.CDistrito, d.NDistrito 'NDistrito',c.NCiudad 'NCiudad' from Distrito d join Ciudad c on c.CCiudad = d.CCiudad where d.CDistrito = '" + id + "'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objDistrito = new Distrito();
                            Ciudad objCiudad = new Ciudad();

                            objCiudad.NCiudad = dr["NCiudad"].ToString();
                            objDistrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            objDistrito.NDistrito = dr["NDistrito"].ToString();
                            objDistrito.CCiudad = objCiudad;
                        }
                    }
                }
                return objDistrito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insertar(Distrito t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccerMatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into distrito values (@NDistrito,@CCiudad)", con);

                    query.Parameters.AddWithValue("@NDistrito", t.NDistrito);
                    query.Parameters.AddWithValue("@CCiudad", t.CCiudad.CCiudad);


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

        public bool Update(Distrito t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("update Distrito set NDistrito =@ndistrito, CCiudad =@cciudad where CDistrito =@id", con);
                    query.Parameters.AddWithValue("@id", t.CDistrito);
                    query.Parameters.AddWithValue("@cciudad", t.CCiudad.CCiudad);
                    query.Parameters.AddWithValue("@ndistrito", t.NDistrito);
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
