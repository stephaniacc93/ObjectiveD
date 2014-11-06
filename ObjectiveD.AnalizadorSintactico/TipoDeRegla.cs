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

        // REVISAR for ( tipo de variable identificador igual entero/real; identificador operador variable; identificador ++)
        For1,
        // REVISAR for ( tipo de variable identificador igual entero/real; identificador operador variable; identificador--)
        For2,
        // REVISAR for (tipo de variable identificador igual identificador; identificador operador identificador; identificador++)
        For3,
        // REVISAR for (tipo de variable identificador igual identificador; identificador operador identificador; identificador--)
        For4,

        //foreach(tipo de variable identificador in identificador)   omar
        Foreach,

        //identificador = expresion   omar
        Asignacion,

        //entero/real + entero/real       omar
        Expresion1,
        //entero/real - entero/real     omar
        Expresion2,
        //entero/real        omar
        Expresion3,
        //identificador  omar
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
