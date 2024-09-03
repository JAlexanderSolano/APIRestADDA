using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Guardar
    {
        public int GuardarDatos(string codigo_company, string name_company, string description_company, string version, string version_description, string version_company_description, string app_code, string app_name, string app_description)
        {
            string Query = String.Format("insert into TMP_LLENAR_CAMPOS([id_company]\r\n,[codigo_company]\r\n,[name_company]\r\n,[description_company]\r\n,[version_id]\r\n,[app_id]\r\n,[version]\r\n,[version_description]\r\n,[version_company_id]\r\n,[company_id]\r\n,[version_company_description]\r\n,[app_code]\r\n,[app_name]\r\n,[app_description]) " +
                "values ((SELECT IDENT_CURRENT ('company') +1) \r\n,'{0}'\r\n,'{1}'\r\n,'{2}'\r\n,(SELECT IDENT_CURRENT ('version') +1)\r\n,(SELECT IDENT_CURRENT ('application') +1)\r\n,'{3}'\r\n,'{4}'\r\n,(SELECT IDENT_CURRENT ('version_company') +1)\r\n,(SELECT IDENT_CURRENT ('company') +1)\r\n,'{5}'\r\n,'{6}'\r\n,'{7}'\r\n,'{8}')",
                codigo_company, name_company, description_company, version, version_description, version_company_description, app_code, app_name, app_description);
            int result = Conexion.Ejecutar(Query);
            return result;
        }
    }
}
