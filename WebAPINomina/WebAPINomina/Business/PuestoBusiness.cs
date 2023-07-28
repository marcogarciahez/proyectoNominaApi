using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPINomina.Models;

namespace WebAPINomina.Business
{
    public class PuestoBusiness
    {
        Conexion connect = new Conexion();
        public List<Puesto> ObtenerPuestos()
        {
            List<Puesto> listaPuestos = new List<Puesto>();

            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerPuestos", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaPuestos.Add(new Puesto()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                sueldo_hora = Convert.ToDecimal(dr["sueldo_hora"]),
                                bono_hora = Convert.ToDecimal(dr["bono_hora"])
                            });
                        }
                    }
                    return listaPuestos;
                }
                catch (Exception ex)
                {
                    return listaPuestos;
                }
            }
        }
    }
}