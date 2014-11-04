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
                    esIf2();
                    esIf3();
                    esIf4();
                    esElse1();
                    esElse2();
                    esElse3();
                    esElse4();
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

        private bool esIf2()
        {
            return true;
        }
        private bool esIf3()
        {
            return true;
        }
        private bool esIf4()
        {
            return true;
        }

        private bool esElse1()
        {
            return true;
        }

        private bool esElse2()
        {
            return true;
        }
        private bool esElse3()
        {
            return true;
        }
        private bool esElse4()
        {
            return true;
        }
    }
}
