﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDaoProducto: IDao<Producto>
    {
        IEnumerable<Producto> ObtenerPorNombreParcial(string nombre);
    }
}
