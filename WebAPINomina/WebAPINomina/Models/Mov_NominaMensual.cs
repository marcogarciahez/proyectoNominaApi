using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINomina.Models
{
    public class Mov_NominaMensual
    {
        public int id { get; set; }
        public int id_empleado { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int horas_trabajadas { get; set; }
        public int cant_entregas { get; set; }
        public decimal pago_entregas { get; set; }
        public decimal pago_bonos { get; set; }
        public decimal sueldo_horas { get; set; }
        public decimal sueldo_bruto { get; set; }
        public decimal retencion_ISR { get; set; }
        public decimal saldo_vales { get; set; }
        public decimal sueldo_neto { get; set; }
    }
}