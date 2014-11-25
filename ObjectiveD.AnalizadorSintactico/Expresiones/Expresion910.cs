using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico.Expresiones
{
    public class Expresion910 : IExpresion
    {
        public string Value { get; set; }
        public bool esSumante { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Expresion910(string value, bool esSumante, TipoDeRegla tipoDeRegla)
        {
            Value = value;
            this.esSumante = esSumante;
            TipoDeRegla = tipoDeRegla;
        }
    }
}
