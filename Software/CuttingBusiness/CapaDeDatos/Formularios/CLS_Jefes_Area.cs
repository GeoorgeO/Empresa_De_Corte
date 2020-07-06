using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Jefes_Area : ConexionBase
    {

        public string Id_Jefe_Area { get; set; }
        public string Nombre_Jefe_Area { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarJefes_Area()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Jefes_Area_Select";

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

        public void MtdInsertarJefes_Area()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Jefes_Area_Insert";
                _dato.CadenaTexto = Id_Jefe_Area;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Jefe_Area");
                _dato.CadenaTexto = Nombre_Jefe_Area;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Jefe_Area");

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

        public void MtdEliminarJefes_Area()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Jefes_Area_Delete";
                _dato.CadenaTexto = Id_Jefe_Area;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Jefe_Area");
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
