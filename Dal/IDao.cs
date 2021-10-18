﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDao<T>
    {
        IEnumerable<T> ObtenerTodos();
        T ObtenerPorId(long id);

        T Insertar(T objeto);
        T Modificar(T objeto);
        void Eliminar(long id);
    }
}
