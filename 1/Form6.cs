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
    public partial class Form6 : Form
    {
        public Form6(string NumTrabajador)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            txtJueves.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtJueves1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtLunes.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtLunes1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtMartes.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtMartes1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtMiercoles.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtMiercoles1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtNumTrabajador.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtTurno.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtViernes.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txtViernes1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
           
            txtNumTrabajador.Text = NumTrabajador;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form5 nuevoFormulario = new Form5(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Horario h = new Horario()
            {
                NumTrabajador = txtNumTrabajador.Text,
                Turno = txtTurno.Text,
                LunesAM = txtLunes.Text,
                MartesAM = txtMartes.Text,
                MiercolesAM = txtMiercoles.Text,
                JuevesAM = txtJueves.Text,
                ViernesAM = txtViernes.Text,
                LunesPM = txtLunes1.Text,
                MartesPM = txtMartes1.Text,
                MiercolesPM = txtMiercoles1.Text,
                JuevesPM = txtJueves1.Text,
                ViernesPM = txtViernes1.Text
            };

            clsconeccion con = new clsconeccion();
            bool exito = h.GuardarHorario(con);

            if (exito)
            {
                DialogResult resultado = MessageBox.Show(
                    "Horario guardado correctamente",
                    "Registro exitoso",
                    MessageBoxButtons.OK
                );

                if (resultado == DialogResult.Yes)
                {
                    // Abre el formulario de horario con el número de trabajador ya cargado
                    Form4 horarioForm = new Form4();
                    horarioForm.Show();
                }
            }
            else
            {
                MessageBox.Show("No se pudo guardar el horario.");
            }
        }
    }
}
