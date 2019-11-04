using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace TransportBusiness
{
    class Validar_Campos
    {
        public string CadenaValida { get; set; }
        public void Valida_Numeros(object sender, KeyEventArgs e, string Cadena)
        {
            int valor = Cadena.IndexOf(".");
            int valor1 = Cadena.IndexOf("-");
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) e.SuppressKeyPress = false; // 0-9
            else if (e.Shift && e.KeyValue == 187) e.SuppressKeyPress = false; // +
            else if (e.KeyValue == 46 || e.KeyValue == 8) e.SuppressKeyPress = false; // DEL and BackSpace
            else if (e.KeyValue == 37 || e.KeyValue == 39) e.SuppressKeyPress = false; // Left/Right Arrow
            else if (e.KeyValue == 110 && valor < 0) e.SuppressKeyPress = false; // Left/Right Arrow
            else if (e.KeyValue == 190 && valor > 0) e.SuppressKeyPress = true; // .
            else if (e.KeyValue == 190 && valor < 0) e.SuppressKeyPress = false; // .
            else if (e.KeyValue == 189 && valor > 0) e.SuppressKeyPress = true; // -
            else if ((e.KeyValue == 109 || e.KeyValue == 189) && valor1 < 0) e.SuppressKeyPress = false; // -
            else e.SuppressKeyPress = true;
        }
        public void Solo_Numeros(object sender, KeyEventArgs e, string Cadena)
        {
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) e.SuppressKeyPress = false; // 0-9
            else if (e.Shift && e.KeyValue == 187) e.SuppressKeyPress = false; // +
            else if (e.KeyValue == 46 || e.KeyValue == 8) e.SuppressKeyPress = false; // DEL and BackSpace
            else if (e.KeyValue == 37 || e.KeyValue == 39) e.SuppressKeyPress = false; // Left/Right Arrow
            else e.SuppressKeyPress = true;
        }
        public void Solo_NumerosLetras(object sender, KeyEventArgs e, string Cadena)
        {
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) e.SuppressKeyPress = false; // 0-9
            else if ((e.KeyValue >= 65 && e.KeyValue <= 90)) e.SuppressKeyPress = false; // A-Z
            else if (e.KeyValue == 46 || e.KeyValue == 8) e.SuppressKeyPress = false; // DEL and BackSpace
            else if (e.KeyValue == 37 || e.KeyValue == 39) e.SuppressKeyPress = false; // Left/Right Arrow
            else if (e.KeyValue == 13) e.SuppressKeyPress = false; // Left/Right Arrow
            else e.SuppressKeyPress = true;
        }
        public void Valida_Simbolos(object sender, KeyEventArgs e, string Cadena)
        {
            if (e.KeyValue == 219) e.SuppressKeyPress = true; // '
        }
        public void Valida_Letras(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >= 65 && e.KeyValue <= 90) e.SuppressKeyPress = false; // A-Z
            else if (e.KeyValue == 192) e.SuppressKeyPress = false; // ñ
            else if (e.KeyValue == 32) e.SuppressKeyPress = false; // space
            else if (e.KeyValue == 46 || e.KeyValue == 8) e.SuppressKeyPress = false; // DEL and BackSpace
            else if (e.KeyValue == 37 || e.KeyValue == 39) e.SuppressKeyPress = false; // Left/Right Arrow
            else if (e.KeyValue == 186) e.SuppressKeyPress = false; // asento
            else e.SuppressKeyPress = true;
        }
        public void Valida_Correo(object sender, KeyPressEventArgs e)
        {
            string Cadena = "-_.@abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890" + (char)8;
            if (!Cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        public void Valida_Campo(object sender, KeyPressEventArgs e)
        {
            string Cadena = CadenaValida + (char)8;
            if (!Cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
