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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            cmbElegir.BackColor = ColorTranslator.FromHtml("#A6A6A6");
            // Opciones del ComboBox
            cmbElegir.Items.Add("EMPLEADO");
            cmbElegir.Items.Add("ADMINISTRADOR");

            // Evento de cambio de selección
            cmbElegir.SelectedIndexChanged += cmbElegir_SelectedIndexChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbElegir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElegir.SelectedItem.ToString() == "EMPLEADO")
            {
                
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
           
            }
            else if (cmbElegir.SelectedItem.ToString() == "ADMINISTRADOR")
            {
               
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
                
            }
            
        }
    }
}
