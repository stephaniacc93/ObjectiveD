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
        private Input[] tokens;
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial && tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[1 + 3].tipoDeToken == TipoDeToken.Menor || tokens[1 + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.If1);
                return true;
            }
            return false;
        }

        private bool esIf2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial && tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[1 + 3].tipoDeToken == TipoDeToken.Menor || tokens[1 + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.If2);
                return true;
            }
            return false;
        }
        private bool esIf3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial && (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
              (tokens[1 + 3].tipoDeToken == TipoDeToken.Menor || tokens[1 + 3].tipoDeToken == TipoDeToken.Mayor ||
               tokens[1 + 3].tipoDeToken == TipoDeToken.MayorIgual ||
               tokens[1 + 3].tipoDeToken == TipoDeToken.MenorIgual)
              && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
              tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.If3);
                return true;
            }
            return false;
        }

        private bool esIf4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial && (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[1 + 3].tipoDeToken == TipoDeToken.Menor || tokens[1 + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[1 + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.If4);
                return true;
            }
            return false;
        }

        private bool esIf5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial && tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[1 + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.String &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.If5);
                return true;
            }
            return false;
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
