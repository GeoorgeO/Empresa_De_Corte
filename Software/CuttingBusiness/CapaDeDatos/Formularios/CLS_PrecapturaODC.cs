using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_PrecapturaODC : ConexionBase
    {

        public string Id_PrecapturaODC { get; set; }
        public string Id_JefeCuadrilla { get; set; }
        public string Id_Huerta { get; set; }
        public string Transportista { get; set; }
        public string Placas { get; set; }
        public string Candado { get; set; }
        public string ODC { get; set; }
        public string Id_TipoCorte { get; set; }
        public string PSobreBanda { get; set; }
        public string Precio { get; set; }
        public string Empaque { get; set; }
        public string JefeArea { get; set; }

        public void MtdSeleccionarPrecapturaODC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_PrecapturaODC_Select";

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



        public void MtdInsertarPrecapturaODC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_PrecapturaODC_Insert";
                _dato.CadenaTexto = Id_PrecapturaODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_PrecapturaODC");
                _dato.CadenaTexto = Id_JefeCuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_JefeCuadrilla");
                _dato.CadenaTexto = Id_Huerta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Huerta");
                _dato.CadenaTexto = Transportista;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Transportista");
                _dato.CadenaTexto = Placas;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Placas");
                _dato.CadenaTexto = Candado;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Candado");
                _dato.CadenaTexto = ODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "ODC");
                _dato.CadenaTexto = Id_TipoCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_TipoCorte");
                _dato.CadenaTexto = PSobreBanda;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "PSobreBanda");
                _dato.CadenaTexto = Precio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Precio");
                _dato.CadenaTexto = Empaque;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Empaque");
                _dato.CadenaTexto = JefeArea;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "JefeArea");
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

        public void MtdEliminarPrecapturaODC()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_PrecapturaODC_Delete";
                _dato.CadenaTexto = Id_PrecapturaODC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_PrecapturaODC");
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
