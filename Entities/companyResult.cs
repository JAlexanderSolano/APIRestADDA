using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class companyResult
    {
        public string codigo_company { get; set; }
        public string name_company { get; set; }
        public string app_name { get; set; }
        public string version { get; set; }

        public companyResult() { }

        public companyResult(string codigo_company, string name_company, string app_name, string version)
        {
            this.codigo_company = codigo_company;
            this.name_company = name_company;
            this.app_name = app_name;
            this.version = version;
        }
    }
}
