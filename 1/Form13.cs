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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btn_generar.BackColor = ColorTranslator.FromHtml("#002140");
            btn_salir.BackColor = ColorTranslator.FromHtml("#002140");

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Form12 nuevoFormulario = new Form12(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
