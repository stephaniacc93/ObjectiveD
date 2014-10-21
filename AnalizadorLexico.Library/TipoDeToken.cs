using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Library
{
    //ESTE ENUM ES DE PRUEBA, NO SE SI SE NECESITARA EN LA IMPLEMENTACION
    public enum TipoDeToken
    {
        Identificador,
        Operador,
        Entero,
        Real,
        Rango,
        If,
        Else,
        Elseif,
        While,
        ParentesisInicial,
        ParentesisFinal,
        For,
        Foreach,
        PuntoComa,
        Menor,
        Mayor,
        MenorIgual,
        MayorIgual,
        Diferente,
        Igual,
        LlaveInicial,
        LlaveFinal,
        Incremento,
        Error,
        String,
        IgualIgual,
        Mas,
        In

    }
}
