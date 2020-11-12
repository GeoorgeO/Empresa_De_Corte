using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Domicilios : ConexionBase
    {
        public string Id_Domicilio { get; set; }
        public string Calle { get; set; }
        public string NoInterior { get; set; }
        public string NoExterior { get; set; }
        public string Colonia { get; set; }
        public string Codigo_Postal { get; set; }
        public string Id_Ciudad { get; set; }
        public string Id_TipoDomicilio { get; set; }
        public string Id_Empleado { get; set; }
        public string id_TipoPersona { get; set; }
        public string Usuario { get; set; }

        public void MtdSeleccionarDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Domicilio_Select";
                _dato.CadenaTexto = Id_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empleado");
                _dato.CadenaTexto = id_TipoPersona;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "id_TipoPersona");
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
        public void MtdInsertarDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Domicilio_Insert";
                _dato.CadenaTexto = Id_Domicilio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Domicilio");
                _dato.CadenaTexto = Calle;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Calle");
                _dato.CadenaTexto = NoInterior;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "NoInterior");
                _dato.CadenaTexto = NoExterior;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "NoExterior");
                _dato.CadenaTexto = Colonia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Colonia");
                _dato.CadenaTexto = Codigo_Postal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Codigo_Postal");
                _dato.CadenaTexto = Id_Ciudad;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Ciudad");
                _dato.CadenaTexto = Id_TipoDomicilio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoDomicilio");
                _dato.CadenaTexto = Id_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Persona");
                _dato.CadenaTexto = id_TipoPersona;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "id_TipoPersona");
                _dato.CadenaTexto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Usuario");
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
        public void MtdEliminarDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Domicilio_Delete";
                _dato.CadenaTexto = Id_Domicilio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Domicilio");
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
        public void MtdEliminarDomicilioPersona()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_DomicilioPersona_Delete";
                _dato.CadenaTexto = Id_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empleado");
                _dato.CadenaTexto = id_TipoPersona;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "id_TipoPersona");
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
