using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Busniess
{
    public class Guardar : IRepositoryGuardar
    {
        public int GuardarDatos(string codigo_company, string name_company, string description_company, string version, string version_description, string version_company_description, string app_code, string app_name, string app_description)
        {
            Data.Guardar guardar = new Data.Guardar();
            int guardo = guardar.GuardarDatos(codigo_company, name_company, description_company, version, version_description, version_company_description, app_code, app_name, app_description);
            return guardo;
        }
    }
}
