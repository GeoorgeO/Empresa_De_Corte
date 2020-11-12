using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Empresas : ConexionBase
    {
    public string Id_Empresa { get; set; }
    public string Nombre_Empresa { get; set; }
    public string Telefono1 { get; set; }
    public string Telefono2 { get; set; }
    public string Email { get; set; }
    public string Contacto { get; set; }
    public string RFC { get; set; }
    public string Usuario { get; set; }

    public void MtdSeleccionarEmpresas()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Select";

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
    public void MtdInsertarEmpresas()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Insert";
            _dato.CadenaTexto = Id_Empresa;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empresa");
            _dato.CadenaTexto = Nombre_Empresa;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_Empresa");
            _dato.CadenaTexto = Telefono1;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono1");
            _dato.CadenaTexto = Telefono2;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono2");
            _dato.CadenaTexto = Email;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Email");
            _dato.CadenaTexto = Contacto;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Contacto");
            _dato.CadenaTexto = RFC;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RFC");
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
    public void MtdEliminarEmpresas()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Delete";
            _dato.CadenaTexto = Id_Empresa;
            _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_Empresa");
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
