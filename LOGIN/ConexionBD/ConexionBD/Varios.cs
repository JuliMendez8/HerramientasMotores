using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConexionBD
{
    public class Varios
    {
        static string Conection = "Server=localhost; Database=libros; uid=root; password=;";

        static public int Validation(string userName, string password)
        {
            int result = 0;

            try
            {
                MySqlConnection conn = new MySqlConnection(Conection);
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblusuario WHERE strCorreo = @strCorreo AND strContrasena = @strContrasena";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@strCorreo", userName);
                cmd.Parameters.AddWithValue("@strContrasena", password);
                result = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }
            catch { }

            return result;
        }

        static public string Register(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string correo, string password)
        {
            string result = "";

            try
            {
                MySqlConnection conn = new MySqlConnection(Conection);
                conn.Open();
                string query = "INSERT INTO tblusuario VALUES(@strCedulaUsuario, @strPrimerNombre, @strSegundoNombre," +
                    " @strPrimerApellido, @strSegundoApellido, @strCorreo, @strContrasena)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@strCedulaUsuario", cedula);
                cmd.Parameters.AddWithValue("@strPrimerNombre", primerNombre);
                cmd.Parameters.AddWithValue("@strSegundoNombre", segundoNombre);
                cmd.Parameters.AddWithValue("@strPrimerApellido", primerApellido);
                cmd.Parameters.AddWithValue("@strSegundoApellido", segundoApellido);
                cmd.Parameters.AddWithValue("@strCorreo", correo);
                cmd.Parameters.AddWithValue("@strContrasena", password);
                cmd.ExecuteNonQuery();
                conn.Close();
                return result = "¡Felicidades! Te registraste exitosamente";
            }
            catch { return result = "¡Rayos! Error al registrarse"; }
        }

        static public int validationEmail(string Email)
        {
            int result = 0;

            try
            {
                MySqlConnection conn = new MySqlConnection(Conection);
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblusuario WHERE strCorreo = @strCorreo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@strCorreo", Email);
                result = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }
            catch { }

            return result;
        }
    }
}