using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Asignacion2: IInput
    {
        public string TipoDeVariable { get; set; }
        public string Identificador { get; set; }
        public IExpresion Expresion { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Asignacion2(string tipoDeVariable, string identificador, IExpresion expresion, TipoDeRegla tipoDeRegla)
        {
            TipoDeVariable = tipoDeVariable;
            Identificador = identificador;
            Expresion = expresion;
            TipoDeRegla = tipoDeRegla;
        }
    }
}
