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
    public class Mov_NominaMensualController : ApiController
    {
        Mov_NominaMensualBusiness mov_NominaMensualBusiness = new Mov_NominaMensualBusiness();
        // GET: api/Mov_NominaMensual/int,datetime
        public Mov_NominaMensual Get(int id_empleado, DateTime fecha)
        {
            return mov_NominaMensualBusiness.ObtenerNomina(id_empleado, fecha);
        }

        // POST: api/Mov_NominaMensual
        public bool Post([FromBody]CapturaMovimientoMensual capturaMovimientoMensual)
        {
            return mov_NominaMensualBusiness.CapturaMovimientosPorMes(capturaMovimientoMensual);
        }

    }
}
