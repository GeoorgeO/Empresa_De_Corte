using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Parametros : ConexionBase
    {
        public string Id_Parametro { get; set; }
        public decimal Pago_x_Dia_Mission { get; set; }
        public decimal Pago_x_Dia { get; set; }
        public decimal N_Cortadores_Mission { get; set; }
        public decimal N_Cortadores { get; set; }
        public decimal Tope_Pago_Mission { get; set; }
        public decimal Tope_Pago { get; set; }
        public decimal Lim_Inf_Cort { get; set; }
        public decimal Lim_Sup_Cort { get; set; }
        public decimal Pago_x_caja { get; set; }
        public decimal Pago_x_caja_Inf { get; set; }
        public decimal Pago_x_caja_Sup { get; set; }
        public decimal Kg_x_Dia_Inf_1 { get; set; }
        public decimal Kg_x_Dia_Sup_1 { get; set; }
        public decimal Pago_Inf_1 { get; set; }
        public decimal Pago_Sup_1 { get; set; }
        public decimal Pago_Inf_1_Mission { get; set; }
        public decimal Pago_Sup_1_Mission { get; set; }
        public decimal Kg_x_Dia_Inf_2 { get; set; }
        public decimal Kg_x_Dia_Sup_2 { get; set; }
        public decimal Pago_Inf_2 { get; set; }
        public decimal Pago_Sup_2 { get; set; }
        public decimal Pago_Inf_2_Mission { get; set; }
        public decimal Pago_Sup_2_Mission { get; set; }
        public decimal Kg_x_Dia_Inf_3 { get; set; }
        public decimal Kg_x_Dia_Sup_3 { get; set; }
        public decimal Pago_Inf_3 { get; set; }
        public decimal Pago_Sup_3 { get; set; }
        public decimal Pago_Inf_3_Mission { get; set; }
        public decimal Pago_Sup_3_Mission { get; set; }
        public string Id_Tipo { get; set; }

        public void MtdSeleccionarParametros()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Select";
                _dato.CadenaTexto = Id_Tipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Tipo");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

        public void MtdInsertarParametros()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Insert";
                _dato.CadenaTexto = Id_Parametro;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Parametro");
                _dato.DecimalValor = Pago_x_Dia_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_x_Dia_Mission");
                _dato.DecimalValor = Pago_x_Dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_x_Dia");
                _dato.DecimalValor = N_Cortadores_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "N_Cortadores_Mission");
                _dato.DecimalValor = N_Cortadores;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "N_Cortadores");
                _dato.DecimalValor = Tope_Pago_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Tope_Pago_Mission");
                _dato.DecimalValor = Tope_Pago;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Tope_Pago");
                _dato.DecimalValor = Lim_Inf_Cort;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Lim_Inf_Cort");
                _dato.DecimalValor = Lim_Sup_Cort;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Lim_Sup_Cort");
                _dato.DecimalValor = Pago_x_caja;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_x_caja");
                _dato.DecimalValor = Pago_x_caja_Inf;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_x_caja_Inf");
                _dato.DecimalValor = Pago_x_caja_Sup;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_x_caja_Sup");
                _dato.DecimalValor = Kg_x_Dia_Inf_1;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Inf_1");
                _dato.DecimalValor = Kg_x_Dia_Sup_1;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Sup_1");
                _dato.DecimalValor = Pago_Inf_1;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_1");
                _dato.DecimalValor = Pago_Sup_1;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_1");
                _dato.DecimalValor = Pago_Inf_1_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_1_Mission");
                _dato.DecimalValor = Pago_Sup_1_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_1_Mission");
                _dato.DecimalValor = Kg_x_Dia_Inf_2;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Inf_2");
                _dato.DecimalValor = Kg_x_Dia_Sup_2;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Sup_2");
                _dato.DecimalValor = Pago_Inf_2;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_2");
                _dato.DecimalValor = Pago_Sup_2;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_2");
                _dato.DecimalValor = Pago_Inf_2_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_2_Mission");
                _dato.DecimalValor = Pago_Sup_2_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_2_Mission");
                _dato.DecimalValor = Kg_x_Dia_Inf_3;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Inf_3");
                _dato.DecimalValor = Kg_x_Dia_Sup_3;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kg_x_Dia_Sup_3");
                _dato.DecimalValor = Pago_Inf_3;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_3");
                _dato.DecimalValor = Pago_Sup_3;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_3");
                _dato.DecimalValor = Pago_Inf_3_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Inf_3_Mission");
                _dato.DecimalValor = Pago_Sup_3_Mission;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Sup_3_Mission");
                _dato.CadenaTexto = Id_Tipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Tipo");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

    }
}
