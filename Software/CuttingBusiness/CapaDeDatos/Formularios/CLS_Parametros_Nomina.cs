using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Parametros_Nomina : ConexionBase
    {

        public decimal Dias_trabajo { get; set; }
        public string Tipo_Empleado { get; set; }
        public decimal Sueldo_Bruto { get; set; }
        public decimal ISR { get; set; }
        public decimal Sueldo_Neto { get; set; }
        public int elimina { get; set; }

        public void MtdSeleccionarParametrosB()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Nomina_B_Select";
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
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

        public void MtdInsertarParametrosB()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Nomina_B_Insert";
                _dato.DecimalValor = Dias_trabajo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Dias_trabajo");
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
                _dato.DecimalValor = Sueldo_Bruto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Bruto");
                _dato.Entero = elimina;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "elimina");
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

        public void MtdSeleccionarParametrosC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Nomina_C_Select";
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
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

        public void MtdInsertarParametrosC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Nomina_C_Insert";
                _dato.DecimalValor = Dias_trabajo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Dias_trabajo");
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
                _dato.DecimalValor = Sueldo_Bruto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Bruto");
                _dato.DecimalValor = ISR;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ISR");
                _dato.DecimalValor = Sueldo_Neto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Neto");
                _dato.Entero = elimina;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "elimina");
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
