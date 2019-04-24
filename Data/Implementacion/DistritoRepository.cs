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
    public class DistritoRepository : IDistritoRepository
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["soccermatch"].ToString());
                con.Open();
                var cmd = new SqlCommand("delete from Distrito where CDistrito='" + id + "'", con);
                cmd.ExecuteNonQuery();
                rpta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rpta;
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
            Distrito distrito_temp= null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerMatch"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select d.CDistrito,d.NDistrito,d.CCiudad from distrito d where d.CDistrito=2", con);
                    using (var dr = query.ExecuteReader())
                    {
                        Ciudad objCiudad = new Ciudad();
                        query.Parameters.AddWithValue("@id", id);
                        distrito_temp = new Distrito();
                        distrito_temp.CDistrito = Convert.ToInt32(dr["CDistrito"]);
                        distrito_temp.NDistrito = dr["NDistrito"].ToString();

                        objCiudad.CCiudad = Convert.ToInt32(dr["CCiudad"]);
                        distrito_temp.CCiudad = objCiudad;
                    }
                }
                return distrito_temp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insertar(Distrito t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["university"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("insert into distrito values (@NDistrito,@CCiudad)", con);

                    query.Parameters.AddWithValue("@name", t.Name);
                    query.Parameters.AddWithValue("@email", t.Email);
                    query.Parameters.AddWithValue("@contactno", t.ContactNo);
                    query.Parameters.AddWithValue("@date", t.Date);
                    query.Parameters.AddWithValue("@address", t.Address);
                    query.Parameters.AddWithValue("@departmentid", t.DepartmentCode.Id);

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

        public bool Update(Distrito t)
        {
            throw new NotImplementedException();
        }
    }
}
