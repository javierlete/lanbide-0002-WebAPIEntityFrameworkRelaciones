using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Producto
    {
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Precio}, {Categoria.Id}, {Categoria.Nombre}";
        }
    }
}
