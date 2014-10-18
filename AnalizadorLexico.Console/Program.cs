using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalizadorLexico.Library;

namespace AnalizadorLexico.Console
{
    class Program
    {
        static Analizador analizador = new Analizador();

        static void Main(string[] args)
        {
            while (true)
            {
                analizador.EmpezarAnalizador();
            }
        }
    }
}
