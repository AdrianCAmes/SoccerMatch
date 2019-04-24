﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementacion
{
    public class AdministradorRepository : IAdministradorRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString())) {
                    con.Open();
                    var cmd = new SqlCommand("delete from Administrador where id='" + id + "'", con);
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex){
                throw ex;
            }
            return rpta;
        }

        public List<Administrador> FindAll()
        {
            var administradores = new List<Administrador>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("a.CAdministrador, u.NUsuario, u.CDNI, u.NumTelefono, j.TDireccion, c.CCalle, c.NCalle," +
                                                "d.CDistrito, d.NDistrito, ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento" +
                                                "from Administrador a, Jugador j, Usuario u, Calle c, Distrito d, Ciudad ci, Departamento de" +
                                                "where a.CAdministrador = j.CJugador and j.CJugador = u.CUsuario and c.CCalle = j.CCalle and" +
                                                "c.CDistrito = d.CDistrito and d.CCiudad = ci.CCiudad and ci.CDepartamento = de.CDepartamento", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var administrador = new Administrador();
                            var calle = new Calle();
                            var distrito = new Distrito();
                            var ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            distrito.CCiudad = ciudad;

                            calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            calle.NCalle = dr["NCalle"].ToString();
                            calle.CDistrito = distrito;

                            administrador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                            administrador.TDireccion = dr["TDireccion"].ToString();
                            administrador.CDNI = Convert.ToInt32(dr["DNI"]);
                            administrador.NUsuario = dr["NUsuario"].ToString();
                            administrador.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                            administrador.CCalle = calle;

                            administradores.Add(administrador);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return administradores;
        }

        public Administrador FindById(int? id)
        {
            Administrador administrador = null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    var query = new SqlCommand("a.CAdministrador, u.NUsuario, u.CDNI, u.NumTelefono, j.TDireccion, c.CCalle," + 
                                                "c.NCalle,  d.CDistrito, d.NDistrito, ci.CCiudad, ci.NCiudad, de.CDepartamento, de.NDepartamento" +
                                                "from Administrador a, Jugador j, Usuario u, Calle c, Distrito d, Ciudad ci, Departamento de" +
                                                "where a.CAdministrador = '" + id + "' and j.CJugador ='" + id + "' and u.CUsuario '" + id + "' and" +
                                                "c.CCalle = j.CCalle and c.CDistrito = d.CDistrito and d.CCiudad = ci.CCiudad and ci.CDepartamento = de.CDepartamento", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            administrador = new Administrador();
                            var calle = new Calle();
                            var distrito = new Distrito();
                            var ciudad = new Ciudad();
                            var departamento = new Departamento();

                            departamento.CDepartamento = Convert.ToInt32(dr["CDepartamento"]);
                            departamento.NDepartamento = dr["NDepartamento"].ToString();

                            ciudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                            ciudad.NCiudad = dr["NCiudad"].ToString();
                            ciudad.CDepartamento = departamento;

                            distrito.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                            distrito.NDistrito = dr["NDistrito"].ToString();
                            distrito.CCiudad = ciudad;

                            calle.CCalle = Convert.ToInt32(dr["CCalle"]);
                            calle.NCalle = dr["NCalle"].ToString();
                            calle.CDistrito = distrito;

                            administrador.CUsuario = Convert.ToInt32(dr["CUsuario"]);
                            administrador.TDireccion = dr["TDireccion"].ToString();
                            administrador.CDNI = Convert.ToInt32(dr["DNI"]);
                            administrador.NUsuario = dr["NUsuario"].ToString();
                            administrador.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                            administrador.CCalle = calle;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return administrador;
        }

        public bool Insertar(Administrador t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("insert into Administrador values (@CAdministrador)", con);

                    query.Parameters.AddWithValue("@CAdministrador", t.CUsuario);
                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return rpta;
        }

        public bool Update(Administrador t)
        {
            bool rpta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("update Administrador set CAdministrador=@id ");
                    query.Parameters.AddWithValue("@id", t.CUsuario);                
                    rpta = true;
                }
            } catch (Exception ex )
            {
                throw ex;
            }

            return rpta;
        }
    } 
}