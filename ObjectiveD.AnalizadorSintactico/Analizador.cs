using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectiveD.AnalizadorLexico;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Analizador
    {
        private int i = 0;
        public void EmpezarAnalizador()
        {
            AnalizadorLexico.Analizador analizadorLexico = new AnalizadorLexico.Analizador();
            List<Input> ListaDeTokens = analizadorLexico.EmpezarAnalizador();

            foreach (var listaDeToken in ListaDeTokens)
            {

                try
                {
                    esIf1();
                }
                catch (Exception)
                {

                }
            }

        }

        private bool esIf1()
        {
            return true;
        }
    }
}
