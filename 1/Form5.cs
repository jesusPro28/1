using _1.Properties;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form4 nuevoFormulario = new Form4(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado()
            {
                NumTrabajador = txtNumTrabajador.Text,
                CURP = txtCurp.Text,
                Nombre = txtNombre.Text,
                APaterno = txtApPaterno.Text,
                AMaterno = txtApMaterno.Text,
                Puesto = txtPuesto.Text,
                Departamento = txtDepartamento.Text
            };

            clsconeccion con = new clsconeccion();
            bool exito = emp.Guardar(con);

            if (exito)
            {
                DialogResult resultado = MessageBox.Show(
                    "Empleado guardado correctamente.\n¿Deseas registrar su horario ahora?",
                    "Registro exitoso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Abre el formulario de horario con el número de trabajador ya cargado
                    Form6 horarioForm = new Form6(emp.NumTrabajador);
                    horarioForm.Show();
                }
            }
            else
            {
                MessageBox.Show("No se pudo guardar el empleado.");
            }
        }
    }
    
}
