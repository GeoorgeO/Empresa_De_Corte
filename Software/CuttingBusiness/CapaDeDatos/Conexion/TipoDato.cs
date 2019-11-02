using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeDatos
{
    public class TipoDato
    {

        public System.Nullable<int> Entero { get; set; }
        public System.String CadenaTexto { get; set; }
        public System.Nullable<DateTime> FechaYHora { get; set; }
        public System.Nullable<decimal> DecimalValor { get; set; }
        public System.Nullable<Boolean> BoleanoValor { get; set; }
        public byte[] ImagenValor { get; set; }
        public System.Nullable<long> EnteroLargo { get; set; }
        public System.Char CaracterValor { get; set; }
    }
}
