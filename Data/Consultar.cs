using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Consultar
    {
        public DataTable ObtenerCompany(int id)
        {
            string Query = String.Format("select c.codigo_company,c.name_company,a.app_name,v.version \r\nfrom company c\r\ninner join version_company vc on c.id_company = vc.company_id\r\ninner join version v on vc.version_id = v.version_id\r\ninner join application a on a.app_id = v.app_id\r\nwhere c.id_company = {0}", id);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
