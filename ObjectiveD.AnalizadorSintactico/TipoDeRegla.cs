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
        //if(identificador operador variable) stephania
        If2,
        //if(variable operador identificador)   stephania
        If3,
        //if(variable operador variable)    stephania
        If4,

        //else(identificador operador identificador)   stephania
        Else1,
        //else(identificador operador variable)    stephania
        Else2,
        //else(variable operador identificador)     stephania
        Else3,
        //else(variable operador variable)       stephania
        Else4,

        //elseif(identificador operador identificador)     sara
        Elseif1,
        //elseif(identificador operador variable)   sara
        Elseif2,
        //elseif(variable operador identificador)    sara
        Elseif3,
        //elseif(variable operador variable)    sara
        Elseif4,

        //while(identificador operador identificador)     sara
        While1,
        //while(identificador operador variable)     sara
        While2,
        //while(variable operador identificador)    sara
        While3,
        //while(variable operador variable)   sara
        While4,

        //for ( tipo de variable identificador operador variable; identificador operador variable; variable ++)   omar
        For1,
        //for ( tipo de variable identificador operador variable; identificador operador variable; variable--)   omar
        For2,
        //for (tipo de variable identificador operador identificador; identificador operador identificador; identificador++)    omar
        For3,
        //for (tipo de variable identificador operador identificador; identificador operador identificador; identificador--)     omar
        For4,

        //foreach(tipo de variable identificador in identificador)   omar
        Foreach,

        //identificador = expresion   omar
        Asignacion,

        //variable + variable       omar
        Expresion1,
        //variable - variable     omar
        Expresion2,
        //variable        jose
        Expresion3,
        //identificador  jose
        Expresion4,
        //variable + identificador   jose
        Expresion5,
        //variable - identifcador  jose
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
