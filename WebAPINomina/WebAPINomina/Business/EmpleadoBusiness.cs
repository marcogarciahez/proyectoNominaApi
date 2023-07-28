using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPINomina.Models;

namespace WebAPINomina.Business
{
    public class EmpleadoBusiness
    {
        Conexion connect = new Conexion();
        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerEmpleados", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaEmpleados.Add(new Empleado()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                apellido_pat = dr["apellido_pat"].ToString(),
                                apellido_mat = dr["apellido_mat"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                domicilio = dr["domicilio"].ToString(),
                                id_puesto = Convert.ToInt32(dr["id_puesto"]),
                                nombre_puesto = dr["nombre_puesto"].ToString(),
                                fecha_nac = Convert.ToDateTime(dr["fecha_nac"])
                            });
                        }
                    }
                    return listaEmpleados;
                }
                catch (Exception ex)
                {
                    return listaEmpleados;
                }
            }
        }

        public Empleado ObtenerEmpleado(int id)
        {
            Empleado empleado = new Empleado();
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerEmpleado", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                             empleado = new Empleado()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                apellido_pat = dr["apellido_pat"].ToString(),
                                apellido_mat = dr["apellido_mat"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                domicilio = dr["domicilio"].ToString(),
                                id_puesto = Convert.ToInt32(dr["id_puesto"]),
                                fecha_nac = Convert.ToDateTime(dr["fecha_nac"])
                            };
                        }
                    }
                    return empleado;
                }
                catch (Exception ex)
                {
                    return empleado;
                }
            }
        }

        public Empleado ObtenerEmpleadoFiltro(string nombre)
        {
            Empleado empleado = new Empleado();
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerEmpleadosFiltro", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            empleado = new Empleado()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                apellido_pat = dr["apellido_pat"].ToString(),
                                apellido_mat = dr["apellido_mat"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                domicilio = dr["domicilio"].ToString(),
                                id_puesto = Convert.ToInt32(dr["id_puesto"]),
                                fecha_nac = Convert.ToDateTime(dr["fecha_nac"])
                            };
                        }
                    }
                    return empleado;
                }
                catch (Exception ex)
                {
                    return empleado;
                }
            }
        }

        public bool IngresarEmpleado(Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_ingresarEmpleado", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@apellido_pat", empleado.apellido_pat);
                cmd.Parameters.AddWithValue("@apellido_mat", empleado.apellido_mat);
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@telefono", empleado.telefono);
                cmd.Parameters.AddWithValue("@domicilio", empleado.domicilio);
                cmd.Parameters.AddWithValue("@id_puesto", empleado.id_puesto);
                cmd.Parameters.AddWithValue("@fecha_nac", empleado.fecha_nac.ToString("yyyy.MM.dd"));

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool ActualizarEmpleado(Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_actualizarEmpleado", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", empleado.id);
                cmd.Parameters.AddWithValue("@apellido_pat", empleado.apellido_pat);
                cmd.Parameters.AddWithValue("@apellido_mat", empleado.apellido_mat);
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@telefono", empleado.telefono);
                cmd.Parameters.AddWithValue("@domicilio", empleado.domicilio);
                cmd.Parameters.AddWithValue("@id_puesto", empleado.id_puesto);
                cmd.Parameters.AddWithValue("@fecha_nac", empleado.fecha_nac.ToString("yyyy.MM.dd"));

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool EliminarEmpleado(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_eliminarEmpleado", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}