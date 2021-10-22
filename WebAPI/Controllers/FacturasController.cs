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
        public IHttpActionResult Get(long id)
        {
            Factura factura = dao.ObtenerPorId(id);

            if (factura != null)
            {
                return Ok(factura);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Factura factura)
        {
            Factura f = dao.Insertar(factura);
            return Created(ControllerContext.Request.RequestUri + "/" + f.Id, f);
        }

        public IHttpActionResult Put(long id, [FromBody] Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }
            return Ok(dao.Modificar(factura));
        }

        public IHttpActionResult Delete(long id)
        {
            try
            {
                dao.Eliminar(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
