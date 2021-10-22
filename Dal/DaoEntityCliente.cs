using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityCliente : IDaoCliente
    {
        #region Singleton
        private DaoEntityCliente() { }
        private static readonly DaoEntityCliente dao = new DaoEntityCliente();
        public static DaoEntityCliente ObtenerInstancia() { return dao; }
        #endregion

        public void Eliminar(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Clientes.Remove(db.Clientes.Find(id));
                db.SaveChanges();
            }
        }

        public Cliente Insertar(Cliente cliente)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();

                return cliente;
            }
        }

        public Cliente Modificar(Cliente cliente)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return cliente;
            }
        }

        public Cliente ObtenerPorId(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Clientes.Include("Facturas").FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<Cliente> ObtenerTodos()
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Clientes.ToList();
            }
        }
    }
}
