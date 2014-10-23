using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectiveD.AnalizadorLexico;

namespace ObjectiveD.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var analizador = new Analizador();

            while (true)
            {
                analizador.EmpezarAnalizador();
            }
        }
    }
}
