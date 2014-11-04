using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorLexico
{
    public enum TipoDeToken
    {
        Identificador,
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
        Decremento,
        String,
        IgualIgual,
        Mas,
        Menos,
        In,
        Error,
        Integer,
        Double,
        TipoString
    }
}
