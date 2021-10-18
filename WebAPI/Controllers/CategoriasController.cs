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
    public class CategoriasController : ApiController
    {
        private static readonly IDao<Categoria> dao = DaoEntityCategoria.ObtenerInstancia();

        // GET: api/Categorias
        public IEnumerable<Categoria> Get()
        {
            return dao.ObtenerTodos();
        }

        // GET: api/Categorias/5
        public IHttpActionResult Get(long id)
        {
            Categoria categoria = dao.ObtenerPorId(id); 

            if(categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // POST: api/Categorias
        public Categoria Post([FromBody] Categoria categoria)
        {
            return dao.Insertar(categoria);
        }

        // PUT: api/Categorias/5
        public Categoria Put(long id, [FromBody] Categoria categoria)
        {
            return dao.Modificar(categoria);
        }

        // DELETE: api/Categorias/5
        public void Delete(long id)
        {
            dao.Eliminar(id);
        }
    }
}
