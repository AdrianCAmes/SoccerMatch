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
            }
            catch (Exception ex)
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
                    var query = new SqlCommand("select c.CCalle,c.CCancha,c.CPropietario,c.MPrecioHora,c.NCancha,c.TDireccion,ca.CDistrito,ca.NCalle from Cancha c, Propietario p, Calle ca where c.CCalle = ca.CCalle and c.CPropietario = p.CPropietario", con);
                    var dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        var cancha = new Cancha();
                        var propietario = new Propietario();
                        var calle = new Calle();
                        cancha.CCancha = Convert.ToInt32(dr["Ccancha"]);
                        propietario.CUsuario = Convert.ToInt32(dr["CPropietario"]);
                        calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                        cancha.NCancha = Convert.ToString(dr["NCancha"]);
                        cancha.TDireccion = Convert.ToString(dr["TDireccion"]);
                        cancha.MPrecioHora = Convert.ToDecimal(dr["MPrecioHora"]);
                        cancha.CPropietario = propietario;
                        cancha.CCalle = calle;
                        canchas.Add(cancha);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return canchas;
        }

        public Cancha FindById(int? id)
        {
            Cancha cancha = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select c.CCalle,c.CCancha,c.CPropietario,c.MPrecioHora,c.NCancha,c.TDireccion,ca.CDistrito,ca.NCalle from Cancha c, Propietario p, Calle ca where c.CCancha = '" + id + "' and c.CCalle = ca.CCalle and c.CPropietario = p.CPropietario", con);
                    var dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        cancha = new Cancha();
                        var propietario = new Propietario();
                        var calle = new Calle();
                        cancha.CCancha = Convert.ToInt32(dr["Ccancha"]);
                        propietario.CUsuario = Convert.ToInt32(dr["CPropietario"]);
                        calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                        cancha.NCancha = Convert.ToString(dr["NCancha"]);
                        cancha.TDireccion = Convert.ToString(dr["TDireccion"]);
                        cancha.MPrecioHora = Convert.ToDecimal(dr["MPrecioHora"]);
                        cancha.CPropietario = propietario;
                        cancha.CCalle = calle;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cancha;
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
                    query.Parameters.AddWithValue("@CPropietario", t.CPropietario.CUsuario);
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

                    var query = new SqlCommand("update Cancha set CPropietario = @cpropietario, CCalle = @ccalle, NCancha = @ncancha, TDireccion = @tdireccion, MPrecioHora = @mpreciohora where CCancha='"+t.CCancha+"'", con);
                    query.Parameters.AddWithValue("@cpropietario", t.CPropietario.CUsuario);
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
