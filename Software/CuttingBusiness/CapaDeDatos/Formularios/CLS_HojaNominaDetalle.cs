using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_HojaNominaDetalle : ConexionBase
    {

        public string Id_HojaNomina { get; set; }
        public string Id_secuencia { get; set; }
        public string Id_empleado { get; set; }
        public decimal Cajas { get; set; }
        public decimal Importe { get; set; }

        public void MtdInsertarHojaNominaDetalle()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNominaDetalle_Insert";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
                _dato.CadenaTexto = Id_secuencia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_secuencia");
                _dato.CadenaTexto = Id_empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_empleado");
                _dato.DecimalValor = Cajas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Cajas");
                _dato.DecimalValor = Importe;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Importe");
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

        public void MtdSeleccionarHojaNominaDetalle()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNominaDetalle_Select";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
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

        public void MtdEliminarHojaNominaDetalle()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNominaDetalle_Delete";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
                _dato.CadenaTexto = Id_secuencia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_secuencia");
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
