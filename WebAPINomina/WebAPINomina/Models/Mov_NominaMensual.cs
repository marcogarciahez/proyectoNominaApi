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
        public int cant_movimientos { get; set; }
        public int faltas { get; set; }
        public decimal sueldo_bruto { get; set; }
        public decimal retencion_ISR { get; set; }
        public decimal saldo_vales { get; set; }
        public decimal sueldo_neto { get; set; }
    }
}