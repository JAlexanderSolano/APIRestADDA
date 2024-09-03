using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRepositoryActualizar
    {
        int ActualizarCompamia(int id, string codigo_company, string name_company, string description_company);
        int ActualizarVersion();
        int ActualizarAplicacion();

    }
}
