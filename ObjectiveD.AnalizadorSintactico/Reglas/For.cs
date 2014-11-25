using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class For: IInput
    {
        public string Identificador { get; set; }
        public string Operator1 { get; set; }
        public string Value1 { get; set; }
        public string Operator2 { get; set; }
        public string Value2 { get; set; }
        public bool EsSumante { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public For(string identificador, string operator1, string value1, string operator2, string value2, bool esSumante, TipoDeRegla tipoDeRegla)
        {
            Identificador = identificador;
            Operator1 = operator1;
            Value1 = value1;
            Operator2 = operator2;
            Value2 = value2;
            EsSumante = esSumante;
            TipoDeRegla = tipoDeRegla;  
        }

    }
}
