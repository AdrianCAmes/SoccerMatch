﻿using System;
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
    public class PropietarioRepository : IPropietarioRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("delete from Propietario where CPropietario='" + id + "'", con);
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

        public List<Propietario> FindAll()
        {
            List<Propietario> propietarios = new List<Propietario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CPropietario,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono from Propietario p, Usuario u where p.CPropietario = u.CUsuario", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var propietario = new Propietario();
                        propietario.CUsuario = Convert.ToInt32(dr["CPropietario"]);
                        propietario.CDNI = Convert.ToInt64(dr["CDNI"]);
                        propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        propietario.NUsuario = dr["NUsuario"].ToString();
                        propietarios.Add(propietario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propietarios;
        }

        public Propietario FindById(int? id)
        {
            Propietario propietario = new Propietario();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();
                    var cmd = new SqlCommand("select p.CPropietario,u.CUsuario,u.CDNI,u.NUsuario,u.NumTelefono from Propietario p, Usuario u where p.CPropietario = '" + id + "' and p.CPropietario = u.CUsuario", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        propietario = new Propietario();
                        propietario.CUsuario = Convert.ToInt32(dr["CPropietario"]);
                        propietario.CDNI = Convert.ToInt32(dr["CDNI"]);
                        propietario.NumTelefono = Convert.ToInt32(dr["NumTelefono"]);
                        propietario.NUsuario = Convert.ToString(dr["NUsuario"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propietario;
        }

        public bool Insertar(Propietario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString()))
                {
                    con.Open();

                    var cmd = new SqlCommand("insert into Propietario values (@cusuario)", con);
                    cmd.Parameters.AddWithValue("@cusuario", t.CUsuario);
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

        public bool Update(Propietario t)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("update Propietario set CPropietario=@cusuario where CPropietario='"+t.CUsuario+"'",con);
                cmd.Parameters.AddWithValue("@cusuario", t.CUsuario);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
        }
    }
}
