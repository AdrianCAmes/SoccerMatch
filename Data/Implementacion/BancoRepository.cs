using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Data.Implementacion
{
    public class BancoRepository : IBancoRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Banco> FindAll()
        {
            var lst_banco = new List<Banco>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TP"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select* from Banco",con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var banco = new Banco();
                            banco.CBanco = Convert.ToInt32(dr["CBanco"]);
                            banco.NBanco = dr["NBanco"].ToString();
                            lst_banco.Add(banco);

                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
            return lst_banco;
        }

        public Banco FindById(int? id)
        {
            Banco banco_aux = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TP"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from banco b where b.id='" + id + "'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            banco_aux = new Banco();
                            banco_aux.CBanco = Convert.ToInt32(dr["CBanco"]);
                            banco_aux.NBanco = dr["NBanco"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return banco_aux;
        }

        public bool Insertar(Banco t)
        {
            bool rpt = false;
            try{
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TP"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("insert into Banco values(@nombre,@codigo)", con);
                    query.Parameters.AddWithValue("@nombre", t.NBanco);
                    query.Parameters.AddWithValue("@codigo", t.CBanco);
                    query.ExecuteNonQuery();
                    rpt = true;
                }
            }catch(Exception)
            {
                throw;
            }
            return rpt;
        }

        public bool Update(Banco t)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TP"].ToString()))
                {
                    con.Open();
                    var query=new SqlCommand("update Banco set NBanco=@nombre where CBanco=@codigo");
                    query.Parameters.AddWithValue("@nombre", t.NBanco);
                    query.Parameters.AddWithValue("@codigo", t.CBanco);
                    query.ExecuteNonQuery();
                    rpta = true;
                }

            }
            catch(Exception)
            {
                throw;
            }
            return rpta;
        }
    }
}
