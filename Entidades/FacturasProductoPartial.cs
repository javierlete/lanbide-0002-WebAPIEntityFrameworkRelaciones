namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class FacturasProducto
    {
        public decimal TotalSinIva => Producto != null ? Producto.Precio * Cantidad : 0;
        public decimal Iva => TotalSinIva * Factura.IVA;
        public decimal Total => TotalSinIva + Iva;
    }
}
