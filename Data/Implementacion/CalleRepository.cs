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
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Calle where id='" + id + "'", con);
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

        public List<Calle> FindAll()
        {
            throw new NotImplementedException();
        }

        public Calle FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Calle t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
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
                    var cmd = new SqlCommand("update Calle set NCalle=@ncalle,CDistrito=@cdistrito)");
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
