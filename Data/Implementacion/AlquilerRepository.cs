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
    public class AlquilerRepository : IAlquilerRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Alquiler where CAlquiler='" + id + "'",con);
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

        public List<Alquiler> FindAll()
        {
            List<Alquiler> alquileres = new List<Alquiler>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from Alquiler ",con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Alquiler alquiler = new Alquiler();
                        Grupo grupo = new Grupo();
                        Cancha cancha = new Cancha();


                        alquiler.CGrupo.CGrupo = Convert.ToInt32(dr["CGrupo"]);
                        alquiler.CCancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                        alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                        alquiler.MDescuento = Convert.ToInt32(dr["MDescuento"]);
                        alquiler.MTotal = Convert.ToInt32(dr["MTotal"]);
                        alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                        alquiler.CHorario.CHorario = Convert.ToInt32(dr["CHorario"]);
                        alquileres.Add(alquiler);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alquileres;
        }

        public Alquiler FindById(int? id)
        {
            Alquiler alquiler = new Alquiler(); 
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from Alquiler where id='"+id+"'",con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        alquiler.CGrupo.CGrupo = Convert.ToInt32(dr["CGrupo"]);
                        alquiler.CCancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                        alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                        alquiler.MDescuento = Convert.ToInt32(dr["MDescuento"]);
                        alquiler.MTotal = Convert.ToInt32(dr["MTotal"]);
                        alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                        alquiler.CHorario.CHorario = Convert.ToInt32(dr["CHorario"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alquiler;
        }

        public bool Insertar(Alquiler t)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("insert into Alquiler values(@CGrupo,@CCancha,@NumHoras,@MDescuento,@MTotal,@FPagado,@CHorario)",con);
                    cmd.Parameters.AddWithValue("@CGrupo", t.CGrupo.CGrupo);
                    cmd.Parameters.AddWithValue("@CCancha", t.CCancha.CCancha);
                    cmd.Parameters.AddWithValue("@NumHoras", t.NumHoras);
                    cmd.Parameters.AddWithValue("@MDescuento", t.MDescuento);
                    cmd.Parameters.AddWithValue("@MTotal", t.MTotal);
                    cmd.Parameters.AddWithValue("@FPagado", t.FPagado);
                    cmd.Parameters.AddWithValue("@CHorario", t.CHorario.CHorario);
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

        public bool Update(Alquiler t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("update Alquiler set CGrupo=@cgrupo,CCancha=@ccancha,NumHoras=@numhoras,MDescuento=@mdescuento,MTotal=@mtotal,FPagado=@fpagado,CHorario=@chorario",con);
                    cmd.Parameters.AddWithValue("@cgrupo", t.CGrupo.CGrupo);
                    cmd.Parameters.AddWithValue("@ccancha", t.CCancha.CCancha);
                    cmd.Parameters.AddWithValue("@numhoras", t.NumHoras);
                    cmd.Parameters.AddWithValue("@mdescuento", t.MDescuento);
                    cmd.Parameters.AddWithValue("@mtotal", t.MTotal);
                    cmd.Parameters.AddWithValue("@fpagado", t.FPagado);
                    cmd.Parameters.AddWithValue("@chorario", t.CHorario.CHorario);
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
    }
}
