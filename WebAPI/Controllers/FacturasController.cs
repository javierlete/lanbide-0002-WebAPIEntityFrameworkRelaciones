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
            return dao.ObtenerTodos();
        }

        // GET: api/Facturas/5
        public Factura Get(long id)
        {
            return dao.ObtenerPorId(id);
        }

        public Factura Post([FromBody] Factura factura)
        {
            return dao.Insertar(factura);
        }

        public Factura Put(long id, [FromBody] Factura factura)
        {
            return dao.Modificar(factura);
        }

        public void Delete(long id)
        {
            dao.Eliminar(id);
        }
    }
}
