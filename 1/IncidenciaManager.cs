using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _1
{
    internal class IncidenciaManager
    {

        private clsconeccion conexion;

        public IncidenciaManager()
        {
            conexion = new clsconeccion();
        }

        public void GuardarIncidencia(string numTrabajador, string curp, DateTime fecha, string descripcion)
        {
            MySqlConnection con = conexion.Abrir();

            try
            {
                // 1. Verificar si existe el trabajador
                string verificar = "SELECT COUNT(*) FROM empleado WHERE `NUM-TRABAJADOR` = @num";
                using (MySqlCommand cmdVerificar = new MySqlCommand(verificar, con))
                {
                    cmdVerificar.Parameters.AddWithValue("@num", numTrabajador);
                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (existe == 0)
                    {
                        MessageBox.Show("El número de trabajador no existe en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2. Insertar la incidencia
                string insertar = @"INSERT INTO incidencias (`NUM-TRABAJADOR`, `CURP`, `FECHA`, `DESCRIPCION`) 
                    VALUES (@num, @curp, @fecha, @desc)";
                using (MySqlCommand cmdInsertar = new MySqlCommand(insertar, con))
                {
                    cmdInsertar.Parameters.AddWithValue("@num", numTrabajador);
                    cmdInsertar.Parameters.AddWithValue("@curp", curp);
                    cmdInsertar.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));
                    cmdInsertar.Parameters.AddWithValue("@desc", descripcion);

                    int resultado = cmdInsertar.ExecuteNonQuery();

                    if (resultado > 0)
                        MessageBox.Show("Incidencia guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    else
                        MessageBox.Show("No se pudo guardar la incidencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar incidencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
