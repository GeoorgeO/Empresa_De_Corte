using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos
{
    public class CLS_HojaNomina : ConexionBase
    {

        public string Id_HojaNomina { get; set; }
        public string Fecha_HojaNomina { get; set; }
        public string Id_Cuadrilla { get; set; }
        public string Empresa { get; set; }
        public decimal Pago_Diario { get; set; }
        public string Id_JefeCuadrilla { get; set; }
        public decimal Tope_pgo_x_dia { get; set; }
        public decimal Total_corte_pgo_x_dia { get; set; }
        public decimal Kgs_cortados_x_dia { get; set; }
        public decimal Cajas_cortados_x_dia { get; set; }
        public decimal Pago_jefe_cuadrilla { get; set; }
        public decimal Peso_promedio_caja { get; set; }
        public decimal Precio_caja_1 { get; set; }
        public decimal Precio_caja_2 { get; set; }
        public decimal Total_cortadores { get; set; }
        public decimal Total_Cajas { get; set; }
        public decimal Total_Importe { get; set; }
        public string Pago_x_dia { get; set; }
        public string Pago_falso { get; set; }
        public string Festivo { get; set; }
        public string Id_Tipo { get; set; }
        public string Estatus { get; set; }
        public decimal Precio_caja { get; set; }
        public string Id_HojaNomina_New { get; set; }
        public string EOrdenesDeCorte { get; set; }

        public string del { get; set; }
        public string al { get; set; }

        public string categoria { get; set; }
        public string todascategorias { get; set; }

        public decimal Pago_Maniobra { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarHojaNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNomina_Select";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
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

        public void MtdVerificaCuadrillaxFecha()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_JefexFecha_Select";
                _dato.CadenaTexto = Id_Cuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Cuadrilla");
                _dato.CadenaTexto = Fecha_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_HojaNomina");
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


        public void MtdSeleccionarHojasNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojasNomina_Select";
                _dato.CadenaTexto = del;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "del");
                _dato.CadenaTexto = al;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "al");
                _dato.CadenaTexto = categoria;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "categoria");
                _dato.CadenaTexto = todascategorias;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "todascategorias");
                _dato.CadenaTexto = Estatus;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Estatus");
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
        public void MtdSeleccionarHojasNominaCerradas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojasNominaCerradas_Select";
                _dato.CadenaTexto = del;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "del");
                _dato.CadenaTexto = al;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "al");
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

        public void MtdSeleccionarCuadrillaNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_CuadrillasNomina_Select";
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

        public void MtdSeleccionarParametrosHoja()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ParametrosHoja_Select";
                _dato.CadenaTexto = Id_Cuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Cuadrilla");
                _dato.CadenaTexto = Id_Tipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Tipo");
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

        public void MtdInsertarHojaNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNomina_Insert";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
                _dato.CadenaTexto = Fecha_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Fecha_HojaNomina");
                _dato.CadenaTexto = Id_Cuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Cuadrilla");
                _dato.CadenaTexto = Empresa;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Empresa");
                _dato.DecimalValor = Pago_Diario;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Diario");
                _dato.CadenaTexto = Id_JefeCuadrilla;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_JefeCuadrilla");
                _dato.DecimalValor = Tope_pgo_x_dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Tope_pgo_x_dia");
                _dato.DecimalValor = Total_corte_pgo_x_dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Total_corte_pgo_x_dia");
                _dato.DecimalValor = Kgs_cortados_x_dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kgs_cortados_x_dia");
                _dato.DecimalValor = Pago_jefe_cuadrilla;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_jefe_cuadrilla");
                _dato.DecimalValor = Peso_promedio_caja;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Peso_promedio_caja");
                _dato.DecimalValor = Precio_caja_1;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_caja_1");
                _dato.DecimalValor = Precio_caja_2;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_caja_2");
                _dato.DecimalValor = Total_cortadores;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Total_cortadores");
                _dato.DecimalValor = Total_Cajas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Total_Cajas");
                _dato.DecimalValor = Total_Importe;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Total_Importe");
                _dato.CadenaTexto = Pago_x_dia;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Pago_x_dia");
                _dato.CadenaTexto = Pago_falso;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Pago_falso");
                _dato.CadenaTexto = Festivo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Festivo");
                _dato.DecimalValor = Cajas_cortados_x_dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Cajas_cortados_x_dia");
                _dato.CadenaTexto = Estatus;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Estatus");
                _dato.DecimalValor = Precio_caja;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_caja");
                _dato.DecimalValor = Pago_Maniobra;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Pago_Maniobra");

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

        public void MtdActuaizaOrdenHojaNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNomina_Update";
                _dato.CadenaTexto = Id_HojaNomina;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina");
                _dato.CadenaTexto = Id_HojaNomina_New;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_HojaNomina_New");

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
        public void MtdActuaizaLiberaHojaNomina()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_HojaNomina_Libera_Update";
                _dato.CadenaTexto = EOrdenesDeCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "EOrdenesDeCorte");
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
