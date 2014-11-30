using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ObjectiveD.AnalizadorLexico;
using ObjectiveD.AnalizadorSintactico.Expresiones;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Analizador
    {
        private int i = 0;
        private Input[] tokens;
        private List<TipoDeRegla> Reglas = new List<TipoDeRegla>();
        List<IInput> inputs = new List<IInput>();
        private IExpresion exp;
        public List<IInput> EmpezarAnalizador()
        {
            AnalizadorLexico.Analizador analizadorLexico = new AnalizadorLexico.Analizador();
            tokens = analizadorLexico.EmpezarAnalizador().ToArray();
            inputs = new List<IInput>();
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
                    if (esIf6())
                        continue;
                    if (esElse1())
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
                    if (esElseIf6())
                        continue;
                    if (esWhile1())
                        continue;
                    if (esWhile2())
                        continue;
                    if (esWhile3())
                        continue;
                    if (esWhile4())
                        continue;
                    if (esWhile5())
                        continue;
                    if (esWhile6())
                        continue;
                    if (esFor1())
                        continue;
                    if (esFor5())
                        continue;
                    if (esFor6())
                        continue;
                    if (esFor2())
                        continue;
                    if (esFor3())
                        continue;
                    if (esFor4())
                        continue;
                    if (esForeach())
                        continue;
                    if (esAsignacion())
                        continue;
                    i++;
                    if (Reglas.Count == 0)
                    {
                        Reglas.Add(TipoDeRegla.ReglaNoExistente);
                    }
                    else
                    {
                        if (Reglas.Last() != TipoDeRegla.ReglaNoExistente)
                            Reglas.Add(TipoDeRegla.ReglaNoExistente);
                    }
                }
                catch (Exception)
                {

                }
            }

            return inputs;

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
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If1));
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
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If2));
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
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If3));
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
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If4));
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
                && (tokens[i + 4].tipoDeToken == TipoDeToken.String || tokens[i + 4].tipoDeToken == TipoDeToken.Entero || tokens[i + 4].tipoDeToken == TipoDeToken.Real) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If5));
                i += 6;
                Reglas.Add(TipoDeRegla.If5);
                return true;
            }
            return false;
        }

        private bool esIf6()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.If && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new If(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.If6));
                i += 6;
                Reglas.Add(TipoDeRegla.If6);
                return true;
            }
            return false;
        }


        private bool esElse1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Else)
            {
                inputs.Add(new Else(TipoDeRegla.Else));
                i += 6;
                Reglas.Add(TipoDeRegla.Else);
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
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif1));
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
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif2));
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
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif3));
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
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif4));
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
                && (tokens[i + 4].tipoDeToken == TipoDeToken.String || tokens[i + 4].tipoDeToken == TipoDeToken.Entero || tokens[i + 4].tipoDeToken == TipoDeToken.Real) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif5));
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif5);
                return true;
            }
            return false;
        }

        private bool esElseIf6()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.Elseif && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new ElseIf(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.Elseif6));
                i += 6;
                Reglas.Add(TipoDeRegla.Elseif6);
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
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While1));
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
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While2));
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
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While3));
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
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While4));
                i += 6;
                Reglas.Add(TipoDeRegla.While4);
                return true;
            }
            return false;
        }

        private bool esWhile5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While &&
                tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && (tokens[i + 4].tipoDeToken == TipoDeToken.String || tokens[i + 4].tipoDeToken == TipoDeToken.Entero || tokens[i + 4].tipoDeToken == TipoDeToken.Real) &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While5));
                i += 6;
                Reglas.Add(TipoDeRegla.While5);
                return true;
            }
            return false;
        }

        private bool esWhile6()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.While && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial &&
                tokens[i + 2].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 3].tipoDeToken == TipoDeToken.IgualIgual
                && tokens[i + 4].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 5].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new While(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 4].Lexema, TipoDeRegla.While6));
                i += 6;
                Reglas.Add(TipoDeRegla.While6);
                return true;
            }
            return false;
        }

        private bool esFor1()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && tokens[i + 2].tipoDeToken == TipoDeToken.Integer &&
                tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Entero &&
                tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                 || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) && tokens[i + 9].tipoDeToken ==
                                                                          TipoDeToken.Entero &&
                tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Incremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, true, TipoDeRegla.For1));
                i += 14;
                Reglas.Add(TipoDeRegla.For1);
                return true;
            }
            return false;
        }

        private bool esFor5()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                 && tokens[i + 2].tipoDeToken == TipoDeToken.Double &&
                 tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                 && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Real &&
                 tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                 && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                 (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                  || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                  tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                  tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) && tokens[i + 9].tipoDeToken ==
                                                                           TipoDeToken.Real &&
                 tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                 && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                 tokens[i + 12].tipoDeToken == TipoDeToken.Incremento
                 && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, true, TipoDeRegla.For5));
                i += 14;
                Reglas.Add(TipoDeRegla.For5);
                return true;
            }
            return false;
        }

        private bool esFor2()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && tokens[i + 2].tipoDeToken == TipoDeToken.Integer &&
                tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Entero &&
                tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                 || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) &&
                 tokens[i + 9].tipoDeToken == TipoDeToken.Entero &&
                tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Decremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, false, TipoDeRegla.For2));
                i += 14;
                Reglas.Add(TipoDeRegla.For2);
                return true;
            }
            return false;
        }

        private bool esFor6()
        {
            if (tokens[i].tipoDeToken == TipoDeToken.For && tokens[i + 1].tipoDeToken == TipoDeToken.ParentesisInicial
                && tokens[i + 2].tipoDeToken == TipoDeToken.Double &&
                tokens[i + 3].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 4].tipoDeToken == TipoDeToken.Igual && tokens[i + 5].tipoDeToken == TipoDeToken.Real &&
                tokens[i + 6].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 7].tipoDeToken == TipoDeToken.Identificador &&
                (tokens[i + 8].tipoDeToken == TipoDeToken.Menor
                 || tokens[i + 8].tipoDeToken == TipoDeToken.Mayor ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MayorIgual ||
                 tokens[i + 8].tipoDeToken == TipoDeToken.MenorIgual) &&
                 tokens[i + 9].tipoDeToken == TipoDeToken.Real &&
                tokens[i + 10].tipoDeToken == TipoDeToken.PuntoComa
                && tokens[i + 11].tipoDeToken == TipoDeToken.Identificador &&
                tokens[i + 12].tipoDeToken == TipoDeToken.Decremento
                && tokens[i + 13].tipoDeToken == TipoDeToken.ParentesisFinal)
            {
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, false, TipoDeRegla.For6));
                i += 14;
                Reglas.Add(TipoDeRegla.For6);
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
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, true, TipoDeRegla.For3));
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
                inputs.Add(new For(tokens[i + 3].Lexema, tokens[i + 4].Lexema, tokens[i + 5].Lexema, tokens[i + 6].Lexema, tokens[i + 7].Lexema, false, TipoDeRegla.For4));
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
                inputs.Add(new Foreach(tokens[i + 2].Lexema, tokens[i + 3].Lexema, tokens[i + 5].Lexema, TipoDeRegla.Foreach));
                i += 7;
                Reglas.Add(TipoDeRegla.Foreach);
                return true;
            }
            return false;

        }
        private bool esAsignacion()
        {
            exp = null;
            if (tokens[i].tipoDeToken == TipoDeToken.Identificador
                && tokens[i + 1].tipoDeToken == TipoDeToken.Igual)
            {
                i += 2;
                Reglas.Add(TipoDeRegla.Asignacion1);
                if (!esExpresionHelper())
                {
                    Reglas.RemoveAt(Reglas.Count - 1);
                    i -= 2;
                    return false;
                }
                inputs.Add(new Asignacion1(tokens[i].Lexema, exp, TipoDeRegla.Asignacion1));
                return true;
            }
            else if ((tokens[i].tipoDeToken == TipoDeToken.Double || tokens[i].tipoDeToken == TipoDeToken.Integer)
                && tokens[i + 1].tipoDeToken == TipoDeToken.Identificador
              && tokens[i + 2].tipoDeToken == TipoDeToken.Igual)
            {
                i += 3;
                Reglas.Add(TipoDeRegla.Asignacion2);
                if (!esExpresionHelper())
                {
                    i -= 2;
                    Reglas.RemoveAt(Reglas.Count - 1);
                    return false;
                }
                inputs.Add(new Asignacion2(tokens[i].Lexema, tokens[i + 1].Lexema, exp, TipoDeRegla.Asignacion2));
                return true;
            }
            return false;
        }


        private bool esExpresionHelper()
        {
            bool response = false;
            if (esExpresion1())
                response = true;
            else if (esExpresion2())
                response = true;
            else if (esExpresion3())
                response = true;
            else if (esExpresion4())
                response = true;
            else if (esExpresion5())
                response = true;
            else if (esExpresion6())
                response = true;
            else if (esExpresion7())
                response = true;
            else if (esExpresion8())
                response = true;
            else if (esExpresion9())
                response = true;
            else if (esExpresion10())
                response = true;
            return response;
        }

        private bool esExpresion1()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                {
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Mas)
                    {
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Entero ||
                            tokens[i + 2].tipoDeToken == TipoDeToken.Real)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion1);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion1);
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;

        }

        private bool esExpresion2()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                {
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                    {
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Entero ||
                            tokens[i + 2].tipoDeToken == TipoDeToken.Real)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion2);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion2);
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion3()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                {
                    exp = new Expresion34(tokens[i].Lexema, TipoDeRegla.Expresion3);
                    i++;
                    Reglas.Add(TipoDeRegla.Expresion3);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion4()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                {
                    exp = new Expresion34(tokens[i].Lexema, TipoDeRegla.Expresion4);
                    i++;
                    Reglas.Add(TipoDeRegla.Expresion4);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion5()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Mas)
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion5);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion5);
                            return true;
                        }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion6()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Entero || tokens[i].tipoDeToken == TipoDeToken.Real)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion6);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion6);
                            return true;
                        }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion7()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Mas)
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion7);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion7);
                            return true;
                        }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion8()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Menos)
                        if (tokens[i + 2].tipoDeToken == TipoDeToken.Identificador)
                        {
                            exp = new Expresion125678(tokens[i + 1].Lexema, tokens[i + 2].Lexema, tokens[i + 3].Lexema, TipoDeRegla.Expresion8);
                            i += 3;
                            Reglas.Add(TipoDeRegla.Expresion8);
                            return true;
                        }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion9()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Incremento)
                    {
                        exp = new Expresion910(tokens[i + 1].Lexema, true, TipoDeRegla.Expresion9);
                        i += 2;
                        Reglas.Add(TipoDeRegla.Expresion9);
                        return true;
                    }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private bool esExpresion10()
        {
            try
            {
                if (tokens[i].tipoDeToken == TipoDeToken.Identificador)
                    if (tokens[i + 1].tipoDeToken == TipoDeToken.Decremento)
                    {
                        exp = new Expresion910(tokens[i + 1].Lexema, false, TipoDeRegla.Expresion10);
                        i += 2;
                        Reglas.Add(TipoDeRegla.Expresion10);
                        return true;
                    }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
