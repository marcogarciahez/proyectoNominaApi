using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPINomina.Models;

namespace WebAPINomina.Controllers
{
    public class Mov_NominaMensualController : ApiController
    {

        // GET: api/Mov_NominaMensual/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mov_NominaMensual
        public void Post([FromBody]Mov_NominaMensual mov_nominaMensual)
        {
            
        }

    }
}
