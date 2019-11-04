using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_UnidadesMedida : ConexionBase
    {
        public string Id_UnidadMedida { get; set; }
        public string Nombre_UnidadMedida { get; set; }
        public string Abrevia_UnidadMedida { get; set; }

        public void MtdSeleccionarUnidadesMedida()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_UnidadesMedida_Select";

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



        public void MtdInsertarUnidadesMedida()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_UnidadesMedida_Insert";
                _dato.CadenaTexto = Id_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_UnidadMedida");
                _dato.CadenaTexto = Nombre_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_UnidadMedida");
                _dato.CadenaTexto = Abrevia_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Abrevia_UnidadMedida");
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

        public void MtdEliminarUnidadesMedida()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_UnidadesMedida_Delete";
                _dato.CadenaTexto = Id_UnidadMedida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_UnidadMedida");
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
