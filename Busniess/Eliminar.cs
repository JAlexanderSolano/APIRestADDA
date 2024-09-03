using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Busniess
{
    public class Eliminar : IRepositoryEliminar
    {
        public int EliminarDatos(int id)
        {
            Data.Eliminar _eliminar = new Data.Eliminar();
            int result = _eliminar.EliminarDatos(id);
            return result;
        }

    }
}
