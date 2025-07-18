using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _1
{
    class Empleado
    {
        public string NumTrabajador { get; set; }
        public string CURP { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }

        public bool Guardar(clsconeccion conexion)
        {
            try
            {
                string sql = "INSERT INTO empleado (`NUM-TRABAJADOR`, CURP, NOMBRE, `A-PATERNO`, `A-MATERNO`, PUESTO, DEPARTAMENTO) " +
              "VALUES (@num, @curp, @nombre, @paterno, @materno, @puesto, @depto)";

                MySqlCommand cmd = new MySqlCommand(sql, conexion.Abrir());
                cmd.Parameters.AddWithValue("@num", NumTrabajador);
                cmd.Parameters.AddWithValue("@curp", CURP);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@paterno", APaterno);
                cmd.Parameters.AddWithValue("@materno", AMaterno);
                cmd.Parameters.AddWithValue("@puesto", Puesto);
                cmd.Parameters.AddWithValue("@depto", Departamento);

                int filas = cmd.ExecuteNonQuery();
                conexion.Cerrar();
                return filas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
                conexion.Cerrar();
                return false;
            }

        }
    }
    
}
