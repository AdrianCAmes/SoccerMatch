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
            throw new NotImplementedException();
        }

        public List<Distrito> FindAll()
        {
            List<Distrito> lstaDistrito = new List<Distrito>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
            {
                con.Open();
                var query = new SqlCommand("select d.NDistrito 'NDistrito',c.NCiudad 'NCiudad' from Distrito d join Ciudad c on c.CCiudad = d.CCiudad", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Distrito objDistrito = new Distrito();
                        Ciudad objCiudad = new Ciudad();

                        objCiudad.NCiudad = dr["NCiudad"].ToString();
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
            throw new NotImplementedException();
        }

        public bool Insertar(Distrito t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Distrito t)
        {
            throw new NotImplementedException();
        }
    }
}
