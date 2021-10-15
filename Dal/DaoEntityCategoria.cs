using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityCategoria : IDao<Categoria>
    {
        #region Singleton
        private DaoEntityCategoria() { }
        private static readonly DaoEntityCategoria dao = new DaoEntityCategoria();
        public static DaoEntityCategoria ObtenerInstancia() { return dao; }
        #endregion

        public void Eliminar(long id)
        {
            using(MF0966Model db = new MF0966Model())
            {
                db.Categorias.Remove(ObtenerPorId(id));
                db.SaveChanges();
            }
        }

        public Categoria Insertar(Categoria categoria)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();

                return categoria;
            }
        }

        public Categoria Modificar(Categoria categoria)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return categoria;
            }
        }

        public Categoria ObtenerPorId(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Categorias.Find(id);
            }
        }

        public IEnumerable<Categoria> ObtenerTodos()
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Categorias.ToList();
            }
        }
    }
}
