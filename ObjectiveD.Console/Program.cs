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
                List<TipoDeRegla> reglasAplicadas = analizador.EmpezarAnalizador();

                foreach (var reglasAplicada in reglasAplicadas)
                {
                    System.Console.WriteLine(reglasAplicada.ToString() + " | " + (int)reglasAplicada);
                }
                System.Console.ReadLine();
            }
        }
    }
}
