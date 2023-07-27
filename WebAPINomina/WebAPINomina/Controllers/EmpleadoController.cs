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

        // GET: api/Empleado/5
        public Empleado Get(int id)
        {
            return new Empleado();
        }

        // POST: api/Empleado
        public bool Post([FromBody]Empleado value)
        {
            return true;
        }

        // PUT: api/Empleado/
        public bool Put([FromBody]Empleado value)
        {
            return true;
        }

        // DELETE: api/Empleado/5
        public bool Delete(int id)
        {
            return true;
        }
    }
}
