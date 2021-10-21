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
    public class FacturasController : ApiController
    {
        private static readonly IDao<Factura> dao = DaoEntityFactura.ObtenerInstancia();
        // GET: api/Facturas
        public IEnumerable<Factura> Get()
        {
            List<Factura> facturas = (List<Factura>)dao.ObtenerTodos();

            facturas.ForEach(f => f.Cliente.Facturas = null);

            return facturas;
        }

        // GET: api/Facturas/5
        public Factura Get(long id)
        {
            return dao.ObtenerPorId(id);
        }
    }
}
