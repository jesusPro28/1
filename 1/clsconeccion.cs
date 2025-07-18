using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace _1
{
    internal class clsconeccion
    {
        private MySqlConnection con;
        public clsconeccion()
        {
            con = new MySqlConnection("Server=127.0.0.1; Database=sistema de registro de asistencia de personal; Uid=root; Pwd=; Port=3306;");

        }

        public MySqlConnection Abrir()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }

        public void Cerrar()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
