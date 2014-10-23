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
        String,
        IgualIgual,
        Mas,
        In,
        Error

    }
}
