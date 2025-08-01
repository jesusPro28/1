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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
            btn_generacionDeReportes.BackColor = ColorTranslator.FromHtml("#002140");
            btn_incidencias.BackColor = ColorTranslator.FromHtml("#002140");
            btn_salir.BackColor = ColorTranslator.FromHtml("#002140");
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Form4 nuevoFormulario = new Form4(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btn_incidencias_Click(object sender, EventArgs e)
        {
            Form10 nuevoFormulario = new Form10(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btn_generacionDeReportes_Click(object sender, EventArgs e)
        {
            Form11 nuevoFormulario = new Form11(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }
    }
}
