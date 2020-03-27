using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
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

        public void MtdSeleccionarEmpleados()
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



        public void MtdInsertarEmpleados()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empleados_Insert";
                _dato.CadenaTexto = Id_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empleado");
                _dato.CadenaTexto = Nombre_Empleado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Empleado");
                _dato.CadenaTexto = Fecha_Nacimiento;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Nacimiento");
                _dato.CadenaTexto = NSS;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "NSS");
                _dato.CadenaTexto = Fecha_Alta_Seg_Social;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Alta_Seg_Social");
                _dato.CadenaTexto = Fecha_Baja_Seg_Social;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Baja_Seg_Social");
                _dato.CadenaTexto = Cuenta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Cuenta");
                _dato.CadenaTexto = Tarjeta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tarjeta");
                _dato.CadenaTexto = Fecha_Alta_Seg_Vida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Alta_Seg_Vida");
                _dato.CadenaTexto = Fecha_Baja_Seg_Vida;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Baja_Seg_Vida");
                _dato.CadenaTexto = Id_Puesto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Puesto");
                _dato.CadenaTexto = Id_Cuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Cuadrilla");
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

        public void MtdEliminarEmpleados()
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

        public void MtdSeleccionarPuestoEmpleado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_PuestoEmpleado_Select";
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
