﻿using System;
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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btn_salir.BackColor = ColorTranslator.FromHtml("#002140");
            btn_generar.BackColor = ColorTranslator.FromHtml("#002140");
            txt_numeroTrabajador.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            textBox1.BackColor = ColorTranslator.FromHtml("#ADDBBF");
            txt_fechaInicio.BackColor = ColorTranslator.FromHtml("#ADDBBF");
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Form11 nuevoFormulario = new Form11(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }
    }
}
