using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINomina.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public int id_puesto { get; set; }
        public DateTime fecha_nac { get; set; }
    }
}