using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Album_Empresa
{
    internal class Conexion
    {
        public static MySqlConnection Conectarse()
        {
            string servidor = "localhost";
            string bd = "crud_album";
            string usuario = "root";
            string password = "";
            string cadenaconexion =
                "Database=" + bd + "; " +
                "Data Source=" + servidor + ";" +
                " User Id= " + usuario + ";" +
                " Password=" + password + "";
            try {

                MySqlConnection conexionBD = new MySqlConnection(cadenaconexion);
                
                
                return conexionBD;


            } catch (MySqlException ex)
            {
               
                Console.WriteLine("Error" + ex.Message);
                return null;
            }
        }
    }
}
