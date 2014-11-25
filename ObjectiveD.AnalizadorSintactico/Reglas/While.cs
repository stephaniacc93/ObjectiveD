using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class While: IInput
    {
        public string FirstField { get; set; }
        public string Operator { get; set; }
        public string SecondField { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public While(string firstField, string @operator, string secondField, TipoDeRegla tipoDeRegla)
        {
            FirstField = firstField;
            Operator = @operator;
            SecondField = secondField;
            TipoDeRegla = tipoDeRegla;  
        }
    }
}
