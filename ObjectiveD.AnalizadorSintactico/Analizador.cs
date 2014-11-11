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

        public List<TipoDeRegla> EmpezarAnalizador()
        {
            AnalizadorLexico.Analizador analizadorLexico = new AnalizadorLexico.Analizador();
            tokens = analizadorLexico.EmpezarAnalizador().ToArray();
            Reglas = new List<TipoDeRegla>();

            for (i = 0; i < tokens.Count(); )
            {
                try
                {
                    if (esIf1())
                        continue;
                    if (esIf2())
                        continue;
                    if (esIf3())
                        continue;
                    if (esIf4())
                        continue;
                    if (esIf5())
                        continue;
                    if (esElse1())
                        continue;
                    if (esElse2())
                        continue;
                    if (esElse3())
                        continue;
                    if (esElse4())
                        continue;
                    if (esElse5())
                        continue;
                    if (esElseIf1())
                        continue;
                    if (esElseIf2())
                        continue;
                    if (esElseIf3())
                        continue;
                    if (esElseIf4())
                        continue;
                    if (esElseIf5())
                        continue;
                    if (esWhile1())
                        continue;
                    if (esWhile2())
                        continue;
                    if (esWhile3())
                        continue;
                    if (esWhile4())
                        continue;
                    if (esFor1())
                        continue;
                    if (esFor2())
                        continue;
                    if (esFor3())
                        continue;
                    if (esFor4())
                        continue;
                    if (esForeach())
                        continue;

                }
                catch (Exception)
                {

                }
            }

            return Reglas;

        }

        private bool esIf1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
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
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
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
            if (tokens[i].tipoDeToken == TipoDeToken.Else && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Else1);
                return true;
            }
            return false;
        }

        private bool esElse2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Else && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Else2);
                return true;
            }
            return false;
        }

        private bool esElse3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Else && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Else3);
                return true;
            }
            return false;
        }

        private bool esElse4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Else && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Else4);
                return true;
            }
            return false;
        }

        private bool esElse5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Else && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.String &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Else5);
                return true;
            }
            return false;
        }

        private bool esElseIf1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif1);
                return true;
            }
            return false;
        }

        private bool esElseIf2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif2);
                return true;
            }
            return false;
        }

        private bool esElseIf3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif3);
                return true;
            }
            return false;
        }

        private bool esElseIf4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif4);
                return true;
            }
            return false;
        }

        private bool esElseIf5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.String &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.ElseIf5);
                return true;
            }
            return false;
        }

        private bool esWhile1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.While1);
                return true;
            }
            return false;
        }

        private bool esWhile2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.While2);
                return true;
            }
            return false;
        }

        private bool esWhile3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.While3);
                return true;
            }
            return false;
        }

        private bool esWhile4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                (tokens[i + 2].tipoDeToken == TipoDeToken.Real || tokens[i + 2].tipoDeToken == TipoDeToken.Entero) &&
                (tokens[i + 3].tipoDeToken == TipoDeToken.Menor || tokens[i + 3].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 3].tipoDeToken == TipoDeToken.MenorIgual)
                && (tokens[i + 4].tipoDeToken == TipoDeToken.Real || tokens[i + 4].tipoDeToken == TipoDeToken.Entero) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 6;
                Reglas.Add(TipoDeRegla.While4);
                return true;
            }
            return false;
        }

        private bool esFor1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && (tokens[i + 2].tipoDeToken == TipoDeToken.Integer
                    || tokens[i + 2].tipoDeToken == TipoDeToken.Double) &&
                tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Entero &&
                tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                 || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) && (tokens[i + 9].tipoDeToken == TipoDeToken.Real
                                                                          ||
                                                                          tokens[i + 9].tipoDeToken ==
                                                                          TipoDeToken.Entero) &&
                tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Incremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 14;
                Reglas.Add(TipoDeRegla.For1);
                return true;
            }
            return false;
        }

        private bool esFor2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && (tokens[i + 2].tipoDeToken == TipoDeToken.Integer
                    || tokens[i + 2].tipoDeToken == TipoDeToken.Double) &&
                tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Entero &&
                tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                 || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) && (tokens[i + 9].tipoDeToken == TipoDeToken.Real
                                                                          ||
                                                                          tokens[i + 9].tipoDeToken ==
                                                                          TipoDeToken.Entero) &&
                tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Decremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 14;
                Reglas.Add(TipoDeRegla.For2);
                return true;
            }
            return false;
        }

        private bool esFor3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For
                && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && (tokens[i + 2].tipoDeToken == TipoDeToken.Integer
                    || tokens[i + 2].tipoDeToken == TipoDeToken.Double)
                && tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual
                && tokens[i + 5].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador
                && (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                    || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                    tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                    tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 9].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Incremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 14;
                Reglas.Add(TipoDeRegla.For3);
                return true;
            }
            return false;
        }

        private bool esFor4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For
                && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && (tokens[i + 2].tipoDeToken == TipoDeToken.Integer
                    || tokens[i + 2].tipoDeToken == TipoDeToken.Double)
                && tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual
                && tokens[i + 5].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador
                && (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                    || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                    tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                    tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual)
                && tokens[i + 9].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Decremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 14;
                Reglas.Add(TipoDeRegla.For4);
                return true;
            }
            return false;

        }

        private bool esForeach()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Foreach
                && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && (tokens[i + 2].tipoDeToken == TipoDeToken.Integer
                || tokens[i + 2].tipoDeToken == TipoDeToken.Double || tokens[i + 2].tipoDeToken == TipoDeToken.TipoString)
                && tokens[i + 3].tipoDeToken == TipoDeToken.Identificador 
                && tokens[i + 4].tipoDeToken == TipoDeToken.In
                && tokens[i + 5].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 6].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                i += 7;
                Reglas.Add(TipoDeRegla.Foreach);
                return true;
            }
            return false;

        }

        /*private bool esAsignacion()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador
                && tokens[i+1].tipoDeToken == TipoDeToken.Igual
                && tokens[i+2].tipoDeToken == TipoDeToken.expre)
            {

            }
        }*/

        private bool esExpresion1()
        {
            if(tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
            {
                if(tokens[i+1].tipoDeToken == TipoDeToken.Mas)
                {
                    if(tokens[i+2].tipoDeToken == TipoDeToken.Entero || tokens[i+2].tipoDeToken == TipoDeToken.Real)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion1);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool esExpresion2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
            {
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                {
                    if (tokens[i + 2].tipoDeToken == TipoDeToken.Entero || tokens[i + 2].tipoDeToken == TipoDeToken.Real)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion2);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool esExpresion3()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
            {
                i++;
                Reglas.Add(TipoDeRegla.Expresion3);
                return true;
            }
            return false;
        }

        private bool esExpresion4()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
            {
                i++;
                Reglas.Add(TipoDeRegla.Expresion4);
                return true;
            }
            return false;
        }

        private bool esExpresion5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                if(tokens[i + 1].tipoDeToken == TipoDeToken.Mas)
                    if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion5);
                        return true;
                    }
            return false;
        }

        private bool esExpresion6()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                    if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion6);
                        return true;
                    }
            return false;
        }

        private bool esExpresion7()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Mas)
                    if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion7);
                        return true;
                    }
            return false;
        }

        private bool esExpresion8()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                    if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                    {
                        i += 3;
                        Reglas.Add(TipoDeRegla.Expresion8);
                        return true;
                    }
            return false;
        }

        private bool esExpresion9()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Incremento)
                {
                    i += 2;
                    Reglas.Add(TipoDeRegla.Expresion9);
                    return true;
                }
            return false;
        }

        private bool esExpresion10()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                if (tokens[i + 1].tipoDeToken == TipoDeToken.Decremento)
                {
                    i += 2;
                    Reglas.Add(TipoDeRegla.Expresion10);
                    return true;
                }
            return false;
        }
    }
}
