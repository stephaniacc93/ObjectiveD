using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorLexico
{
    public class Input
    {
        public TipoDeToken tipoDeToken { get; set; }
        public string Lexema { get; set; }
        public int Linea { get; set; }

        public Input(TipoDeToken tipoDeToken, string lexema, int linea)
        {
            this.tipoDeToken = tipoDeToken;
            Lexema = lexema;
            Linea = linea;
        }
    }
}
