using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ob.Web.Data;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Configuration;
class Conexion
    {
        public static SqlConnection SqlCon;
        public static SqlCommand cmd;       //EL COMANDO LO CREAMOS PUBLICO PARA USARLO EN LA PAGINA ORIGEN
        public Conexion()
        {
            string Connection = "";//contendra los datos de la conexion
            ConnectionStringSettings Conex;
            Conex = ConfigurationManager.ConnectionStrings["BD"];
            Connection = Conex.ConnectionString;
            SqlCon = new SqlConnection(Connection);
        }
        public void Abrir()
        {
            SqlCon.Open();
        }
        public void Cerrar()
        {
            SqlCon.Close();
        }
        public DataSet Ejecutar()//nos ayudara a extraer el campo que querramos
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds, "0");
            return ds;
        }
    }
//TABLA ORIGEN DONDE HAREMOS LOS LLAMADOS

private void Inflacion()
        {
            string Sql = "crTarObtenerInflacion";//CREAMOS EL STOREPROCEDURE
            Conexion cn = new Conexion();
            try
            {
                cn.Abrir();
             
                Conexion.cmd = new SqlCommand(Sql, Conexion.SqlCon);//llamamos a nuestro comando
                Conexion.cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = cn.Ejecutar().Tables[0];//llamamo la forma ejecutar, desde un datatable
                lblAComercial.Text = dt.Rows[0]["porcentaje"].ToString();//si se observa el dt.table[0], no se usa porque lo hacemos al principio de la llamada
                cn.Cerrar();

            }
            catch (Exception ex)
            { }
        }
