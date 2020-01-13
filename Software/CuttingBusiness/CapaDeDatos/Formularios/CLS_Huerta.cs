using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Huerta : ConexionBase
    {

        public string Id_Huerta { get; set; }
        public string Nombre_Huerta { get; set; }
        public string Registro_Huerta { get; set; }
        public string Id_Duenio { get; set; }
        public string Id_Estado { get; set; }
        public string Id_Ciudad { get; set; }
        public string Id_Calidad { get; set; }
        public string Id_Cultivo { get; set; }
        public decimal zona_Huerta { get; set; }
        public string banda_Huerta { get; set; }
        public decimal este_Huerta { get; set; }
        public decimal norte_Huerta { get; set; }
        public decimal asnm_Huerta { get; set; }
        public decimal latitud_Huerta { get; set; }
        public decimal longitud_Huerta { get; set; }
        public string Activo { get; set; }


        public void MtdSeleccionarHuerta()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Huerta_Select";
                _dato.CadenaTexto = Activo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Activo");
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
        public void MtdInsertarHuerta()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Huerta_Insert";
                _dato.CadenaTexto = Id_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Huerta");
                _dato.CadenaTexto = Nombre_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Huerta");
                _dato.CadenaTexto = Registro_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Registro_Huerta");
                _dato.CadenaTexto = Id_Duenio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Duenio");
                _dato.CadenaTexto = Id_Estado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Estado");
                _dato.CadenaTexto = Id_Ciudad;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Ciudad");
                _dato.CadenaTexto = Id_Calidad;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Calidad");
                _dato.CadenaTexto = Id_Cultivo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Cultivo");
                _dato.DecimalValor = zona_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "zona_Huerta");
                _dato.CadenaTexto = banda_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "banda_Huerta");
                _dato.DecimalValor = este_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "este_Huerta");
                _dato.DecimalValor = norte_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "norte_Huerta");
                _dato.DecimalValor = asnm_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "asnm_Huerta");
                _dato.DecimalValor = latitud_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "latitud_Huerta");
                _dato.DecimalValor = longitud_Huerta;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "longitud_Huerta");
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
        public void MtdEliminarHuerta()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Huerta_Delete";
                _dato.CadenaTexto = Id_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Huerta");
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
