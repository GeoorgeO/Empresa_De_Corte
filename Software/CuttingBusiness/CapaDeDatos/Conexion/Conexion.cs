using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace CapaDeDatos
{
    public class Conexion
    {
        private SqlConnection conn = new SqlConnection();
        private SqlCommand comando = new SqlCommand();

        public DataSet DatosDataSet { get; set; }

        public DataTable Datos { get; set; }
        public string cadenaConexion { get; set; }
        public string NombreProcedimiento { get; set; }
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        

        //private string m_cadenaConexion;
        public string m_cadenaConexion { get; set; }
        //
        //public void conexionAux(string cadenaConexion)
        //{
        //    m_cadenaConexion = cadenaConexion;

        //}
        public Conexion(string cadenaConexion)
        {
            m_cadenaConexion = cadenaConexion; ;
        }
        public void Conectar()
        {
            Exito = true;
            try
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = m_cadenaConexion;
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        public void ConectarC()
        {
            Exito = true;
            try
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = m_cadenaConexion;
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        public void Desconectar()
        {
            Exito = true;
	        try {
		        if (conn != null) {
			        conn.Close();
		        }
	        } catch (Exception e) {
                Mensaje = e.Message;

                Exito = false;
	        }

        }

        /// <summary>
        /// con la finalidad de pasar de manera genérica el tipo de dato que se está solicitando se realizó esta funcion mediante el parametros tipo se indica qeu tiepo de dato y el valor como ven es una clase donde dependiendo de que tiepo de dato de ahí se toma el valor, si es date se toma del date  y así sucesivamente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="parametro"></param>
        /// <param name="valor"></param>

       private void TipoDato(EnumTipoDato tipo, ref SqlParameter parametro, TipoDato valor)
        {
            if (tipo == EnumTipoDato.Tipodecimal)
            {
		        parametro.SqlDbType = SqlDbType.Decimal;
		        parametro.Value = valor.DecimalValor;
	        }

            if (tipo == EnumTipoDato.CadenaTexto)
            {
		        parametro.SqlDbType = SqlDbType.NVarChar;
		        parametro.Value = valor.CadenaTexto;
	        }
            if (tipo == EnumTipoDato.Entero)
            {
		        parametro.SqlDbType = SqlDbType.Int;
		        parametro.Value = valor.Entero;
	        }
            if (tipo == EnumTipoDato.Fecha)
            {
		        parametro.SqlDbType = SqlDbType.DateTime;
		        parametro.Value = valor.FechaYHora;
	        }

            if (tipo == EnumTipoDato.Boleano )
            {
                parametro.SqlDbType = SqlDbType.Bit ;
                parametro.Value = valor.BoleanoValor ;
            }
            if (tipo == EnumTipoDato.imagen)
            {
                parametro.SqlDbType = SqlDbType.Image;
                parametro.Value = valor.ImagenValor;
            }
        }


       public void eliminarTodosParametros(ref SqlCommand x)
       {
	        if (x.Parameters.Count > 0) {
		        x.Parameters.Clear();
	        }

       }

       public void agregarParametro(EnumTipoDato tipo, TipoDato valor, string nombre)
       {
	        Exito = true;
	        try {
		        SqlParameter parametro = new SqlParameter();
		        parametro.ParameterName = "@" + nombre;
                TipoDato(tipo, ref parametro, valor);                
		        comando.Parameters.Add(parametro);
                
	        } catch (Exception e) {
		        Mensaje = e.Message;
		        Exito = false;
	        }
        }

        public void EjecutarNonQuery()
        {
	        Exito = true;
	        try {
		        Conectar();
		        if (Exito == true) {
			        comando.Connection = conn;
			        comando.CommandText = NombreProcedimiento;
			        comando.CommandTimeout = 500000;
			        comando.CommandType = CommandType.StoredProcedure;
			        comando.ExecuteNonQuery();
		        }
	        } catch (Exception e) {
		        Mensaje = e.Message;
		        Exito = false;
	        } finally {
		        conn.Close();
	        }
        }
        public void EjecutarNonQueryC()
        {
            Exito = true;
            try
            {
                ConectarC();
                if (Exito == true)
                {
                    comando.Connection = conn;
                    comando.CommandText = NombreProcedimiento;
                    comando.CommandTimeout = 500000;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
            finally
            {
                conn.Close();
            }
        }

        public void EjecutarDataset(bool Tabla)
        {
	        DataTable dtMyTable = new DataTable("TABLANORMEX");
	        DataSet dtMyDataSet = new DataSet();

            //Conectar();
	        this.Exito = true;

	        try {
		        if (Exito == true) {
			        comando.Connection = conn;
			        comando.CommandText = NombreProcedimiento;
			        comando.CommandType = CommandType.StoredProcedure;
			        comando.CommandTimeout = 500000;
			        conn.ConnectionString = m_cadenaConexion;
			        comando.Connection = conn;
			        SqlDataAdapter SqlDa = new SqlDataAdapter(comando);
			        if (Tabla == true) {
				        SqlDa.Fill(dtMyTable);
				        Datos = dtMyTable;
			        } else {
				        SqlDa.Fill(dtMyDataSet);
				        DatosDataSet = dtMyDataSet;

			        }
			        conn.Close();
		        }
	        } catch (Exception e) {
		        this.Mensaje = e.Message;


		        this.Exito = false;
	        } finally {
		        conn.Close();
	        }
        }
        public void EjecutarDatasetC(bool Tabla)
        {
            DataTable dtMyTable = new DataTable("TABLANORMEX");
            DataSet dtMyDataSet = new DataSet();

            ConectarC();
            this.Exito = true;

            try
            {
                if (Exito == true)
                {
                    comando.Connection = conn;
                    comando.CommandText = NombreProcedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 500000;
                    conn.ConnectionString = m_cadenaConexion;
                    comando.Connection = conn;
                    SqlDataAdapter SqlDa = new SqlDataAdapter(comando);
                    if (Tabla == true)
                    {
                        SqlDa.Fill(dtMyTable);
                        Datos = dtMyTable;
                    }
                    else
                    {
                        SqlDa.Fill(dtMyDataSet);
                        DatosDataSet = dtMyDataSet;

                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                this.Mensaje = e.Message;


                this.Exito = false;
            }
            finally
            {
                conn.Close();
            }
        }
        public void EjecutarDataset()
        {
	        EjecutarDataset(true);
        }
        public void EjecutarDatasetC()
        {
            EjecutarDatasetC(true);
        }
    }//End Class
}
