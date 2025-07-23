using _1.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            textBox1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            btnEliminar.BackColor = ColorTranslator.FromHtml("#002140");
            btnModificar.BackColor = ColorTranslator.FromHtml("#002140");
            btnSalir.BackColor = ColorTranslator.FromHtml("#002140");
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form4 nuevoFormulario = new Form4(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string numTrabajador = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numTrabajador))
            {
                MessageBox.Show("Ingresa un número de trabajador.");
                return;
            }

            clsconeccion conexion = new clsconeccion();

            using (MySqlConnection conn = conexion.Abrir())
            {
                string query = @"
            SELECT 
                empleado.`NUM-TRABAJADOR`,
                empleado.PUESTO,
                empleado.DEPARTAMENTO,
                horario.TURNO,
                horario.`LUNES-am`, horario.`MARTES-am`, horario.`MIERCOLES-am`, horario.`JUEVES-am`, horario.`VIERNES-am`,
                horario.`lunes-pm`, horario.`martes-pm`, horario.`miercoles-pm`, horario.`jueves-pm`, horario.`viernes-pm`
            FROM empleado
            LEFT JOIN horario ON empleado.`NUM-TRABAJADOR` = horario.`NUM-TRABAJADOR`
            WHERE empleado.`NUM-TRABAJADOR` = @num;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@num", numTrabajador);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Form8 frmDetalle = new Form8();

                            frmDetalle.Txt_numeroDeTrabajador.Text = reader["NUM-TRABAJADOR"].ToString();
                            frmDetalle.txt_puesto.Text = reader["PUESTO"].ToString();
                            frmDetalle.txt_departamento.Text = reader["DEPARTAMENTO"].ToString();
                            frmDetalle.txt_turno.Text = reader["TURNO"].ToString();

                            frmDetalle.txt_lunesEntrada.Text = reader["LUNES-am"].ToString();
                            frmDetalle.txt_martesEntrada.Text = reader["MARTES-am"].ToString();
                            frmDetalle.txt_miercolesEntrada.Text = reader["MIERCOLES-am"].ToString();
                            frmDetalle.txt_juevesEntrada.Text = reader["JUEVES-am"].ToString();
                            frmDetalle.txt_viernesEntrada.Text = reader["VIERNES-am"].ToString();

                            frmDetalle.txt_lunesSalida.Text = reader["lunes-pm"].ToString();
                            frmDetalle.txt_martesSalida.Text = reader["martes-pm"].ToString();
                            frmDetalle.txt_miercolesSalida.Text = reader["miercoles-pm"].ToString();
                            frmDetalle.txt_juevesSalida.Text = reader["jueves-pm"].ToString();
                            frmDetalle.txt_viernesSalida.Text = reader["viernes-pm"].ToString();

                            frmDetalle.Show();
                        }
                        else
                        {
                            MessageBox.Show("Empleado no encontrado.");
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string numTrabajador = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numTrabajador))
            {
                MessageBox.Show("Por favor, ingresa el número de trabajador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Estás seguro de eliminar todos los datos de este trabajador?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            clsconeccion conexion = new clsconeccion();

            try
            {
                MySqlConnection con = conexion.Abrir();

                // Iniciar transacción
                MySqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    string eliminarHorario = "DELETE FROM horario WHERE `NUM-TRABAJADOR` = @numTrabajador";
                    string eliminarEmpleado = "DELETE FROM empleado WHERE `NUM-TRABAJADOR` = @numTrabajador";

                    using (MySqlCommand cmd1 = new MySqlCommand(eliminarHorario, con, transaccion))
                    {
                        cmd1.Parameters.AddWithValue("@numTrabajador", numTrabajador);
                        cmd1.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd2 = new MySqlCommand(eliminarEmpleado, con, transaccion))
                    {
                        cmd2.Parameters.AddWithValue("@numTrabajador", numTrabajador);
                        int filasAfectadas = cmd2.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Confirmar transacción si todo fue exitoso
                            transaccion.Commit();

                            MessageBox.Show("Datos eliminados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                        }
                        else
                        {
                            // Revertir si no se encontró el trabajador
                            transaccion.Rollback();

                            MessageBox.Show("No se encontró ningún trabajador con ese número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception exInTransaction)
                {
                    // Revertir en caso de cualquier error durante la transacción
                    transaccion.Rollback();
                    MessageBox.Show("Error al eliminar datos: " + exInTransaction.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
