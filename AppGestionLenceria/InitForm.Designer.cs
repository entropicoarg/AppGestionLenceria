namespace UI
{
    partial class InitForm
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
            archivoToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            gestionToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            gestionToolStripMenuItem1 = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            coloresToolStripMenuItem = new ToolStripMenuItem();
            tamañosToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, proveedoresToolStripMenuItem, productosToolStripMenuItem, ventasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionToolStripMenuItem });
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(84, 20);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // gestionToolStripMenuItem
            // 
            gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            gestionToolStripMenuItem.Size = new Size(180, 22);
            gestionToolStripMenuItem.Text = "Gestion";
            gestionToolStripMenuItem.Click += gestionToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionToolStripMenuItem1, categoriasToolStripMenuItem, coloresToolStripMenuItem, tamañosToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // gestionToolStripMenuItem1
            // 
            gestionToolStripMenuItem1.Name = "gestionToolStripMenuItem1";
            gestionToolStripMenuItem1.Size = new Size(180, 22);
            gestionToolStripMenuItem1.Text = "Gestion";
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(180, 22);
            categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // coloresToolStripMenuItem
            // 
            coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            coloresToolStripMenuItem.Size = new Size(180, 22);
            coloresToolStripMenuItem.Text = "Colores";
            // 
            // tamañosToolStripMenuItem
            // 
            tamañosToolStripMenuItem.Name = "tamañosToolStripMenuItem";
            tamañosToolStripMenuItem.Size = new Size(180, 22);
            tamañosToolStripMenuItem.Text = "Tamaños";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // InitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "InitForm";
            Text = "Gestion de Lenceria";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem1;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem coloresToolStripMenuItem;
        private ToolStripMenuItem tamañosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
    }
}