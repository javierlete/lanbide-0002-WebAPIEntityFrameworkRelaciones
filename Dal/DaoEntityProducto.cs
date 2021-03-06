using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityProducto : IDaoProducto
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
                
                db.Entry(producto).Reference(p => p.Categoria).Load();

                db.SaveChanges();

                return producto;
            }
        }

        public IEnumerable<Producto> ObtenerPorNombreParcial(string nombre)
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Productos.Include("Categoria").Where(p => p.Nombre.Contains(nombre)).ToList();
            }
        }

        public Producto Modificar(Producto producto)
        {
            using (MF0966Model db = new MF0966Model())
            {
                if (producto.CategoriaId != producto.Categoria?.Id)
                {
                    producto.Categoria = db.Categorias.Find(producto.CategoriaId);
                }
                
                db.Entry(producto.Categoria).State = System.Data.Entity.EntityState.Unchanged;

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
