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
        private int NoLinea = 1;
        private char[] LETRAS = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ".ToCharArray();


        public void EmpezarAnalizador()
        {
            inputs = new List<Input>();
            i = 0;
            Console.WriteLine("Ingrese el codigo");

            string input = Console.ReadLine();
            inputArray = input.ToCharArray();

            for (int j = 0; j <= inputArray.Count() - 1; j++)
            {
                try
                {
                    esEspacio();
                    esWhile();
                    esElseIf();
                    esElse();
                    esIf();
                    esParentesisInicial();
                    esParentesisTerminal();
                    esString();
                    esForeach();
                    esFor();
                    esPuntoYComa();
                    esMenorIgual();
                    esMayorIgual();
                    esMenor();
                    esMayor();
                    esLlaveInicial();
                    esLlaveTerminal();
                    esIncremento();
                    esIgual();
                    esDiferente();
                    esSaltoDeLinea();
                    esIdentificador();

                    if (char.IsDigit(inputArray[i]))
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.Entero, inputArray[i - 1].ToString(), NoLinea));
                        if (inputArray[i] == '.')
                        {
                            i++;
                            if (char.IsDigit(inputArray[i]))
                            {
                                i++;
                                inputs.Add(new Input(TipoDeToken.Real, inputArray[i - 1].ToString(), NoLinea));
                            }
                            else if (inputArray[i] == '.')
                            {
                                inputs.Add(new Input(TipoDeToken.Rango, inputArray[i].ToString(), NoLinea));
                                i++;
                            }
                        }
                        if (char.IsDigit(inputArray[i]))
                        {
                            i++;
                            inputs.Add(new Input(TipoDeToken.Entero, inputArray[i - 1].ToString(), NoLinea));
                        }
                    }
                }
                catch (Exception)
                {

                }

            }

            foreach (var inp in inputs)
            {
                Console.Write("[" + (int)inp.tipoDeToken + "] ");
            }
            Console.ReadLine();
        }

        private void esEspacio()
        {
            if (!endOfInput())
                if (inputArray[i] == ' ')
                    i++;
        }

        private bool endOfInput()
        {
            if (i >= inputArray.Length)
                return true;
            return false;
        }

        private bool esSaltoDeLinea()
        {
            try
            {
                if (!endOfInput())
                {
                    if (inputArray[i].ToString() == "/" &&
                        (inputArray[i + 1].ToString() == "n" || inputArray[i + 1].ToString() == "t"))
                    {
                        NoLinea++;
                        i += 2;
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private bool esWhile()
        {
            try
            {
                int esBlanco = 0;
                if (!endOfInput())
                {
                    if (inputArray[i] == 'w' && inputArray[i + 1] == 'h' && inputArray[i + 2] == 'i' && inputArray[i + 3] == 'l'&& inputArray[i + 4] == 'e')
                    {
                        i += 5;
                        inputs.Add(new Input(TipoDeToken.While, "while", NoLinea));
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }



        //private bool esIdentificador()
        //{
        //    try
        //    {

        //        int empiezaIdentificador = i;
        //        if (char.IsLetter(inputArray[i]))
        //        {
        //            string lexema = "";
        //            lexema += inputArray[i].ToString();
        //            i++;
        //            if (esLetraODigito())
        //            {
        //                for (int x = empiezaIdentificador; x == i; x++)
        //                {
        //                    lexema += inputArray[x];
        //                }
        //                return true;
        //            }
        //            inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return false;
        //}

        //private bool esIdentificador()
        //{
        //    try
        //    {
        //        if (!endOfInput())
        //        {
        //            int empiezaIdentificador = i;
        //            if (char.IsLetter(inputArray[i]))
        //            {
        //                string lexema = "";
        //                lexema += inputArray[i].ToString();
        //                i++;
        //                while (esLetraODigito())
        //                {
        //                    esLetraODigito();
        //                }

        //                for (int x = empiezaIdentificador; x == i; x++)
        //                {
        //                    lexema += inputArray[x].ToString();
        //                }

        //                inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return false;
        //}

        private bool esIdentificador()
        {
            try
            {
                if (!endOfInput())
                {
                    if (char.IsLetter(inputArray[i]))
                    {
                        string lexema = "";
                        lexema += inputArray[i].ToString();
                        i++;

                        while (char.IsLetterOrDigit(inputArray[i]) && !endOfInput())
                        {
                            lexema += inputArray[i];
                            i++;

                            if (endOfInput())
                            {
                                inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
                                return true;
                            }
                            else if (!char.IsLetterOrDigit(inputArray[i]))
                            {
                                inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
                                return true;
                            }
                        }
                        inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }


        private bool esLetraODigito()
        {
            try
            {
                if (!endOfInput())
                {
                    if (char.IsLetterOrDigit(inputArray[i]))
                    {
                        i++;
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private bool esElse()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() > 3)
                    {
                        if (inputArray[i] == 'e' && inputArray[i + 1] == 'l' && inputArray[i + 2] == 's' &&
                            inputArray[i + 3] == 'e')
                        {
                            i += 4;
                            inputs.Add(new Input(TipoDeToken.Else, "else", NoLinea));
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esIf()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() > 1)
                    {
                        if (inputArray[i] == 'i' && inputArray[i + 1] == 'f')
                        {
                            i += 2;
                            inputs.Add(new Input(TipoDeToken.If, "if", NoLinea));
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esElseIf()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == 'e' && inputArray[i + 1] == 'l' && inputArray[i + 2] == 's' &&
                            inputArray[i + 3] == 'e' && inputArray[i + 4] == ' ' && inputArray[i + 5] == 'i' &&
                            inputArray[i + 6] == 'f')
                    {
                        i += 7;
                        inputs.Add(new Input(TipoDeToken.Elseif, "else if", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esParentesisInicial()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '(')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.ParentesisInicial, "(", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esParentesisTerminal()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == ')')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.ParentesisFinal, ")", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        private bool esString()
        {
            if (!endOfInput())
            {
                try
                {
                    string constante = String.Empty;
                    if (inputArray[i] == '"')
                    {
                        i++;
                        if (char.IsLetter(inputArray[i]))
                        {
                            do
                            {
                                constante += inputArray[i];
                                i++;
                            }
                            while (char.IsLetter(inputArray[i]));
                            if (inputArray[i] == '"')
                            {
                                i++;
                                inputs.Add(new Input(TipoDeToken.String, constante, NoLinea));
                                return true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }


        private bool esFor()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() >= 3)
                    {
                        if (inputArray[i] == 'f' && inputArray[i + 1] == 'o' && inputArray[i + 2] == 'r')
                        {
                            i += 3;
                            inputs.Add(new Input(TipoDeToken.For, "for", NoLinea));
                            return true;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }


        private bool esForeach()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() > 6)
                    {
                        if (inputArray[i] == 'f' && inputArray[i + 1] == 'o' && inputArray[i + 2] == 'r')
                            if (inputArray[i + 3] == 'e' && inputArray[i + 4] == 'a' && inputArray[i + 5] == 'c' &&
                                inputArray[i + 6] == 'h')
                            {
                                i += 7;
                                inputs.Add(new Input(TipoDeToken.Foreach, "foreach", NoLinea));
                                return true;
                            }
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }


        private bool esPuntoYComa()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == ';')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.PuntoComa, ";", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esMayor()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '>')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.Mayor, ">", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
        private bool esMenor()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '<')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.Menor, "<", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esMenorIgual()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '<')
                        if (inputArray[i + 1] == '=')
                        {
                            i += 2;
                            inputs.Add(new Input(TipoDeToken.MenorIgual, "<=", NoLinea));
                            return true;
                        }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }
        private bool esMayorIgual()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '>')
                        if (inputArray[i + 1] == '=')
                        {
                            i += 2;
                            inputs.Add(new Input(TipoDeToken.MayorIgual, ">=", NoLinea));
                            return true;
                        }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
        private bool esDiferente()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '!')
                        if (inputArray[i + 1] == '=')
                        {
                            i += 2;
                            inputs.Add(new Input(TipoDeToken.Diferente, "!=", NoLinea));
                            return true;
                        }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esIgual()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '=')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.Igual, "=", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        private bool esLlaveInicial()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '{')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.LlaveInicial, "{", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        private bool esLlaveTerminal()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '}')
                    {
                        i++;
                        inputs.Add(new Input(TipoDeToken.LlaveFinal, "}", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        private bool esIncremento()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '+')
                        if (inputArray[i + 1] == '+')
                        {
                            i += 2;
                            inputs.Add(new Input(TipoDeToken.Incremento, "++", NoLinea));
                            return true;
                        }
                }
                catch (Exception)
                {

                }
            }
            return false;
        }

        /* private bool esOperadorValido()
         {
             try
             {
                 bool response = false;
                 if (esMayorIgual())
                 {
                     return true;
                     //de esto todavia falta
                 }
             }
             catch (Exception)
             {
             }
             return false;
         }*/

    }
}
