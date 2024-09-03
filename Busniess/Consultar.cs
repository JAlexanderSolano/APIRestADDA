using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busniess
{
    public class Consultar: IRepositoryConsultar
    {
        public DataTable ObtenerCompany(int id)
        {
            Data.Consultar _consultar = new Data.Consultar();
            DataTable tblResult = _consultar.ObtenerCompany(id);
            return tblResult;
        }
    }
}
