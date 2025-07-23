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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            button1.BackColor = ColorTranslator.FromHtml("#002140");
            cmb_seleccionar.BackColor = ColorTranslator.FromHtml("#A6A6A6");
            //agrega las opciones del combobox
            cmb_seleccionar.Items.Add("EMPLEADO");
            cmb_seleccionar.Items.Add("REPORTE GENERAL");
            cmb_seleccionar.SelectedIndex = 0; 
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 nuevoFormulario = new Form9(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void cmb_seleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cmb_seleccionar.SelectedItem.ToString();    
            if (opcionSeleccionada == "EMPLEADO")
            {
                // Mostrar el formulario de empleado
                Form12 nuevoFormulario = new Form12(); // Instanciar el nuevo form
                nuevoFormulario.Show();              // Mostrar el nuevo form
                this.Close();
            }
            else if (opcionSeleccionada == "REPORTE GENERAL")
            {
                // Mostrar el formulario de reporte general
                Form14 nuevoFormulario = new Form14(); // Instanciar el nuevo form
                nuevoFormulario.Show();              // Mostrar el nuevo form
                this.Close();
            }
        }
    }
}
