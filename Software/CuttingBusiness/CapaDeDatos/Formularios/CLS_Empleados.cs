using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Formularios
{
    public class CLS_Empleados : ConexionBase
    {

        public string Id_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string NSS { get; set; }
        public string Fecha_Alta_Seg_Social { get; set; }
        public string Fecha_Baja_Seg_Social { get; set; }
        public string Cuenta { get; set; }
        public string Tarjeta { get; set; }
        public string Fecha_Alta_Seg_Vida { get; set; }
        public string Fecha_Baja_Seg_Vida { get; set; }
        public string Id_Puesto { get; set; }
        public string Id_Cuadrilla { get; set; }
        public string Activo { get; set; }

        public void MtdSeleccionarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empleados_Select";
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



        public void MtdInsertarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empleados_Insert";
                _dato.CadenaTexto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Usuario");
                _dato.CadenaTexto = Nombre_Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Usuario");
                _dato.CadenaTexto = Contrasena;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Contrasena");
                _dato.CadenaTexto = Id_Perfil;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Perfil");
                _dato.CadenaTexto = Creador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Creador");
                _dato.CadenaTexto = Modificador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Modificador");
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

        public void MtdEliminarUsuarios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empleados_Delete";
                _dato.CadenaTexto = Id_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empleado");
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
