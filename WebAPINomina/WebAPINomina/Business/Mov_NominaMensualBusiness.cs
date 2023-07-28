using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPINomina.Models;

namespace WebAPINomina.Business
{
    public class Mov_NominaMensualBusiness
    {
        Conexion connect = new Conexion();
        public bool CapturaMovimientosPorMes(CapturaMovimientoMensual capturaMovimientoMensual)
        {
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_capturarMovimientos", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_empleado", capturaMovimientoMensual.id_empleado);
                cmd.Parameters.AddWithValue("@fecha", capturaMovimientoMensual.fecha.ToString("yyyy.MM.dd"));
                cmd.Parameters.AddWithValue("@cant_entregas", capturaMovimientoMensual.cant_entregas);
                cmd.Parameters.AddWithValue("@faltas", capturaMovimientoMensual.faltas);

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

        public Mov_NominaMensual ObtenerNomina(int id_empleado, DateTime fecha)
        {
            Mov_NominaMensual mov_NominaMensual = new Mov_NominaMensual();
            using (SqlConnection conexion = new SqlConnection(connect.ruta))
            {
                SqlCommand cmd = new SqlCommand("sp_nominaMensual", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_empleado", id_empleado);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            mov_NominaMensual = new Mov_NominaMensual()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                id_empleado = Convert.ToInt32(dr["id_empleado"]),
                                mes = Convert.ToInt32(dr["mes"]),
                                ano = Convert.ToInt32(dr["ano"]),
                                horas_trabajadas = Convert.ToInt32(dr["horas_trabajadas"]),
                                cant_entregas = Convert.ToInt32(dr["cant_entregas"]),
                                pago_entregas = Convert.ToDecimal(dr["pago_entregas"]),
                                pago_bonos = Convert.ToDecimal(dr["pago_bonos"]),
                                sueldo_horas = Convert.ToDecimal(dr["sueldo_horas"]),
                                sueldo_bruto = Convert.ToDecimal(dr["sueldo_bruto"]),
                                retencion_ISR = Convert.ToDecimal(dr["retencion_ISR"]),
                                saldo_vales = Convert.ToDecimal(dr["saldo_vales"]),
                                sueldo_neto = Convert.ToDecimal(dr["sueldo_neto"])
                            };
                        }
                    }
                    return mov_NominaMensual;
                }
                catch (Exception ex)
                {
                    return mov_NominaMensual;
                }
            }
        }
    }
}