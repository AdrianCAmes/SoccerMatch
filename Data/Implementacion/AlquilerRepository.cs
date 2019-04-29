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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Alquiler where CAlquiler='" + id + "'", con);
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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
<<<<<<< HEAD
                    var cmd = new SqlCommand("select a.CAlquiler, a.DHoraInicio, a.NumHoras, a.MDescuento, a.MTotal, a.FPagado, c.CCancha, c.NCancha, c.TDireccion, c.MPrecioHora, u.CUsuario, u.CDNI, u.NUsuario, u.NumTelefono, e.CEquipo, e.NEquipo, e.TDescripcion, e.NumParticipantes, e.DFechaJuego, e.CDistrito 'CDistritoGrupo', d2.NDistrito 'NDistritoGrupo', ci2.CCiudad 'CCiudadGrupo', ci2.NCiudad'NCiudadGrupo', de2.CDepartamento 'CDepartamentoGrupo', de2.NDepartamento 'NDepartamentoGrupo', cl.CCalle, cl.NCalle, d1.CDistrito 'CDistritoCancha', d1.NDistrito 'NDistritoCancha', ci1.CCiudad 'CCiudadCancha', ci1.NCiudad'NCiudadCancha', de1.CDepartamento 'CDepartamentoCancha', de1.NDepartamento 'NDepartamentoCancha' from Alquiler a, Equipo e, Cancha c, Propietario p, Calle cl, Distrito d1, Distrito d2, Ciudad ci1, Ciudad ci2, Departamento de1, Departamento de2, Usuario u where a.CEquipo = e.CEquipo and a.CCancha = c.CCancha and c.CPropietario = p.CPropietario and u.CUsuario = p.CPropietario and cl.CCalle = c.CCalle and cl.CDistrito = d1.CDistrito and d1.CCiudad = ci1.CCiudad and ci1.CDepartamento = de1.CDepartamento and e.CDistrito = d2.CDistrito and d2.CCiudad = ci2.CCiudad and ci2.CDepartamento = de2.CDepartamento", con);
=======
                    var cmd = new SqlCommand("select a.CAlquiler, a.DFechaInicio, a.NumHoras, a.MDescuento, a.MTotal, a.FPagado, c.CCancha, c.NCancha, c.TDireccion, c.MPrecioHora, u.CUsuario, u.CDNI, u.NUsuario, u.NumTelefono, e.CEquipo, e.NEquipo, e.TDescripcion, e.NumParticipantes, e.DFechaJuego, e.CDistrito 'CDistritoGrupo', d2.NDistrito 'NDistritoGrupo', ci2.CCiudad 'CCiudadGrupo', ci2.NCiudad'NCiudadGrupo', de2.CDepartamento 'CDepartamentoGrupo', de2.NDepartamento 'NDepartamentoGrupo', cl.CCalle, cl.NCalle, d1.CDistrito 'CDistritoCancha', d1.NDistrito 'NDistritoCancha', ci1.CCiudad 'CCiudadCancha', ci1.NCiudad'NCiudadCancha', de1.CDepartamento 'CDepartamentoCancha', de1.NDepartamento 'NDepartamentoCancha' from Alquiler a, Equipo e, Cancha c, Propietario p, Calle cl, Distrito d1, Distrito d2, Ciudad ci1, Ciudad ci2, Departamento de1, Departamento de2, Usuario u where a.CEquipo = e.CEquipo and a.CCancha = c.CCancha and c.CPropietario = p.CPropietario and u.CUsuario = p.CPropietario and cl.CCalle = c.CCalle and cl.CDistrito = d1.CDistrito and d1.CCiudad = ci1.CCiudad and ci1.CDepartamento = de1.CDepartamento and e.CDistrito = d2.CDistrito and d2.CCiudad = ci2.CCiudad and ci2.CDepartamento = de2.CDepartamento", con);
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var alquiler = new Alquiler();
                        var grupo = new Grupo();
                        var cancha = new Cancha();
                        var propietario = new Propietario();
                        var calle = new Calle();
                        var distritoCancha = new Distrito();
                        var distritoGrupo = new Distrito();
                        var ciudadCancha = new Ciudad();
                        var ciudadGrupo = new Ciudad();
                        var departamentoCancha = new Departamento();
                        var departamentoGrupo = new Departamento();

                        departamentoCancha.CDepartamento = Convert.ToInt32(dr["CDepartamentoCancha"]);
                        departamentoCancha.NDepartamento = dr["NDepartamentoCancha"].ToString();

                        ciudadCancha.CCiudad = Convert.ToInt32(dr["CCiudadCancha"]);
                        ciudadCancha.NCiudad = dr["NCiudadCancha"].ToString();
                        ciudadCancha.CDepartamento = departamentoCancha;

                        distritoCancha.CDistrito = Convert.ToInt32(dr["CDistritoCancha"]);
                        distritoCancha.NDistrito = dr["NDistritoCancha"].ToString();
                        distritoCancha.CCiudad = ciudadCancha;

                        calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                        calle.NCalle = dr["NCalle"].ToString();
                        calle.CDistrito = distritoCancha;

                        departamentoGrupo.CDepartamento = Convert.ToInt32(dr["CDepartamentoGrupo"]);
                        departamentoGrupo.NDepartamento = dr["NDepartamentoGrupo"].ToString();

                        ciudadGrupo.CCiudad = Convert.ToInt32(dr["CCiudadGrupo"]);
                        ciudadGrupo.NCiudad = dr["NCiudadGrupo"].ToString();
                        ciudadGrupo.CDepartamento = departamentoGrupo;

                        distritoGrupo.CDistrito = Convert.ToInt32(dr["CDistritoGrupo"]);
                        distritoGrupo.NDistrito = dr["NDistritoGrupo"].ToString();
                        distritoGrupo.CCiudad = ciudadGrupo;

                        grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                        grupo.NGrupo = dr["NEquipo"].ToString();
                        grupo.TDescripcion = dr["TDescripcion"].ToString();
                        grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                        grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                        grupo.CDistrito = distritoGrupo;

                        propietario.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                        propietario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        propietario.NUsuario = dr["NUsuario"].ToString();
                        propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);

                        cancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                        cancha.CPropietario = propietario;
                        cancha.CCalle = calle;
                        cancha.NCancha = dr["NCancha"].ToString();
                        cancha.TDireccion = dr["TDireccion"].ToString();
                        cancha.MPrecioHora = Convert.ToDecimal(dr["MPrecioHora"]);

                        alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                        alquiler.CGrupo = grupo;
                        alquiler.CCancha = cancha;
<<<<<<< HEAD
                        alquiler.DHoraInicio = Convert.ToDateTime(dr["DHoraInicio"]);
=======
                        alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
                        alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                        alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                        alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                        alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);

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
            Alquiler alquiler = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select a.CAlquiler, a.DFechaInicio, a.NumHoras, a.MDescuento, a.MTotal, a.FPagado, c.CCancha, c.NCancha, c.TDireccion, c.MPrecioHora, u.CUsuario, u.CDNI, u.NUsuario, u.NumTelefono, e.CEquipo, e.NEquipo, e.TDescripcion, e.NumParticipantes, e.DFechaJuego, e.CDistrito 'CDistritoGrupo', d2.NDistrito 'NDistritoGrupo', ci2.CCiudad 'CCiudadGrupo', ci2.NCiudad'NCiudadGrupo', de2.CDepartamento 'CDepartamentoGrupo', de2.NDepartamento 'NDepartamentoGrupo', cl.CCalle, cl.NCalle, d1.CDistrito 'CDistritoCancha', d1.NDistrito 'NDistritoCancha', ci1.CCiudad 'CCiudadCancha', ci1.NCiudad'NCiudadCancha', de1.CDepartamento 'CDepartamentoCancha', de1.NDepartamento 'NDepartamentoCancha' from Alquiler a, Equipo e, Cancha c, Propietario p, Calle cl, Distrito d1, Distrito d2, Ciudad ci1, Ciudad ci2, Departamento de1, Departamento de2, Usuario u where a.CAlquiler = '" + id + "' and a.CEquipo = e.CEquipo and a.CCancha = c.CCancha and c.CPropietario = p.CPropietario and u.CUsuario = p.CPropietario and cl.CCalle = c.CCalle and cl.CDistrito = d1.CDistrito and d1.CCiudad = ci1.CCiudad and ci1.CDepartamento = de1.CDepartamento and e.CDistrito = d2.CDistrito and d2.CCiudad = ci2.CCiudad and ci2.CDepartamento = de2.CDepartamento", con);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            alquiler = new Alquiler();
                            var grupo = new Grupo();
                            var cancha = new Cancha();
                            var propietario = new Propietario();
                            var calle = new Calle();
                            var distritoCancha = new Distrito();
                            var distritoGrupo = new Distrito();
                            var ciudadCancha = new Ciudad();
                            var ciudadGrupo = new Ciudad();
                            var departamentoCancha = new Departamento();
                            var departamentoGrupo = new Departamento();

                            departamentoCancha.CDepartamento = Convert.ToInt32(dr["CDepartamentoCancha"]);
                            departamentoCancha.NDepartamento = dr["NDepartamentoCancha"].ToString();

                            ciudadCancha.CCiudad = Convert.ToInt32(dr["CCiudadCancha"]);
                            ciudadCancha.NCiudad = dr["NCiudadCancha"].ToString();
                            ciudadCancha.CDepartamento = departamentoCancha;

                            distritoCancha.CDistrito = Convert.ToInt32(dr["CDistritoCancha"]);
                            distritoCancha.NDistrito = dr["NDistritoCancha"].ToString();
                            distritoCancha.CCiudad = ciudadCancha;

                            calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            calle.NCalle = dr["NCalle"].ToString();
                            calle.CDistrito = distritoCancha;

                            departamentoGrupo.CDepartamento = Convert.ToInt32(dr["CDepartamentoGrupo"]);
                            departamentoGrupo.NDepartamento = dr["NDepartamentoGrupo"].ToString();

                            ciudadGrupo.CCiudad = Convert.ToInt32(dr["CCiudadGrupo"]);
                            ciudadGrupo.NCiudad = dr["NCiudadGrupo"].ToString();
                            ciudadGrupo.CDepartamento = departamentoGrupo;

                            distritoGrupo.CDistrito = Convert.ToInt32(dr["CDistritoGrupo"]);
                            distritoGrupo.NDistrito = dr["NDistritoGrupo"].ToString();
                            distritoGrupo.CCiudad = ciudadGrupo;

                            grupo.CGrupo = Convert.ToInt32(dr["CEquipo"]);
                            grupo.NGrupo = dr["NEquipo"].ToString();
                            grupo.TDescripcion = dr["TDescripcion"].ToString();
                            grupo.NumParticipantes = Convert.ToInt32(dr["NumParticipantes"]);
                            grupo.DFechaJuego = Convert.ToDateTime(dr["DFechaJuego"]);
                            grupo.CDistrito = distritoGrupo;

                            propietario.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                            propietario.CDNI = Convert.ToInt32(dr["CDNI"]);
                            propietario.NUsuario = dr["NUsuario"].ToString();
                            propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);

                            cancha.CCancha = Convert.ToInt32(dr["CCancha"]);
                            cancha.CPropietario = propietario;
                            cancha.CCalle = calle;
                            cancha.NCancha = dr["NCancha"].ToString();
                            cancha.TDireccion = dr["TDireccion"].ToString();
                            cancha.MPrecioHora = Convert.ToDecimal(dr["MPrecioHora"]);

                            alquiler.CAlquiler = Convert.ToInt32(dr["CAlquiler"]);
                            alquiler.CGrupo = grupo;
                            alquiler.CCancha = cancha;
                            alquiler.DHoraInicio = Convert.ToDateTime(dr["DFechaInicio"]);
                            alquiler.NumHoras = Convert.ToInt32(dr["NumHoras"]);
                            alquiler.MDescuento = Convert.ToDecimal(dr["MDescuento"]);
                            alquiler.MTotal = Convert.ToDecimal(dr["MTotal"]);
                            alquiler.FPagado = Convert.ToBoolean(dr["FPagado"]);
                        }
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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
<<<<<<< HEAD
                    var cmd = new SqlCommand("insert into Alquiler values(@CGrupo,@CCancha,@NumHoras,@MDescuento,@MTotal,@FPagado,@DFechaInicio)", con);
=======
                    var cmd = new SqlCommand("insert into Alquiler values(@CGrupo,@CCancha,@DFechaInicio, @NumHoras,@MDescuento,@MTotal,@FPagado)", con);
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
                    cmd.Parameters.AddWithValue("@CGrupo", t.CGrupo.CGrupo);
                    cmd.Parameters.AddWithValue("@CCancha", t.CCancha.CCancha);
                    cmd.Parameters.AddWithValue("@DFechaInicio", t.DHoraInicio);
                    cmd.Parameters.AddWithValue("@NumHoras", t.NumHoras);
                    cmd.Parameters.AddWithValue("@MDescuento", t.MDescuento);
                    cmd.Parameters.AddWithValue("@MTotal", t.MTotal);
                    cmd.Parameters.AddWithValue("@FPagado", t.FPagado);
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
                    var cmd = new SqlCommand("update Alquiler set CGrupo=@cgrupo,CCancha=@ccancha,DFechaInicio = @dfechainicio, NumHoras=@numhoras,MDescuento=@mdescuento,MTotal=@mtotal,FPagado=@fpagado", con);
                    cmd.Parameters.AddWithValue("@cgrupo", t.CGrupo.CGrupo);
                    cmd.Parameters.AddWithValue("@ccancha", t.CCancha.CCancha);
                    cmd.Parameters.AddWithValue("@dfechainicio", t.DHoraInicio);
                    cmd.Parameters.AddWithValue("@numhoras", t.NumHoras);
                    cmd.Parameters.AddWithValue("@mdescuento", t.MDescuento);
                    cmd.Parameters.AddWithValue("@mtotal", t.MTotal);
                    cmd.Parameters.AddWithValue("@fpagado", t.FPagado);
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
