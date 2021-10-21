namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Factura
    {
        public const decimal IVA = 0.21m;

        public decimal TotalSinIva => FacturasProductos.Sum(fp => fp.TotalSinIva);
        public decimal Iva => TotalSinIva * IVA;
        public decimal Total => TotalSinIva + Iva;
    }
}
