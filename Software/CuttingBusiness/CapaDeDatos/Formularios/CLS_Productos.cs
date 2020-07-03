using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Productos : ConexionBase
    {

        public string Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Id_UnidadMedida { get; set; }
        public string Inventariable { get; set; }
        public int Stock_Min { get; set; }
        public int Stock_Max { get; set; }
        public string Anaquel { get; set; }
        public string Pasillo { get; set; }
        public string Repisa { get; set; }
        public int Stock { get; set; }
        public string Activo { get; set; }
        public string Id_ProductoTipo { get; set; }
        public string Id_Marca { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarProductos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Productos_Select";
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
        public void MtdSeleccionarProductosId()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ProductosId_Select";
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
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



        public void MtdInsertarProductos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Productos_Insert";
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
                _dato.CadenaTexto = Nombre_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Producto");
                _dato.CadenaTexto = Id_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_UnidadMedida");
                _dato.CadenaTexto = Inventariable;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Inventariable");
                _dato.Entero = Stock_Min;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Stock_Min");
                _dato.Entero = Stock_Max;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Stock_Max");
                _dato.CadenaTexto = Anaquel;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Anaquel");
                _dato.CadenaTexto = Pasillo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Pasillo");
                _dato.CadenaTexto = Repisa;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Repisa");
                _dato.CadenaTexto = Id_ProductoTipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_ProductoTipo");
                _dato.CadenaTexto = Id_Marca;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Marca");

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

        public void MtdEliminarProductos()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Productos_Delete";
                _dato.CadenaTexto = Id_Producto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Producto");
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
