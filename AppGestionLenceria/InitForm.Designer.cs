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
            ventasToolStripMenuItem = new ToolStripMenuItem();
            gestionDePropiedadesToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem1 = new ToolStripMenuItem();
            tamañosToolStripMenuItem1 = new ToolStripMenuItem();
            coloresToolStripMenuItem1 = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            gestionToolStripMenuItem2 = new ToolStripMenuItem();
            gestionToolStripMenuItem3 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, proveedoresToolStripMenuItem, productosToolStripMenuItem, ventasToolStripMenuItem, gestionDePropiedadesToolStripMenuItem, clientesToolStripMenuItem });
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
            gestionToolStripMenuItem.Size = new Size(114, 22);
            gestionToolStripMenuItem.Text = "Gestion";
            gestionToolStripMenuItem.Click += gestionToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionToolStripMenuItem1 });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // gestionToolStripMenuItem1
            // 
            gestionToolStripMenuItem1.Name = "gestionToolStripMenuItem1";
            gestionToolStripMenuItem1.Size = new Size(114, 22);
            gestionToolStripMenuItem1.Text = "Gestion";
            gestionToolStripMenuItem1.Click += gestionToolStripMenuItem1_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionToolStripMenuItem3 });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // gestionDePropiedadesToolStripMenuItem
            // 
            gestionDePropiedadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasToolStripMenuItem1, tamañosToolStripMenuItem1, coloresToolStripMenuItem1 });
            gestionDePropiedadesToolStripMenuItem.Name = "gestionDePropiedadesToolStripMenuItem";
            gestionDePropiedadesToolStripMenuItem.Size = new Size(143, 20);
            gestionDePropiedadesToolStripMenuItem.Text = "Gestion de propiedades";
            // 
            // categoriasToolStripMenuItem1
            // 
            categoriasToolStripMenuItem1.Name = "categoriasToolStripMenuItem1";
            categoriasToolStripMenuItem1.Size = new Size(130, 22);
            categoriasToolStripMenuItem1.Text = "Categorias";
            categoriasToolStripMenuItem1.Click += categoriasToolStripMenuItem1_Click;
            // 
            // tamañosToolStripMenuItem1
            // 
            tamañosToolStripMenuItem1.Name = "tamañosToolStripMenuItem1";
            tamañosToolStripMenuItem1.Size = new Size(130, 22);
            tamañosToolStripMenuItem1.Text = "Tamaños";
            tamañosToolStripMenuItem1.Click += tamañosToolStripMenuItem1_Click;
            // 
            // coloresToolStripMenuItem1
            // 
            coloresToolStripMenuItem1.Name = "coloresToolStripMenuItem1";
            coloresToolStripMenuItem1.Size = new Size(130, 22);
            coloresToolStripMenuItem1.Text = "Colores";
            coloresToolStripMenuItem1.Click += coloresToolStripMenuItem1_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionToolStripMenuItem2 });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // gestionToolStripMenuItem2
            // 
            gestionToolStripMenuItem2.Name = "gestionToolStripMenuItem2";
            gestionToolStripMenuItem2.Size = new Size(180, 22);
            gestionToolStripMenuItem2.Text = "Gestion";
            gestionToolStripMenuItem2.Click += gestionToolStripMenuItem2_Click;
            // 
            // gestionToolStripMenuItem3
            // 
            gestionToolStripMenuItem3.Name = "gestionToolStripMenuItem3";
            gestionToolStripMenuItem3.Size = new Size(180, 22);
            gestionToolStripMenuItem3.Text = "Gestion";
            gestionToolStripMenuItem3.Click += gestionToolStripMenuItem3_Click;
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
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem gestionDePropiedadesToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem1;
        private ToolStripMenuItem tamañosToolStripMenuItem1;
        private ToolStripMenuItem coloresToolStripMenuItem1;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem2;
        private ToolStripMenuItem gestionToolStripMenuItem3;
    }
}