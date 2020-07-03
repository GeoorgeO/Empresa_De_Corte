using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_TiposEntradas : ConexionBase
    {

        public string Id_TipoEntrada { get; set; }
        public string Nombre_TipoEntrada { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarTiposEntradas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TiposEntradas_Select";

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



        public void MtdInsertarTiposEntradas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TiposEntradas_Insert";
                _dato.CadenaTexto = Id_TipoEntrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoEntrada");
                _dato.CadenaTexto = Nombre_TipoEntrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_TipoEntrada");

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

        public void MtdEliminarTiposEntradas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_TiposEntradas_Delete";
                _dato.CadenaTexto = Id_TipoEntrada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoEntrada");
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
