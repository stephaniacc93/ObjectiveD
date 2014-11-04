using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public enum TipoDeRegla
    {
        //if(identificador operador identificador) stephania
        If1,
        //if(identificador operador entero/real) stephania
        If2,
        //if(entero/real operador identificador)   stephania
        If3,
        //if(entero/real operador entero/real)    stephania
        If4,
        //if(identificador igualigual string) stephania
        If5,

        //else(identificador operador identificador)   stephania
        Else1,
        //else(identificador operador entero/real)    stephania
        Else2,
        //else(entero/real operador identificador)     stephania
        Else3,
        //else(entero/real operador entero/real)       stephania
        Else4,
        //else(identificador igualigual string) stephania
        Else5,

        //elseif(identificador operador identificador)     sara
        Elseif1,
        //elseif(identificador operador entero/real)   sara
        Elseif2,
        //elseif(entero/real operador identificador)    sara
        Elseif3,
        //elseif(entero/real operador entero/real)    sara
        Elseif4,
        //elseif(identificador igualigual string) sara
        ElseIf5,

        //while(identificador operador identificador)     sara
        While1,
        //while(identificador operador entero/real)     sara
        While2,
        //while(entero/real operador identificador)    sara
        While3,
        //while(entero/real operador entero/real)   sara
        While4,

        //for ( tipo de variable identificador operador entero/real; identificador operador variable; variable ++)   omar
        For1,
        //for ( tipo de variable identificador operador entero/real; identificador operador variable; variable--)   omar
        For2,
        //for (tipo de variable identificador operador identificador; identificador operador identificador; identificador++)    omar
        For3,
        //for (tipo de variable identificador operador identificador; identificador operador identificador; identificador--)     omar
        For4,

        //foreach(tipo de variable identificador in identificador)   omar
        Foreach,

        //identificador = expresion   omar
        Asignacion,

        //entero/real + entero/real       omar
        Expresion1,
        //entero/real - entero/real     omar
        Expresion2,
        //entero/real        jose
        Expresion3,
        //identificador  jose
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
