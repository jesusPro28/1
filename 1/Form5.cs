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
            btnSalir.BackColor = ColorTranslator.FromHtml("#002140");
            btnRegistrar.BackColor = ColorTranslator.FromHtml("#002140");
            txtApMaterno.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtApPaterno.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtCurp.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtNombre.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtNumTrabajador.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            cmbDepartamento.BackColor = ColorTranslator.FromHtml("#A6A6A6");
            cmbPuesto.BackColor = ColorTranslator.FromHtml("#A6A6A6");
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
                Puesto = cmbPuesto.Text,
                Departamento = cmbDepartamento.Text
            };

            clsconeccion con = new clsconeccion();
            bool exito = emp.Guardar(con);

            if (exito)
            {
                DialogResult resultado = MessageBox.Show(
                    "Empleado guardado correctamente.\n¿Deseas registrar su horario ahora?",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.OK)
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
