using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceNetCore21MySql.Controllers
{
    public class PrincipalController
    {
        public List<Datos> Informacion;

        public void ConsultaRegistros()
        {
            var dt = new DataTable();
            var conexion = new MySqlConnection("Server=35.238.58.16; database=DB_PersonalProjects; user id=eduardo; password=12345;SslMode=none;");
            var cmd = new MySqlCommand("select *from Informacion",conexion);
            conexion.Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            Informacion = new List<Datos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Datos datos = new Datos();
                datos.id_usuario = int.Parse(dt.Rows[i]["id_usuario"].ToString());
                datos.Nombre = dt.Rows[i]["nombre"].ToString();
                datos.Direccion = dt.Rows[i]["direccion"].ToString();
                datos.Telefono = dt.Rows[i]["telefono"].ToString();
                datos.Correo = dt.Rows[i]["correo"].ToString();
                datos.Edad = int.Parse(dt.Rows[i]["edad"].ToString());

                Informacion.Add(datos);
            }
        }

        public void ConsultarRegistroUsuario(int id)
        {
            var dt = new DataTable();
            var conexion = new MySqlConnection("Server=35.238.58.16; database=DB_PersonalProjects; user id=eduardo; password=12345;SslMode=none;");
            var cmd = new MySqlCommand("select *from Informacion where id_usuario =" + id + "", conexion);
            conexion.Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            Informacion = new List<Datos>();

            Datos datos = new Datos();
            datos.id_usuario = int.Parse(dt.Rows[0]["id_usuario"].ToString());
            datos.Nombre = dt.Rows[0]["nombre"].ToString();
            datos.Direccion = dt.Rows[0]["direccion"].ToString();
            datos.Telefono = dt.Rows[0]["telefono"].ToString();
            datos.Correo = dt.Rows[0]["correo"].ToString();
            datos.Edad = int.Parse(dt.Rows[0]["edad"].ToString());
            Informacion.Add(datos);
        }

        public bool AlmacenarInformacionUsuario(int ID, string Nombre, string Direccion, string Telefono, string Correo, int Edad)
        {
            var conexion = new MySqlConnection("Server=35.238.58.16; database=DB_PersonalProjects; user id=eduardo; password=12345;SslMode=none;");
            var query = new MySqlCommand("insert into Informacion values(" + ID + ",'" + Nombre + "','" + Direccion + "','" + Telefono + "','" + Correo + "'," + Edad + ")", conexion);
            try
            {
                conexion.Open();
                query.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                conexion.Close();
                return false;
            }
        }
    }
}
