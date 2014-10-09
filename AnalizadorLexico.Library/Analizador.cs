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
                if (esParentesis())
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

        public bool esOperador()
        {

            //TENGO DUDAS EN ESTE
            if (inputArray[i] == '<' || inputArray[i] == '>' || inputArray[i] == '=')
            {
                i++;
                esOperador();
                return true;
            }
            else
            {
                return false;
            }
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

        public bool esParentesis()
        {
            //aprueba si es parentesis si, si agregar input
            inputs.Add(new Input(TipoDeToken.ParentesisInicial, "(", NoLinea));
            return true;
        }

        public bool esConstante()
        {
            return true;
        }


        public bool esFor()
        {
            return true;
        }

        public bool esSwitch()
        {
            return true;
        }

        public bool esForeach()
        {
            return true;
        }

        public bool esChar()
        {
            return true;
        }

        public bool esPuntoYComa()
        {
            return true;
        }

        public bool esMayor()
        {
            return true;
        }
        public bool esMenor()
        {
            return true;
        }

        public bool esMenorIgual()
        {
            return true;
        }
        public bool esMayorIgual()
        {
            return true;
        }
        public bool esDiferente()
        {
            return true;
        }

        public bool esIgual()
        {
            return true;
        }

        public bool esLlave()
        {
            return true;
        }

        public bool esIncremento()
        {
            return true;
        }

    }
}
