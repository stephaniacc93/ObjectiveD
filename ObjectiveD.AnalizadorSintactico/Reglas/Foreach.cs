using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Foreach: IInput
    {
        public string TipoDeVariable { get; set; }
        public string Identificador { get; set; }
        public string List { get; set; }
        public TipoDeRegla TipoDeRegla { get; set; }

        public Foreach(string tipoDeVariable, string identificador, string list, TipoDeRegla tipoDeRegla)
        {
            TipoDeVariable = tipoDeVariable;
            Identificador = identificador;
            List = list;
            TipoDeRegla = tipoDeRegla;  
        }
    }
}
