using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Entradas : ConexionBase
    {
        // Encabezado de la entrada

        public string Id_Proveedor { get; set; }
        public string Id_TipoEntrada { get; set; }
        public string Fecha_Entrada { get; set; }
        public int Numero_ArticulosEntrada { get; set; }

        // Detalles de la entrada
        public string Serie_Entrada { get; set; }
        public string Folio_Entrada { get; set; }
        public int Registro_EntradaDetalles { get; set; }
        public string Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Nombre_UnidadMedida { get; set; }
        public int Cantidad_EntradaDetalles { get; set; }
        public decimal Precio_EntradaDetalles { get; set; }
        public decimal Total_EntradaDetalles { get; set; }
        public string Observaciones_EntradaDetalles { get; set; }





        public void MtdSeleccionarEntradaEncabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Entradas_Select";

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

        public void MtdInsertarEntradaEncabezado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_EntradaEncabezado_Insert";
                _dato.CadenaTexto = Serie_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Entrada");
                _dato.CadenaTexto = Id_Proveedor;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Proveedor");
                _dato.CadenaTexto = Id_TipoEntrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoEntrada");
                _dato.CadenaTexto = Fecha_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Entrada");
                _dato.Entero = Numero_ArticulosEntrada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Numero_ArticulosEntrada");
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
                _conexion.NombreProcedimiento = "SP_EntradaInventario_Update";
                _dato.CadenaTexto = Folio_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Entrada");
                _dato.CadenaTexto = Serie_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Entrada");
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
                _dato.Entero = Cantidad_EntradaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cantidad_EntradaDetalles");
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

        public void MtdSeleccionarEntradaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_EntradaDetalles_Select";
                _dato.CadenaTexto = Folio_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Entrada");
                _dato.CadenaTexto = Serie_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Entrada");
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

        public void MtdInsertarEntradaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_EntradaDetalles_Insert";
                _dato.CadenaTexto = Folio_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Entrada");
                _dato.CadenaTexto = Serie_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Entrada");
                _dato.Entero = Registro_EntradaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Registro_EntradaDetalles");
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
                _dato.CadenaTexto = Nombre_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Producto");
                _dato.CadenaTexto = Nombre_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_UnidadMedida");
                _dato.Entero = Cantidad_EntradaDetalles;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Cantidad_EntradaDetalles");
                _dato.DecimalValor = Convert.ToDecimal(Precio_EntradaDetalles);
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_EntradaDetalles");
                _dato.DecimalValor = Convert.ToDecimal(Total_EntradaDetalles);
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Total_EntradaDetalles");
                _dato.CadenaTexto = Observaciones_EntradaDetalles;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Observaciones_EntradaDetalles");
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

        public void MtdEliminarEntradaDetalles()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_EntradaDetalles_Delete";
                _dato.CadenaTexto = Folio_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Folio_Entrada");
                _dato.CadenaTexto = Serie_Entrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Serie_Entrada");
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
