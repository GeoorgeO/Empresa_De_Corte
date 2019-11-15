using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace CapaDeDatos
{
    public class SEG_Login:ConexionBase
    {
        public System.Nullable<int> IdUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Id_Usuario { get; set; }
        public System.Nullable<int> IsRestablecerContrasenia { get; set; }
        public string UltimoAcceso { get; set; }

        public void MtdSeleccionarUsuarioLogin()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_UsuariosAcceso_Select";
                _dato.CadenaTexto = Id_Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Usuario");
                _dato.CadenaTexto = Contrasena;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Contrasena");
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
        public void MtdModificarUsuarioFechaAcceso()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SPR_SEGLoginFechaAccesoModificar";
                
                _dato.Entero = IdUsuario;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "IdUsuario");

                _conexion.EjecutarNonQuery();
                Exito = _conexion.Exito;
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        
    }
}
