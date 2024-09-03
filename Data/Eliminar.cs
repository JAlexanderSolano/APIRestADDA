using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Eliminar
    {
        public int EliminarDatos(int id)
        {
            string Query = String.Format("Delete from TMP_LLENAR_CAMPOS where id = {0}", id);
            int result = Conexion.Ejecutar(Query);
            return result;
        }
    }
}
