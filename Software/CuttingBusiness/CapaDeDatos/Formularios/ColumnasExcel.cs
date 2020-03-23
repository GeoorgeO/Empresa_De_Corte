using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{

    public class ColumnasExcel : ConexionBase
    {
        public int Row_PSC_Inicio { get; set; }
        public int Col_PSC_Fecha { get; set; }
        public int Col_PSC_ODC { get; set; }
        public int Col_PSC_Ubicacion { get; set; }
        public int Col_PSC_Pesada { get; set; }
        public int Col_PSC_Placas { get; set; }
        public int Col_PSC_Huertas { get; set; }
        public int Col_PSC_Productor { get; set; }
        public int Col_PSC_Cajas { get; set; }
        public int Col_PSC_Kilos { get; set; }
        public int Col_PSC_Variedad { get; set; }
        public int Col_PSC_JefeCuadrilla { get; set; }
        public int Col_PSC_CajasZ { get; set; }
        public int Col_PSC_FolioZ { get; set; }
        public int Col_PSC_JefeArea { get; set; }
        
        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            this.Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServicioCortesColumnas_Select";
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    this.Datos = _conexion.Datos;
                }
                else
                {
                    this.Mensaje = _conexion.Mensaje;
                    this.Exito = false;


                }
            }
            catch (Exception e)
            {
                this.Mensaje = e.Message;
                this.Exito = false;
            }


        }

        public void MtdModificar()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            this.Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ServicioCortesColumnas_Update";
                _dato.Entero = this.Col_PSC_Fecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Fecha");
                _dato.Entero = this.Col_PSC_ODC;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_ODC");
                _dato.Entero = this.Row_PSC_Inicio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Row_PSC_Inicio");
                _dato.Entero = this.Col_PSC_Ubicacion;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Ubicacion");
                _dato.Entero = this.Col_PSC_Pesada;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Pesada");
                _dato.Entero = this.Col_PSC_Placas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Placas");
                _dato.Entero = this.Col_PSC_Huertas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Huertas");
                _dato.Entero = this.Col_PSC_Productor;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Productor");
                _dato.Entero = this.Col_PSC_Cajas;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Cajas");
                _dato.Entero = this.Col_PSC_Kilos;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Kilos");
                _dato.Entero = this.Col_PSC_Variedad;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_Variedad");
                _dato.Entero = this.Col_PSC_JefeCuadrilla;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_JefeCuadrilla");
                _dato.Entero = this.Col_PSC_CajasZ;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_CajasZ");
                _dato.Entero = this.Col_PSC_FolioZ;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_FolioZ");
                _dato.Entero = this.Col_PSC_JefeArea;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Col_PSC_JefeArea");
                
                _conexion.EjecutarNonQuery();
                this.Exito = _conexion.Exito;
            }
            catch (Exception e)
            {
                this.Mensaje = e.Message;
                this.Exito = false;
            }

        }
    }
}
