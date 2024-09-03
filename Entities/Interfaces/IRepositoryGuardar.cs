using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRepositoryGuardar
    {
        int GuardarDatos(string codigo_company, string name_company, string description_company, string version, string version_description, string version_company_description, string app_code, string app_name, string app_description);
    }
}
