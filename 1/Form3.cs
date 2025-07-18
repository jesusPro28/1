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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 nuevoFormulario = new Form1(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string passwordIngresado = txtPass.Text;

            clsconeccion conexion = new clsconeccion();
            MySqlConnection conn = conexion.Abrir();

            try
            {
                string query = "SELECT COUNT(*) FROM administrador WHERE PASSWORD = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", passwordIngresado);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Acceso concedido");

                        Form4 nuevoForm = new Form4();
                        nuevoForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}
