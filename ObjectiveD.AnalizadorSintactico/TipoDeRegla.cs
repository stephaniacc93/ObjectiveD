using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public enum TipoDeRegla
    {
        //if(identificador operador identificador) -ya
        If1,
        //if(identificador operador entero/real) -ya
        If2,
        //if(entero/real operador identificador)   -ya
        If3,
        //if(entero/real operador entero/real)    -ya
        If4,
        //if(identificador igualigual string/entero/real) -  FALTA
        If5,
        //if(identificador igualigual identificador) -  FALTA
        If6,

        //else
        Else,
        
        //elseif(identificador operador identificador)     -ya
        Elseif1,
        //elseif(identificador operador entero/real)   -ya
        Elseif2,
        //elseif(entero/real operador identificador)    -ya
        Elseif3,
        //elseif(entero/real operador entero/real)    -ya
        Elseif4,
        //elseif(identificador igualigual string) -ya
        ElseIf5,
        //elseif(identificador igualigual identificador)
        ElseIf6,

        //while(identificador operador identificador)     -ya
        While1,
        //while(identificador operador entero/real)     -ya
        While2,
        //while(entero/real operador identificador)    -ya
        While3,
        //while(entero/real operador entero/real)  -ya
        While4,
        //while(identificador igualigual string) -ya
        While5,
        //while(identificador igualigual identificador)
        While6,

        // for (int identificador igual entero; identificador operador int; identificador ++)     -ya
        For1,
        // for (double identificador igual real; identificador operador real; identificador ++)
        For5,

        //  for (double identificador igual real; identificador operador real; identificador--)
        For6,

        //  for (int identificador igual entero; identificador operador entero; identificador--)
        For2,

        //  for (tipo de variable identificador igual identificador; identificador operador identificador; identificador++)     -ya
        For3,

        //  for (tipo de variable identificador igual identificador; identificador operador identificador; identificador--)      -ya
        For4,

        //foreach(tipo de variable identificador in identificador)   -ya
        Foreach,

        //identificador = expresion   omar ? pendiente por falta de saber que es expresion
        Asignacion1,

        //tipo de variable identificador  = expresion
        Asignacion2,

        //entero/real + entero/real  Expresion125678     ya
        Expresion1,
        //entero/real - entero/real  Expresion125678   ya
        Expresion2,
        //entero/real        ya
        Expresion3,
        //identificador  ya
        Expresion4,
        //entero/real + identificadorExpresion125678   jose
        Expresion5,
        //entero/real - identifcadorExpresion125678  jose
        Expresion6,
        //identificador + identificador Expresion125678   jose
        Expresion7,
        //identificador - identificadorExpresion125678     jose
        Expresion8,
        //identificador++       jose
        Expresion9,
        //identificador--         jose
        Expresion10,

        //regla no existente
        ReglaNoExistente
    }
}
