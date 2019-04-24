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
    public class GrupoRepository : IGrupoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Equipo where CEquipo='" + id + "'");
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public List<Grupo> FindAll()
        {
            throw new NotImplementedException();
        }

        public Grupo FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Grupo t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("insert into Equipo values(@NGrupo,@TDescripcion,@NumParticipantes,@DFechaJuego,@CDistrito)", con);
                cmd.Parameters.AddWithValue("@NGrupo", t.NGrupo);
                cmd.Parameters.AddWithValue("@TDescripcion", t.TDescripcion);
                cmd.Parameters.AddWithValue("@NumParticipantes", t.NumParticipantes);
                cmd.Parameters.AddWithValue("@DFechaJuego", t.DFechaJuego);
                cmd.Parameters.AddWithValue("@CDistrito", t.CDistrito);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return rpta;
        }

        public bool Update(Grupo t)
        {
            throw new NotImplementedException();
        }
    }
}
