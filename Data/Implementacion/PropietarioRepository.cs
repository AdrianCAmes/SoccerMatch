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
    public class PropietarioRepository : IParticipanteRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Propietario where id='" + id + "'", con);
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

        public List<Participante> FindAll()
        {
            List<Participante> participantes = new List<Participante>();
            try
            {
                using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select*from ", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var participante = new Participante();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return participantes;
        }

        public Participante FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Participante t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Participante t)
        {
            throw new NotImplementedException();
        }
    }
}
