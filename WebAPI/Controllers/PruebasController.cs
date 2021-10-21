using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PruebasController : ApiController
    {
        public string Get(string nombre = "desconocido", string apellidos = "desconocidez")
        {
            return "Hola " + nombre + " " + apellidos;
        }
    }
}
