using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Library
{
    public class Analizador
    {
        int i = 0;
        private char[] inputArray;
        private List<Input> inputs = new List<Input>();
        private int NoLinea = 0;
        private char[] NUMEROS = "0123456789".ToCharArray();


        public void EmpezarAnalizador()
        {
            Console.WriteLine("Ingrese el codigo");
            string input = Console.ReadLine();
            inputArray = input.ToCharArray();

            while (i <= inputArray.Count() - 1)
            {
                if (esNumero())
                {
                    if (input[i] == '.')
                    {
                        i++;
                        if (esNumero())
                        {
                            //printf("[real]");
                        }
                        else if (input[i] == '.')
                        {
                            //printf("[entero]");
                            //printf("[rango]");
                        }
                    }
                    else
                    {
                        //printf("[entero]");
                    }
                }
                else if (esIdentificador())
                {
                    //printf("[identificador]");
                }
                else if (esOperador())
                {
                    //printf("[asignación]");

                }
                else if (esIf())
                {
                    //printf("[asignación]");
                }
                else if (esElseIf())
                {
                    //printf("[asignación]");
                }
                else if (esElse())
                {
                    //printf("[asignación]");
                }
                else if (esWhile())
                {
                    //printf("[asignación]");
                }
                else if (esSaltoDeLinea())
                {
                    
                }
                else
                {
                    i++;
                }
            }
        }

        //Cambiar 
        public bool esSaltoDeLinea()
        {
            return true;
        }

        //EJEMPLO: WHILE
        public bool esWhile()
        {
            if ((inputArray[i] + inputArray[i + 1] + inputArray[i + 2] + inputArray[i + 3] + inputArray[i + 4]).ToString().ToLower() == "while")
            {
                i += 4;
                inputs.Add(new Input(TipoDeToken.While,"while", NoLinea));
                if (esParentesisInicial())
                {
                    i++;
                    if (esIdentificador())
                    {
                        i++;
                        //inputs.Add(new Input(TipoDeToken.Identificador,"", NoLinea));
                        if (esOperador())
                        {
                            i++;
                            //inputs.Add(new Input(TipoDeToken.Operador, NoLinea));
                            if (esConstante())
                            {
                                i++;
                                //inputs.Add(new Input(TipoDeToken.Constante, NoLinea));
                                return true;
                            }
                            else
                            {
                                //inputs.Add(new Input(TipoDeToken.Error, NoLinea));
                                return false;
                            }
                        }

                        else
                        {
                            //inputs.Add(new Input(TipoDeToken.Error, NoLinea));
                            return false;
                        }
                    }
                    else
                    {
                        //inputs.Add(new Input(TipoDeToken.Error, NoLinea));
                        return false;
                    }
                }
                else
                {
                    //inputs.Add(new Input(TipoDeToken.Error, NoLinea));
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //checar
        public bool esNumero()
        {
            if (char.IsDigit(inputArray[i]))
            {
                i++;
                return true;
            }
            else
                return false;
        }

        public bool esIdentificador()
        {
            //TENGO DUDAS EN ESTE
            return true;
        }

        public bool esElse()
        {
            return true;
        }

        public bool esIf()
        {
            return true;
        }

        public bool esElseIf()
        {
            return true;
        }

        public bool esParentesisInicial()
        {
            //aprueba si es parentesis si, si agregar input
            if (inputArray[i] == '(')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.ParentesisInicial, "(", NoLinea));
                return true;
            }
            return false;
        }

        public bool esParentesisTerminal()
        {
            if (inputArray[i] == ')')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.ParentesisFinal, ")", NoLinea));
                return true;
            }
            return false;
        }

        public bool esConstante()
        {
            string constante = String.Empty;
            if (inputArray[i].ToString().IndexOfAny(NUMEROS) >= 0)
            {
                do
                {
                    constante += inputArray[i];
                    i++;
                }
                while (inputArray[i].ToString().IndexOfAny(NUMEROS) >= 0);
                inputs.Add(new Input(TipoDeToken.Constante, constante, NoLinea));
                return true;
            }
            return false;
        }


        public bool esFor()
        {
            if (inputArray[i] == 'f' && inputArray[i + 1] == 'o' && inputArray[i + 2] == 'r')
            {
                i += 2;
                inputs.Add(new Input(TipoDeToken.Foreach, "foreach", NoLinea));
                return true;
            }
            return false;
        }

        public bool esSwitch()
        {
            return true;
        }

        public bool esForeach()
        {
            if(inputArray[i] == 'f' && inputArray[i+1] == 'o' && inputArray[i+2]=='r')
                if (inputArray[i + 3] == 'e' && inputArray[i + 4] == 'a' && inputArray[i + 5] == 'c' && inputArray[i+6] == 'h')
                {
                    i += 6;
                    inputs.Add(new Input(TipoDeToken.Foreach, "foreach", NoLinea));
                    return true;
                }
            return false;
        }

        public bool esChar()
        {
            return true;
        }

        public bool esPuntoYComa()
        {
            if (inputArray[i] == ';')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.PuntoComa, ";", NoLinea));
                return true;
            }
            else
                return false;
        }

        public bool esMayor()
        {
            if (inputArray[i] == '>')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.Mayor, ">", NoLinea));
                return true;
            }
            else
                return false;
        }
        public bool esMenor()
        {
            if (inputArray[i] == '>')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.Menor, "<", NoLinea));
                return true;
            }
            else
                return false;
        }

        public bool esMenorIgual()
        {
            if (inputArray[i] == '<')
                if (inputArray[i + 1] == '=')
                {
                    i += 2;
                    inputs.Add(new Input(TipoDeToken.MenorIgual, "<=", NoLinea));
                    return true;
                }
            return false;
        }
        public bool esMayorIgual()
        {
            if (inputArray[i] == '>')
                if (inputArray[i + 1] == '=')
                {
                    i += 2;
                    inputs.Add(new Input(TipoDeToken.MayorIgual, ">=", NoLinea));
                    return true;
                }
            return false;
        }
        public bool esDiferente()
        {
            if (inputArray[i] == '!')
                if (inputArray[i + 1] == '=')
                {
                    i += 2;
                    inputs.Add(new Input(TipoDeToken.Diferente, "!=", NoLinea));
                    return true;
                }
            return false;
        }

        public bool esIgual()
        {
            if (inputArray[i + 1] == '=')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.Igual, "=", NoLinea));
                return true;
            }
            return false;
        }

        public bool esLlaveInicial()
        {
            if (inputArray[i] == '{')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.LlaveInicial, "{", NoLinea));
                return true;
            }
            return false;
        }

        public bool esLlaveTerminal()
        {
            if (inputArray[i] == '}')
            {
                i++;
                inputs.Add(new Input(TipoDeToken.LlaveFinal, "}", NoLinea));
                return true;
            }
            return false;
        }

        public bool esIncremento()
        {
            if (inputArray[i] == '+')
                if (inputArray[i + 1] == '+')
                {
                    i += 2;
                    inputs.Add(new Input(TipoDeToken.Incremento, "++", NoLinea));
                    return true;
                }
            return false;
        }

    }
}
