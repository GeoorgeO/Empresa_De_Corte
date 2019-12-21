using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Salidas : ConexionBase
    {

        // Encabezado de la salida

        public string Id_JefeCuadrilla { get; set; }
        public string Id_TipoSalida { get; set; }
        public string Fecha_Salida { get; set; }
        public int Numero_Articulossalida { get; set; }

        // Detalles de la salida
        public string Serie_Salida { get; set; }
        public string Folio_Salida { get; set; }
        public int Registro_SalidaDetalles { get; set; }
        public string Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Nombre_UnidadMedida { get; set; }
        public int Cantidad_SalidaDetalles { get; set; }
        public decimal Precio_SalidaDetalles { get; set; }
        public decimal Total_SalidaDetalles { get; set; }
        public string Observaciones_SalidaDetalles { get; set; }

        
        

        public void MtdSeleccionarSalidasEncabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Salidas_Select";

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

        public void MtdSeleccionarJefeCuadrillas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_JefeCuadrillas_Select";

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

        public void MtdInsertarSalidasEncabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_SalidasEncabezado_Insert";
                _dato.CadenaTexto = Serie_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Salida");
                _dato.CadenaTexto = Id_JefeCuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_JefeCuadrilla");
                _dato.CadenaTexto = Id_TipoSalida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoSalida");
                _dato.CadenaTexto = Fecha_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Salida");
                _dato.Entero = Numero_Articulossalida;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Numero_Articulossalida");
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

        

        public void MtdAfectarInventario()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_SalidasInventario_Update";
                _dato.CadenaTexto = Folio_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Salida");
                _dato.CadenaTexto = Serie_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Salida");
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
                _dato.Entero = Cantidad_SalidaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cantidad_SalidaDetalles");
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

        public void MtdSeleccionarSalidasDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_SalidasDetalles_Select";
                _dato.CadenaTexto = Folio_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Salida");
                _dato.CadenaTexto = Serie_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Salida");
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

        public void MtdInsertarSalidasDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_SalidasDetalles_Insert";
                _dato.CadenaTexto = Folio_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Salida");
                _dato.CadenaTexto = Serie_Salida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Salida");
                _dato.Entero = Registro_SalidaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Registro_SalidaDetalles");
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
                _dato.CadenaTexto = Nombre_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Producto");
                _dato.CadenaTexto = Nombre_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_UnidadMedida");
                _dato.Entero = Cantidad_SalidaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cantidad_SalidaDetalles");
                _dato.DecimalValor = Convert.ToDecimal(Precio_SalidaDetalles);
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_SalidaDetalles");
                _dato.DecimalValor = Convert.ToDecimal(Total_SalidaDetalles);
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Total_SalidaDetalles");
                _dato.CadenaTexto = Observaciones_SalidaDetalles;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Observaciones_SalidaDetalles");
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
