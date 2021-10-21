﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityFactura : IDao<Factura>
    {
        #region Singleton
        private DaoEntityFactura() { }
        private static readonly DaoEntityFactura dao = new DaoEntityFactura();
        public static DaoEntityFactura ObtenerInstancia() { return dao; }
        #endregion

        public void Eliminar(long id)
        {
            using(MF0966Model db = new MF0966Model())
            {
                db.Facturas.Remove(db.Facturas.Find(id));
                db.SaveChanges();
            }
        }

        public Factura Insertar(Factura factura)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Facturas.Add(factura);
                db.SaveChanges();

                return factura;
            }
        }

        public Factura Modificar(Factura factura)
        {
            using (MF0966Model db = new MF0966Model())
            {
                db.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return factura;
            }
        }

        public Factura ObtenerPorId(long id)
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Facturas.Include("FacturasProductos").Include("Cliente").Include("FacturasProductos.Producto").FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<Factura> ObtenerTodos()
        {
            using (MF0966Model db = new MF0966Model())
            {
                return db.Facturas.Include("Cliente").ToList();
            }
        }
    }
}
