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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btn_salir.BackColor = ColorTranslator.FromHtml("#002140");
            btn_guardar.BackColor = ColorTranslator.FromHtml("#002140");
            txt_curp.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_descripcion.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_fecha.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_numeroTrabajador.BackColor = ColorTranslator.FromHtml("#ADDBBF");
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Form9 nuevoFormulario = new Form9(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }
        private void LimpiarCampos()
        {
            txt_numeroTrabajador.Clear();
            txt_curp.Clear();
            txt_fecha.Clear();
            txt_descripcion.Clear();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string numTrabajador = txt_numeroTrabajador.Text.Trim();
            string curp = txt_curp.Text.Trim();
            string descripcion = txt_descripcion.Text.Trim();

            if (!DateTime.TryParse(txt_fecha.Text.Trim(), out DateTime fecha))
            {
                MessageBox.Show("La fecha ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(numTrabajador) || string.IsNullOrEmpty(curp) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IncidenciaManager manager = new IncidenciaManager();
            manager.GuardarIncidencia(numTrabajador, curp, fecha, descripcion);
            LimpiarCampos(); // <- AQUÍ LIMPIAS LOS TEXTBOX

        }
    }
}
