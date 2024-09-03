using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Actualizar
    {
        public int ActualizarAplicacion()
        {
            throw new NotImplementedException();
        }

        public int ActualizarCompamia(int id, string codigo_company, string name_company, string description_company)
        {
            string Query = String.Format("update TMP_LLENAR_CAMPOS set codigo_company = '{1}', name_company = '{2}',  description_company = '{3}' where id = {0}", id, codigo_company, name_company, description_company);
            int reuslt = Conexion.Ejecutar(Query);
            return reuslt;
        }

        public int ActualizarVersion()
        {
            throw new NotImplementedException();
        }
    }
}
