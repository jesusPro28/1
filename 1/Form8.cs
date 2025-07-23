using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btnSalir.BackColor = ColorTranslator.FromHtml("#002140");
            btn_modificar.BackColor = ColorTranslator.FromHtml("#002140");
            txt_departamento.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_juevesEntrada.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_juevesSalida.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_lunesEntrada.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_lunesSalida.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_martesEntrada.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_martesSalida.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_miercolesEntrada.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_miercolesSalida.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_puesto.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_turno.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_viernesEntrada.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_viernesSalida.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            Txt_numeroDeTrabajador.BackColor = ColorTranslator.FromHtml("#ADDBBF");
        }
        
        private void Form8_Load(object sender, EventArgs e)
        {

        }
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form7 nuevoFormulario = new Form7(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            string numTrabajador = Txt_numeroDeTrabajador.Text.Trim();

            if (string.IsNullOrWhiteSpace(numTrabajador))
            {
                MessageBox.Show("Por favor ingresa un número de trabajador.");
                return;
            }

            clsconeccion conexion = new clsconeccion();
            MySqlConnection con = conexion.Abrir();

            try
            {
                // Verificar existencia en tabla empleado
                string queryEmpleado = "SELECT COUNT(*) FROM empleado WHERE `NUM-TRABAJADOR` = @num";
                MySqlCommand cmdEmp = new MySqlCommand(queryEmpleado, con);
                cmdEmp.Parameters.AddWithValue("@num", numTrabajador);

                int existeEmpleado = Convert.ToInt32(cmdEmp.ExecuteScalar());

                // Verificar existencia en tabla horario
                string queryHorario = "SELECT COUNT(*) FROM horario WHERE `NUM-TRABAJADOR` = @num";
                MySqlCommand cmdHor = new MySqlCommand(queryHorario, con);
                cmdHor.Parameters.AddWithValue("@num", numTrabajador);

                int existeHorario = Convert.ToInt32(cmdHor.ExecuteScalar());

                if (existeEmpleado == 0 || existeHorario == 0)
                {
                    MessageBox.Show("El número de trabajador no existe en ambas tablas.");
                    return;
                }

                // Actualizar EMPLEADO
                string updateEmp = @"
                        UPDATE empleado 
                        SET PUESTO = @puesto, DEPARTAMENTO = @departamento 
                        WHERE `NUM-TRABAJADOR` = @num";
                MySqlCommand cmdUpdateEmp = new MySqlCommand(updateEmp, con);
                cmdUpdateEmp.Parameters.AddWithValue("@puesto", txt_puesto.Text.Trim());
                cmdUpdateEmp.Parameters.AddWithValue("@departamento", txt_departamento.Text.Trim());
                cmdUpdateEmp.Parameters.AddWithValue("@num", numTrabajador);
                cmdUpdateEmp.ExecuteNonQuery();

                // Actualizar HORARIO
                string updateHor = @"UPDATE horario 
                     SET TURNO = @turno,
                         `LUNES-am` = @lunes_am,
                         `MARTES-am` = @martes_am,
                         `MIERCOLES-am` = @miercoles_am,
                         `JUEVES-am` = @jueves_am,
                         `VIERNES-am` = @viernes_am,
                         `lunes-pm` = @lunes_pm,
                         `martes-pm` = @martes_pm,
                         `miercoles-pm` = @miercoles_pm,
                         `jueves-pm` = @jueves_pm,
                         `viernes-pm` = @viernes_pm
                     WHERE `NUM-TRABAJADOR` = @num";

                MySqlCommand cmdUpdateHor = new MySqlCommand(updateHor, con);
                cmdUpdateHor.Parameters.AddWithValue("@turno", txt_turno.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@lunes_am", txt_lunesEntrada.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@martes_am", txt_martesEntrada.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@miercoles_am", txt_miercolesEntrada.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@jueves_am", txt_juevesEntrada.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@viernes_am", txt_viernesEntrada.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@lunes_pm", txt_lunesSalida.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@martes_pm", txt_martesSalida.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@miercoles_pm", txt_miercolesSalida.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@jueves_pm", txt_juevesSalida.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@viernes_pm", txt_viernesSalida.Text.Trim());
                cmdUpdateHor.Parameters.AddWithValue("@num", numTrabajador);
                cmdUpdateHor.ExecuteNonQuery();

                MessageBox.Show("Datos actualizados correctamente.");
                Form7 form7 = new Form7();
                form7.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
