using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            MF0966Model db = new MF0966Model();

            // Contraejemplo de pedir productos sin pedir explícitamente las categorías incluídas
            foreach(var p in db.Productos)
            {
                Console.Write(p.Nombre);
                Console.Write(" -> ");
                Console.WriteLine(p.Categoria.Nombre);
            }

            IDao<Producto> dao = DaoEntityProducto.ObtenerInstancia();
            IDao<Categoria> daoCategoria = DaoEntityCategoria.ObtenerInstancia();

            foreach (var p in dao.ObtenerTodos())
            {
                Console.Write(p.Nombre);
                Console.Write(" -> ");
                Console.WriteLine(p.Categoria.Nombre);
            }

            var producto = dao.ObtenerPorId(1L);

            Console.Write(producto.Nombre);
            Console.Write(" -> ");
            Console.WriteLine(producto.Categoria.Nombre);

            Producto p1 = new Producto()
            {
                Nombre = "Nuevo Por Dao",
                Precio = 123.45m,
                CategoriaId = 2
            };

            dao.Insertar(p1);

            Console.WriteLine(dao.ObtenerPorId(p1.Id));

            Producto p2 = new Producto()
            {
                Nombre = "Nuevo Por Dao",
                Precio = 123.45m,
                Categoria = daoCategoria.ObtenerPorId(1L)
            };

            dao.Insertar(p2);

            p1.Precio = 54321.12m;

            dao.Modificar(p1);

            Console.WriteLine(dao.ObtenerPorId(p1.Id));

            dao.Eliminar(p2.Id);
            dao.Eliminar(p1.Id);

            Console.WriteLine(dao.ObtenerPorId(p1.Id));

            Console.ReadKey();
        }
    }
}
