using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMC2
{
    public partial class principal : Form
    {
        //creamos instancias de los formilarios que vamos a nesesitar en nuestro mdi
        private Form1 form1;
        private Formulario_3 formulario;
        public principal()
        {
            InitializeComponent();
        }
        // esto sirve para que el formulaeio llamado aparezca dentro del formulario padre y que no se abra mas de una vez a menos que se halla cerrado 
        //para lograr esto se edita la propiedad isMDIconteiner se asigna com true
        private void formulario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form1 == null || form1.IsDisposed)
            {
                form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            }
            else
            {
                form1.BringToFront();
            }



        }

        private void principal_Load(object sender, EventArgs e)
        {
            if (form1 == null || form1.IsDisposed)
            {
                formulario = new Formulario_3();
                formulario.MdiParent = this;
                formulario.Show();
            }
            else
            {
                form1.BringToFront();
            }


        }
    }
}
