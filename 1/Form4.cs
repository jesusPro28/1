using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btnRegistrar.BackColor = ColorTranslator.FromHtml("#002140");
            btnSalir.BackColor = ColorTranslator.FromHtml("#002140");
            comboBoxelegir.BackColor = ColorTranslator.FromHtml("#A6A6A6");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBoxelegir.Items.Add("AGREGAR");
            comboBoxelegir.Items.Add("MODIFICAR");
            comboBoxelegir.Items.Add("REPORTES");

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string seleccion = comboBoxelegir.SelectedItem?.ToString();

            if (seleccion == null)
            {
                MessageBox.Show("Por favor selecciona una opción.");
                return;
            }

            Form nuevoForm = null;

            switch (seleccion)
            {
                case "AGREGAR":
                    nuevoForm = new Form5();
                    break;
                case "MODIFICAR":
                    nuevoForm = new Form7();
                    break;
                case "REPORTES":
                    nuevoForm = new Form9();
                    break;
                default:
                    MessageBox.Show("Opción no válida.");
                    return;
            }

            nuevoForm.Show();
            this.Close(); // Cierra el formulario actual
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form3 nuevoFormulario = new Form3(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }
    }
}
