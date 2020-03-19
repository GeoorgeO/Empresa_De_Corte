using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_ServiciosCortes:ConexionBase
    {
        public string PSC_Fecha { get; set; }
        public string PSC_ODC { get; set; }
        public string PSC_Ubicacion { get; set; }
        public string PSC_Pesada { get; set; }
        public string PSC_Placas { get; set; }
        public string PSC_Huertas { get; set; }
        public string PSC_Productor { get; set; }
        public string PSC_Cajas { get; set; }
        public string PSC_Kilos { get; set; }
        public string PSC_Variedad { get; set; }
        public string PSC_JefeCuadrilla { get; set; }
        public string PSC_CajasZ { get; set; }
        public string PSC_FolioZ { get; set; }
        public string PSC_JefeArea { get; set; }
        public string PSC_ClaveDia { get; set; }
        public string  Fecha_Inicio{ get; set; }
        public string Fecha_Fin { get; set; }

        public void MtdSeleccionarServicioCorteODC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServiciosCortesODC_Select";
                _dato.CadenaTexto = PSC_Fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Fecha");
                _dato.CadenaTexto = PSC_ODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_ODC");
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
        public void MtdSeleccionarServicioCorteODCCont()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServiciosODCCont_Select";
                _dato.CadenaTexto = PSC_ODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_ODC");
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
        public void MtdSeleccionarServicioCorteODC_Fechas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServiciosODC_Select";
                _dato.CadenaTexto = Fecha_Inicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Inicio");
                _dato.CadenaTexto = Fecha_Fin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_Fin");
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
        public void MtdInsertarServiciosCortes()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServiciosCortes_Insert";
                _dato.CadenaTexto = PSC_Fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Fecha");
                _dato.CadenaTexto = PSC_ODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_ODC");
                _dato.CadenaTexto = PSC_Ubicacion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Ubicacion");
                _dato.CadenaTexto = PSC_Pesada;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Pesada");
                _dato.CadenaTexto = PSC_Placas;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Placas");
                _dato.CadenaTexto = PSC_Huertas;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Huertas");
                _dato.CadenaTexto = PSC_Productor;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Productor");
                _dato.CadenaTexto = PSC_Cajas;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Cajas");
                _dato.CadenaTexto = PSC_Kilos;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Kilos");
                _dato.CadenaTexto = PSC_Variedad;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Variedad");
                _dato.CadenaTexto = PSC_JefeCuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_JefeCuadrilla");
                _dato.CadenaTexto = PSC_CajasZ;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_CajasZ");
                _dato.CadenaTexto = PSC_FolioZ;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_FolioZ");
                _dato.CadenaTexto = PSC_JefeArea;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_JefeArea");
                _dato.CadenaTexto = PSC_ClaveDia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_ClaveDia");
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
        public void MtdEliminarServicioCorteODC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServiciosODC_Delete";
                _dato.CadenaTexto = PSC_Fecha;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_Fecha");
                _dato.CadenaTexto = PSC_ODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSC_ODC");
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
