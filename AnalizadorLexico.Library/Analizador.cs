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

                    if (esNumero())
                    {
                        inputs.Add(new Input(TipoDeToken.Real, inputArray[i - 1].ToString(), NoLinea));
                        if (inputArray[i] == '.')
                        {
                            i++;
                            if (esNumero())
                            {
                                inputs.Add(new Input(TipoDeToken.Real, inputArray[i - 1].ToString(), NoLinea));
                            }
                            else if (inputArray[i] == '.')
                            {
                                inputs.Add(new Input(TipoDeToken.Rango, inputArray[i - 1].ToString(), NoLinea));
                                i++;
                            }
                        }
                        else if (esNumero())
                        {
                            inputs.Add(new Input(TipoDeToken.Entero, inputArray[i - 1].ToString(), NoLinea));
                        }
                    }
                }
                catch (Exception)
                {

                }
                esEspacio();
                //esWhile();
                //esIdentificador();
                //esElse();
                //esIf();
                //esElseIf();
                //esParentesisInicial();
                //esParentesisTerminal();
                //esString();
                esForeach();
                esFor();
                esPuntoYComa();
                esOperadorValido();
                esLlaveInicial();
                esLlaveTerminal();
                esIncremento();
                esSaltoDeLinea();
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
                if (inputArray[i].ToString() == "/" && (inputArray[i + 1].ToString() == "n" || inputArray[i + 1].ToString() == "t"))
                {
                    NoLinea++;
                    i += 2;
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        //CAMBIAR: WHILE
        private bool esWhile()
        {
            try
            {
                int esBlanco = 0;
                if (inputArray.Count() > 5)
                {
                    if (
                        (inputArray[i] + inputArray[i + 1] + inputArray[i + 2] + inputArray[i + 3] + inputArray[i + 4])
                            .ToString().ToLower() == "while")
                    {
                        i += 4;
                        inputs.Add(new Input(TipoDeToken.While, "while", NoLinea));
                        //esBlanco =  esEspacioEnBlanco()
                        if (esParentesisInicial() && esBlanco == 0)
                        {
                            i++;
                            if (esIdentificador())
                            {
                                i++;
                                //inputs.Add(new Input(TipoDeToken.Identificador,"", NoLinea));
                                if (esOperadorValido())
                                {
                                    i++;
                                    //inputs.Add(new Input(TipoDeToken.Operador, NoLinea));
                                    //if (esConstante())
                                    //{
                                    //    i++;
                                    //    //inputs.Add(new Input(TipoDeToken.Constante, NoLinea));
                                    //    return true;
                                    //}
                                    //else
                                    //{
                                    //    //inputs.Add(new Input(TipoDeToken.Error, NoLinea));
                                    //    return false;
                                    //}
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
                        }
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        private bool esNumero()
        {
            try
            {

                if (char.IsDigit(inputArray[i]))
                {
                    i++;
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        private bool esIdentificador()
        {
            try
            {

                int empiezaIdentificador = i;
                if (char.IsLetter(inputArray[i]))
                {
                    string lexema = "";
                    lexema += inputArray[i].ToString();
                    i++;
                    if (esLetraODigito())
                    {
                        for (int x = empiezaIdentificador; x == i; x++)
                        {
                            lexema += inputArray[x];
                        }
                        return true;
                    }
                    inputs.Add(new Input(TipoDeToken.Identificador, lexema, NoLinea));
                    return true;
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
                if (char.IsLetterOrDigit(inputArray[i]))
                {
                    i++;
                    esLetraODigito();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private bool esElse()
        {
            try
            {
                if (inputArray.Count() > 4)
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
            return false;
        }

        private bool esIf()
        {
            try
            {
                if (inputArray.Count() > 2)
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
            return false;
        }

        private bool esElseIf()
        {
            try
            {
                if (esElse() && esIf())
                {
                    inputs.Add(new Input(TipoDeToken.Elseif, "else if", NoLinea));
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private bool esParentesisInicial()
        {
            try
            {
                //aprueba si es parentesis si, si agregar input
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
            return false;
        }

        private bool esParentesisTerminal()
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
            return false;
        }

        private bool esString()
        {
            try
            {
                string constante = String.Empty;
                if (inputArray[i] == '"')
                {
                    if (inputArray[i].ToString().IndexOfAny(LETRAS) >= 0)
                    {
                        do
                        {
                            constante += inputArray[i];
                            i++;
                        }
                        while (inputArray[i].ToString().IndexOfAny(LETRAS) >= 0);
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
            return false;
        }
        private bool esMenor()
        {
            try
            {
                if (inputArray[i] == '>')
                {
                    i++;
                    inputs.Add(new Input(TipoDeToken.Menor, "<", NoLinea));
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        private bool esMenorIgual()
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

            return false;
        }
        private bool esMayorIgual()
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

            return false;
        }
        private bool esDiferente()
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

            return false;
        }

        private bool esIgual()
        {
            try
            {
                if (inputArray[i + 1] == '=')
                {
                    i++;
                    inputs.Add(new Input(TipoDeToken.Igual, "=", NoLinea));
                    return true;
                }
            }
            catch (Exception)
            {

            }

            return false;
        }

        private bool esLlaveInicial()
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

            return false;
        }

        private bool esLlaveTerminal()
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

            return false;
        }

        private bool esIncremento()
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

            return false;
        }

        private bool esOperadorValido()
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
        }

    }
}
