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
            var canchas = new List<Cancha>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("", con);
                    var dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                    }
                }
            } catch(Exception ex)
            {
                throw;
            }

            return canchas;
        }

        public Cancha FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Cancha t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into Cancha values (@CPropietario, @CCalle, @NCancha, @TDireccion, @MPrecioHora)", con);
                    query.Parameters.AddWithValue("@CPropietario", t.CPropietario.NUsuario);
                    query.Parameters.AddWithValue("@CCalle", t.CCalle.CCalle);
                    query.Parameters.AddWithValue("@NCancha", t.NCancha);
                    query.Parameters.AddWithValue("@TDireccion", t.TDireccion);
                    query.Parameters.AddWithValue("@MPrecioHora", t.MPrecioHora);
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

        public bool Update(Cancha t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Cancha set CPropietario = @cpropietario, CCalle = @ccalle, NCancha = @ncancha, TDireccion = @tdireccion, MPrecioHora = @mpreciohora)", con);
                    query.Parameters.AddWithValue("@cpropietario", t.CPropietario.NUsuario);
                    query.Parameters.AddWithValue("@ccalle", t.CCalle.CCalle);
                    query.Parameters.AddWithValue("@ncancha", t.NCancha);
                    query.Parameters.AddWithValue("@tdireccion", t.TDireccion);
                    query.Parameters.AddWithValue("@mpreciohora", t.MPrecioHora);
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
