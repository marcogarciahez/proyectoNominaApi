using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINomina.Models
{
    public class Puesto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal sueldo_hora { get; set; }
        public decimal bono_hora { get; set; }
    }
}