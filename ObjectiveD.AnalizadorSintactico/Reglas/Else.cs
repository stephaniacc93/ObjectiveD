using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveD.AnalizadorSintactico
{
    public class Else: IInput
    {

        public TipoDeRegla TipoDeRegla { get; set; }

        public Else(TipoDeRegla tipoDeRegla)
        {
            TipoDeRegla = tipoDeRegla;  
        }
    }
}
