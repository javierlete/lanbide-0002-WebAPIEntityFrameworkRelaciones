using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private static readonly IDaoCliente dao = DaoEntityCliente.ObtenerInstancia();
        public Cliente Get(long id)
        {
            return dao.ObtenerPorId(id);
        }
    }
}
