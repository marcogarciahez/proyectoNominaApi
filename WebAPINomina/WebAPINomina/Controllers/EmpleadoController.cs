using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPINomina.Business;
using WebAPINomina.Models;

namespace WebAPINomina.Controllers
{
    public class EmpleadoController : ApiController
    {

        public EmpleadoBusiness empleadoBusiness = new EmpleadoBusiness();
        // GET: api/Empleado
        public List<Empleado> Get()
        {
            return empleadoBusiness.ObtenerEmpleados();
        }

        // GET: api/Empleado/id
        public Empleado Get(int id)
        {
            return empleadoBusiness.ObtenerEmpleado(id);
        }

        // POST: api/Empleado
        public bool Post([FromBody]Empleado empleado)
        {
            return empleadoBusiness.IngresarEmpleado(empleado);
        }

        // PUT: api/Empleado/
        public bool Put([FromBody]Empleado empleado)
        {
            return empleadoBusiness.ActualizarEmpleado(empleado);
        }

        // DELETE: api/Empleado/id
        public bool Delete(int id)
        {
            return empleadoBusiness.EliminarEmpleado(id);
        }
    }
}
