using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorLexico
{
    public class Analizador
    {
        private int i = 0;
        private char[] inputArray;
        private List<Input> inputs = new List<Input>();
        private int NoLinea = 1;
        private char[] LETRAS = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ".ToCharArray();
        private string valorNumerico = "";

        public List<Input> EmpezarAnalizador()
        {
            inputs = new List<Input>();
            i = 0;
            Console.WriteLine("Ingrese el codigo");
            string input = Console.ReadLine();
            inputArray = input.ToCharArray();

            for (i = 0; i < inputArray.Count(); )
            {
                try
                {
                    if (esTipoString())
                        continue;
                    if (esInteger())
                        continue;
                    if (esDouble())
                        continue;
                    if (esDouble())
                        continue;
                    if (esIn())
                        continue;
                    if (esForeach())
                        continue;
                    if (esWhile())
                        continue;
                    if (esElseIf())
                        continue;
                    if (esElse())
                        continue;
                    if (esIf())
                        continue;
                    if (esString())
                        continue;
                    if (esFor())
                        continue;
                    if (esPuntoYComa())
                        continue;
                    if (esMenorIgual())
                        continue;
                    if (esMayorIgual())
                        continue;
                    if (esMenor())
                        continue;
                    if (esMayor())
                        continue;
                    if (esIgualIgual())
                        continue;
                    if (esIncremento())
                        continue;
                    if (esDecremento())
                        continue;
                    if (esMas())
                        continue;
                    if (esMenos())
                        continue;
                    if (esLlaveInicial())
                        continue;
                    if (esLlaveTerminal())
                        continue;
                    if (esIgual())
                        continue;
                    if (esDiferente())
                        continue;
                    if (esSaltoDeLinea())
                        continue;
                    if (esIdentificador())
                        continue;
                    if (esParentesisInicial())
                        continue;
                    if (esParentesisTerminal())
                        continue;
                    if (esDigito())
                        continue;
                    if (esEspacio())
                        continue;
                    if (!endOfInput())
                    {
                        inputs.Add(new Input(TipoDeToken.Error, inputArray[i].ToString(), NoLinea));
                        i++;
                        continue;
                    }
                }
                catch (Exception)
                {

                }

            }

            return inputs;
        }


        public bool esDigito()
        {
            if (!endOfInput())
            {
                string valorNumerico = String.Empty;
                if (char.IsDigit(inputArray[i]))
                {
                    do
                    {
                        valorNumerico += inputArray[i];
                        i++;
                        if (i >= inputArray.Length)
                        {
                            inputs.Add(new Input(TipoDeToken.Entero, valorNumerico, NoLinea));
                            break;
                        }
                    }
                    while (char.IsDigit(inputArray[i]));
                    if (inputArray[i] == '.')
                    {
                        i++;
                        if (inputArray[i] == '.')
                        {
                            valorNumerico += "..";
                            i++;
                            if (char.IsDigit(inputArray[i]))
                            {
                                do
                                {
                                    valorNumerico += inputArray[i];
                                    i++;
                                    if (i >= inputArray.Length)
                                    {
                                        inputs.Add(new Input(TipoDeToken.Rango, valorNumerico, NoLinea));
                                        break;
                                    }
                                } while (char.IsDigit(inputArray[i]));
                                if (!char.IsDigit(inputArray[i]))
                                {
                                    inputs.Add(new Input(TipoDeToken.Rango, valorNumerico, NoLinea));
                                    return true;
                                }
                            }
                        }

                        else if (char.IsDigit(inputArray[i]))
                        {
                            do
                            {
                                valorNumerico += inputArray[i];
                                i++;
                                if (i >= inputArray.Length)
                                {
                                    inputs.Add(new Input(TipoDeToken.Real, valorNumerico, NoLinea));
                                    break;
                                }
                            } while (char.IsDigit(inputArray[i]));
                            if (!char.IsDigit(inputArray[i]))
                            {
                                inputs.Add(new Input(TipoDeToken.Real, valorNumerico, NoLinea));
                                return true;
                            }
                        }
                    }
                    else if (!char.IsDigit(inputArray[i]))
                    {
                        inputs.Add(new Input(TipoDeToken.Entero, valorNumerico, NoLinea));
                        return true;
                    }
                }
            }
            return false;
        }


        private bool esEspacio()
        {
            if (!endOfInput())
            {
                if (string.IsNullOrWhiteSpace(inputArray[i].ToString()))
                {
                    i++;
                    return true;
                }
            }
            return false;
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
                    if (inputArray[i] == 'w' && inputArray[i + 1] == 'h' && inputArray[i + 2] == 'i' && inputArray[i + 3] == 'l' && inputArray[i + 4] == 'e')
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


        private bool esIdentificador()
        {
            string lexema = "";
            try
            {
                if (!endOfInput())
                {
                    if (char.IsLetter(inputArray[i]))
                    {
                        lexema += inputArray[i].ToString();
                        i++;

                        if (!endOfInput())
                        {
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
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(lexema))
                            {
                                inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
                                return true;
                            }

                        }

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

        public bool esIgualIgual()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '=' && inputArray[i + 1] == '=')
                    {
                        i += 2;
                        inputs.Add(new Input(TipoDeToken.IgualIgual, "==", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public bool esIn()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == 'i' && inputArray[i + 1] == 'n')
                    {
                        i += 2;
                        inputs.Add(new Input(TipoDeToken.In, "in", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public bool esMas()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '+')
                    {
                        i += 1;
                        inputs.Add(new Input(TipoDeToken.Mas, "+", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public bool esMenos()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '-')
                    {
                        i += 1;
                        inputs.Add(new Input(TipoDeToken.Menos, "-", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public bool esDecremento()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray[i] == '-' && inputArray[i + 1] == '-')
                    {
                        i += 2;
                        inputs.Add(new Input(TipoDeToken.Decremento, "--", NoLinea));
                        return true;
                    }
                }
                catch (Exception)
                {
                }
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

        private bool esInteger()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() >= 3)
                    {
                        if (inputArray[i] == 'i' && inputArray[i + 1] == 'n' && inputArray[i + 2] == 't')
                        {
                            i += 3;
                            inputs.Add(new Input(TipoDeToken.Integer, "int", NoLinea));
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


        private bool esDouble()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() >= 3)
                    {
                        if (inputArray[i] == 'd' && inputArray[i + 1] == 'o' && inputArray[i + 2] == 'u' && inputArray[i + 3] == 'b' && inputArray[i + 4] == 'l' && inputArray[i + 5] == 'e')
                        {
                            i += 6;
                            inputs.Add(new Input(TipoDeToken.Double, "double", NoLinea));
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

        private bool esTipoString()
        {
            if (!endOfInput())
            {
                try
                {
                    if (inputArray.Count() >= 3)
                    {
                        if (inputArray[i] == 's' && inputArray[i + 1] == 't' && inputArray[i + 2] == 'r' && inputArray[i + 3] == 'i' && inputArray[i + 4] == 'n' && inputArray[i + 5] == 'g')
                        {
                            i += 6;
                            inputs.Add(new Input(TipoDeToken.TipoString, "string", NoLinea));
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


    }
}
