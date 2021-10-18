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
    public class ProductosController : ApiController
    {
        private static readonly IDaoProducto dao = DaoEntityProducto.ObtenerInstancia();

        // GET: api/Productos
        public IEnumerable<Producto> Get()
        {
            IEnumerable<Producto> productos;

            productos = dao.ObtenerTodos();

            foreach (Producto p in productos)
            {
                p.Categoria.Productos = null;
            }

            return productos;
        }

        public IEnumerable<Producto> Get(string nombre)
        {
            IEnumerable<Producto> productos;

            productos = dao.ObtenerPorNombreParcial(nombre);
            
            foreach (Producto p in productos)
            {
                p.Categoria.Productos = null;
            }

            return productos;
            //return new List<Producto>() { new Producto() { Nombre = nombre } };
        }

        // GET: api/Productos/5
        public Producto Get(long id)
        {
            return dao.ObtenerPorId(id);
        }

        // POST: api/Productos
        public Producto Post([FromBody] Producto producto)
        {
            return dao.Insertar(producto);
        }

        // PUT: api/Productos/5
        public Producto Put(long id, [FromBody] Producto producto)
        {
            return dao.Modificar(producto);
        }

        // DELETE: api/Productos/5
        public void Delete(long id)
        {
            dao.Eliminar(id);
        }
    }
}
