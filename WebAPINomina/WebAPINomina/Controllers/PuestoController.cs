using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPINomina.Business;
using WebAPINomina.Models;

namespace WebAPINomina.Controllers
{
    public class PuestoController : ApiController
    {
        public PuestoBusiness puestoBusiness = new PuestoBusiness();
        public List<Puesto> Get()
        {
            return puestoBusiness.ObtenerPuestos();
        }
    }
}
