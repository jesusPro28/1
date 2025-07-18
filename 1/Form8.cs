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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
        }
        public TextBox txtNumero;
        public TextBox txtPuesto;
        public TextBox txtDepartamento;
        public TextBox txtTurno;

        public TextBox txtLunesAM;
        public TextBox txtMartesAM;
        public TextBox txtMiercolesAM;
        public TextBox txtJuevesAM;
        public TextBox txtViernesAM;

        public TextBox txtLunesPM;
        public TextBox txtMartesPM;
        public TextBox txtMiercolesPM;
        public TextBox txtJuevesPM;
        public TextBox txtViernesPM;
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form7 nuevoFormulario = new Form7(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }
    }
}
