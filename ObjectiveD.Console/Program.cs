using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(reglasAplicada))
                    {
                        string name =  "\n" + descriptor.Name + "\n";
                        object value = descriptor.GetValue(reglasAplicada) + "\n";
                        System.Console.WriteLine("{0}={1}", name, value);
                    }

                }

                System.Console.ReadLine();
            }
        }
    }
}
