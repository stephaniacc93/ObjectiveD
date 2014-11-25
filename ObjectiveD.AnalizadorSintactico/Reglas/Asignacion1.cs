using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Asignacion1 : IInput
    {
        public string Identificador { get; set; }
        public IExpresion Expresion { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Asignacion1(string identificador, IExpresion expresion, TipoDeRegla tipoDeRegla)
        {
            Identificador = identificador;
            Expresion = expresion;
            TipoDeRegla = tipoDeRegla;
        }
    }
}
