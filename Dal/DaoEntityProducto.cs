using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityProducto : IDao<Producto>
    {
        #region Singleton
        private DaoEntityProducto() { }
        private static readonly DaoEntityProducto dao = new DaoEntityProducto();
        public static DaoEntityProducto ObtenerInstancia() { return dao; }
        #endregion

        public void Eliminar(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Productos.Remove(db.Productos.Find(id));
                db.SaveChanges();
            }
        }

        public Producto Insertar(Producto producto)
        {
            using (MF0966Model db = new MF0966Model())
            {
                if (producto.Categoria != null)
                {
                    producto.CategoriaId = producto.Categoria.Id;
                    db.Entry(producto.Categoria).State = System.Data.Entity.EntityState.Unchanged;
                }
                db.Productos.Add(producto);
                db.SaveChanges();

                return producto;
            }
        }

        public Producto Modificar(Producto producto)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return producto;
            }
        }

        public Producto ObtenerPorId(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Productos.Include("Categoria").FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Productos.Include("Categoria").ToList();
            }
        }
    }
}
