using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectiveD.AnalizadorSintactico;

namespace ObjectiveD.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var analizador = new Analizador();

            while (true)
            {
                List<IInput> inputs = analizador.EmpezarAnalizador();

                foreach (var reglasAplicada in inputs)
                {
                    System.Console.WriteLine(reglasAplicada.TipoDeRegla.ToString());
                }
                System.Console.ReadLine();
            }
        }
    }
}
