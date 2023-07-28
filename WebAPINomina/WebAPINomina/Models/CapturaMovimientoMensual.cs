using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINomina.Models
{
    public class CapturaMovimientoMensual
    {
        public int id_empleado { get; set;}
        public DateTime fecha { get; set; }
        public int cant_entregas { get; set;}
        public int faltas { get; set;}
    }
}