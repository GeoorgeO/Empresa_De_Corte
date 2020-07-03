using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_CategoriasCuadrilla : ConexionBase
    {

        public string Id_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarCategoriasCuadrilla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CategoriasCuadrilla_Select";

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

        public void MtdInsertarCategoriasCuadrilla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CategoriasCuadrilla_Insert";
                _dato.CadenaTexto = Id_Categoria;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Categoria");
                _dato.CadenaTexto = Nombre_Categoria;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Categoria");
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

        public void MtdEliminarCategoriasCuadrilla()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CategoriasCuadrilla_Delete";
                _dato.CadenaTexto = Id_Categoria;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Categoria");
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
