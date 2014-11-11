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
        //if(identificador igualigual string) -ya
        If5,

        //else(identificador operador identificador)   -ya
        Else1,
        //else(identificador operador entero/real)    -ya
        Else2,
        //else(entero/real operador identificador)     -ya
        Else3,
        //else(entero/real operador entero/real)       -ya
        Else4,
        //else(identificador igualigual string) -ya
        Else5,

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

        //while(identificador operador identificador)     -ya
        While1,
        //while(identificador operador entero/real)     -ya
        While2,
        //while(entero/real operador identificador)    -ya
        While3,
        //while(entero/real operador entero/real)  -ya
        While4,

        // for ( tipo de variable identificador igual entero; identificador operador variable; identificador ++)     -ya
        For1,
        //  for ( tipo de variable identificador igual entero; identificador operador variable; identificador--)    -ya
        For2,
        //  for (tipo de variable identificador igual identificador; identificador operador identificador; identificador++)     -ya
        For3,
        //  for (tipo de variable identificador igual identificador; identificador operador identificador; identificador--)      -ya
        For4,

        //foreach(tipo de variable identificador in identificador)   -ya
        Foreach,

        //identificador = expresion   omar ? pendiente por falta de saber que es expresion
        Asignacion,

        //entero/real + entero/real       ya
        Expresion1,
        //entero/real - entero/real     ya
        Expresion2,
        //entero/real        ya
        Expresion3,
        //identificador  ya
        Expresion4,
        //entero/real + identificador   jose
        Expresion5,
        //entero/real - identifcador  jose
        Expresion6,
        //identificador + identificador    jose
        Expresion7,
        //identificador - identificador     jose
        Expresion8,
        //identificador++       jose
        Expresion9,
        //identificador--         jose
        Expresion10,

        //regla no existente
        ReglaNoExistente
    }
}
