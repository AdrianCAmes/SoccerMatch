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
    public class CanchaRepository : ICanchaRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("delete from Cancha where CCancha = '" + id + "'", con);
                    query.ExecuteNonQuery();

                    rpta = true;
                }
            } catch (Exception ex)
            {
                throw;
            }

            return rpta;
        }

        public List<Cancha> FindAll()
        {
            throw new NotImplementedException();
        }

        public Cancha FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Cancha t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cancha t)
        {
            throw new NotImplementedException();
        }
    }
}
