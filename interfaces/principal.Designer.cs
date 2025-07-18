namespace IMC2
{
    partial class principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            tareasToolStripMenuItem = new ToolStripMenuItem();
            formulario1ToolStripMenuItem = new ToolStripMenuItem();
            cUENTASToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tareasToolStripMenuItem, cUENTASToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tareasToolStripMenuItem
            // 
            tareasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { formulario1ToolStripMenuItem });
            tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            tareasToolStripMenuItem.Size = new Size(53, 20);
            tareasToolStripMenuItem.Text = "tareas ";
            // 
            // formulario1ToolStripMenuItem
            // 
            formulario1ToolStripMenuItem.Name = "formulario1ToolStripMenuItem";
            formulario1ToolStripMenuItem.Size = new Size(180, 22);
            formulario1ToolStripMenuItem.Text = "formulario1...";
            formulario1ToolStripMenuItem.Click += formulario1ToolStripMenuItem_Click;
            // 
            // cUENTASToolStripMenuItem
            // 
            cUENTASToolStripMenuItem.Name = "cUENTASToolStripMenuItem";
            cUENTASToolStripMenuItem.Size = new Size(67, 20);
            cUENTASToolStripMenuItem.Text = "cUENTAS";
            // 
            // principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "principal";
            Text = "principal";
            Load += principal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tareasToolStripMenuItem;
        private ToolStripMenuItem formulario1ToolStripMenuItem;
        private ToolStripMenuItem cUENTASToolStripMenuItem;
    }
}