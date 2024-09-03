using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Resultado <T> // clase tipo resultado generica
    {
        public T resultado { get; set; }
        public Resultado(T resultado)
        {
            this.resultado = resultado;
        }

        public Resultado() { }

    }
}
