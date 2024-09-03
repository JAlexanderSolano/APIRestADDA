using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Busniess
{
    public class Actualizar: IRepositoryActualizar
    {
    
        public int ActualizarCompamia(int id, string codigo_company, string name_company, string description_company)
        {
            Data.Actualizar _actualizar = new Data.Actualizar();
            int result = _actualizar.ActualizarCompamia(id, codigo_company, name_company, description_company);
            return result;
        }

        public int ActualizarVersion()
        {
            Data.Actualizar _actualizar = new Data.Actualizar();
            int result = _actualizar.ActualizarVersion();
            return result;
        }

        public int ActualizarAplicacion()
        {
            Data.Actualizar _actualizar = new Data.Actualizar();
            int result = _actualizar.ActualizarAplicacion();
            return result;
        }
    }
}
