using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDeDatos
{
    public class ConexionBase
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public DataTable Datos { get; set; }

        protected string cadenaConexion = ConexionSQL.LeerConexion();

        protected Conexion _conexion = new Conexion(ConexionSQL.LeerConexion());

        protected string cadenaConexionC = ConexionSQL.LeerConexionC();

        protected Conexion _conexionC = new Conexion(ConexionSQL.LeerConexionC());

        protected string cadenaConexionR = ConexionSQL.LeerConexionR();

        protected Conexion _conexionR = new Conexion(ConexionSQL.LeerConexionR());
    }
}
