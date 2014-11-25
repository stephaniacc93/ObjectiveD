using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico.Expresiones
{
    public class Expresion34 :IExpresion
    {
        public string Value { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Expresion34(string value, TipoDeRegla tipoDeRegla)
        {
            Value = value;
            TipoDeRegla = tipoDeRegla;
        }
    }
}
