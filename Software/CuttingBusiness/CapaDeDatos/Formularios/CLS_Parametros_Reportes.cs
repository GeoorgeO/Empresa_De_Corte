using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Parametros_Reportes: ConexionBase
    {
        public string Id { get; set; }
        public string Tipo_Empleado { get; set; }
        public int Dias_trabajo { get; set; }
        public decimal Sueldo_Bruto { get; set; }
        public decimal ISR { get; set; }
        public decimal Sueldo_Neto { get; set; }


        public void MtdSeleccionarParametrosB()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Reportes_B_Select";
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
        public void MtdSeleccionarParametrosC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Reportes_C_Select";
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
        public void MtdUpdateParametrosB()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Reportes_B_Update";
                _dato.Entero = Dias_trabajo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Dias_trabajo");
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
                _dato.DecimalValor = Sueldo_Bruto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Bruto");
                _dato.CadenaTexto = Id;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id");
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
        public void MtdUpdateParametrosC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Parametros_Reportes_C_Update";
                _dato.Entero = Dias_trabajo;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Dias_trabajo");
                _dato.CadenaTexto = Tipo_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo_Empleado");
                _dato.DecimalValor = Sueldo_Bruto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Bruto");
                _dato.DecimalValor = ISR;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "ISR");
                _dato.DecimalValor = Sueldo_Neto;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Sueldo_Neto");
                _dato.CadenaTexto = Id;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id");
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
