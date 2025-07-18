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
                            // Crear y llenar el formulario destino
                            Form8 frmDetalle = new Form8();

                            frmDetalle.txtNumero.Text = reader["NUM-TRABAJADOR"].ToString(); // CORREGIDO
                            frmDetalle.txtPuesto.Text = reader["PUESTO"].ToString();
                            frmDetalle.txtDepartamento.Text = reader["DEPARTAMENTO"].ToString();
                            frmDetalle.txtTurno.Text = reader["TURNO"].ToString();

                            frmDetalle.txtLunesAM.Text = reader["LUNES-am"].ToString();
                            frmDetalle.txtMartesAM.Text = reader["MARTES-am"].ToString();
                            frmDetalle.txtMiercolesAM.Text = reader["MIERCOLES-am"].ToString();
                            frmDetalle.txtJuevesAM.Text = reader["JUEVES-am"].ToString();
                            frmDetalle.txtViernesAM.Text = reader["VIERNES-am"].ToString();

                            frmDetalle.txtLunesPM.Text = reader["lunes-pm"].ToString();
                            frmDetalle.txtMartesPM.Text = reader["martes-pm"].ToString();
                            frmDetalle.txtMiercolesPM.Text = reader["miercoles-pm"].ToString();
                            frmDetalle.txtJuevesPM.Text = reader["jueves-pm"].ToString();
                            frmDetalle.txtViernesPM.Text = reader["viernes-pm"].ToString();

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
    }
}
