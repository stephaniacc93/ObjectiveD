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
        private Input [] tokens; 
        private List<TipoDeRegla> Reglas = new List<TipoDeRegla>(); 
        public void EmpezarAnalizador()
        {
            AnalizadorLexico.Analizador analizadorLexico = new AnalizadorLexico.Analizador();
            tokens = analizadorLexico.EmpezarAnalizador().ToArray();
            Reglas = new List<TipoDeRegla>();

            while (i < tokens.Count())
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[1 + 2].tipoDeToken == TipoDeToken.Menor || tokens[1 + 2].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[1 + 2].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[1 + 2].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 3].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 4].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 5;
                Reglas.Add(TipoDeRegla.If1);
            }
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
