using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico.Expresiones
{
    public class Expresion125678: IExpresion
    {
        public string Variable1 { get; set; }
        public string Operador { get; set; }
        public string Variable2 { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Expresion125678(string variable1, string operador, string variable2, TipoDeRegla tipoDeRegla)
        {
            Variable1 = variable1;
            Operador = operador;
            Variable2 = variable2;
            TipoDeRegla = tipoDeRegla;  
        }
    }
}
