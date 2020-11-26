namespace VntRoute
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motoristasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarArquivoDeRotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDestinos = new System.Windows.Forms.Button();
            this.btnMotorista = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.bntVeiculo = new System.Windows.Forms.Button();
            this.BtnCliente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.movimentaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.ForestGreen;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.lançamentosToolStripMenuItem,
            this.importarArquivoDeRotasToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 25);
            this.menuStrip1.TabIndex = 8;
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametrosToolStripMenuItem,
            this.destinosToolStripMenuItem,
            this.motoristasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.cidadeToolStripMenuItem,
            this.estadoToolStripMenuItem,
            this.veículoToolStripMenuItem});
            this.cadastroToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.cadastroToolStripMenuItem.Text = "Cadastros";
            // 
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.parametrosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.parametrosToolStripMenuItem.Text = "Empresa";
            this.parametrosToolStripMenuItem.Click += new System.EventHandler(this.parametrosToolStripMenuItem_Click_1);
            // 
            // destinosToolStripMenuItem
            // 
            this.destinosToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.destinosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.destinosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("destinosToolStripMenuItem.Image")));
            this.destinosToolStripMenuItem.Name = "destinosToolStripMenuItem";
            this.destinosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.destinosToolStripMenuItem.Text = "Destinos";
            this.destinosToolStripMenuItem.Click += new System.EventHandler(this.destinosToolStripMenuItem_Click);
            // 
            // motoristasToolStripMenuItem
            // 
            this.motoristasToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.motoristasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.motoristasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("motoristasToolStripMenuItem.Image")));
            this.motoristasToolStripMenuItem.Name = "motoristasToolStripMenuItem";
            this.motoristasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.motoristasToolStripMenuItem.Text = "Motoristas";
            this.motoristasToolStripMenuItem.Click += new System.EventHandler(this.motoristasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem.Image")));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // cidadeToolStripMenuItem
            // 
            this.cidadeToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.cidadeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cidadeToolStripMenuItem.Name = "cidadeToolStripMenuItem";
            this.cidadeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cidadeToolStripMenuItem.Text = "Cidade";
            this.cidadeToolStripMenuItem.Click += new System.EventHandler(this.cidadeToolStripMenuItem_Click);
            // 
            // estadoToolStripMenuItem
            // 
            this.estadoToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.estadoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            this.estadoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.estadoToolStripMenuItem.Text = "Estado";
            this.estadoToolStripMenuItem.Click += new System.EventHandler(this.estadoToolStripMenuItem_Click);
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.veículoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.veículoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("veículoToolStripMenuItem.Image")));
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            this.veículoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.veículoToolStripMenuItem.Text = "Veículo";
            this.veículoToolStripMenuItem.Click += new System.EventHandler(this.veículoToolStripMenuItem_Click);
            // 
            // lançamentosToolStripMenuItem
            // 
            this.lançamentosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.lançamentosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lançamentosToolStripMenuItem.Image")));
            this.lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            this.lançamentosToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.lançamentosToolStripMenuItem.Text = "Lançamentos";
            this.lançamentosToolStripMenuItem.Click += new System.EventHandler(this.lançamentosToolStripMenuItem_Click);
            // 
            // importarArquivoDeRotasToolStripMenuItem
            // 
            this.importarArquivoDeRotasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.importarArquivoDeRotasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarArquivoDeRotasToolStripMenuItem.Image")));
            this.importarArquivoDeRotasToolStripMenuItem.Name = "importarArquivoDeRotasToolStripMenuItem";
            this.importarArquivoDeRotasToolStripMenuItem.Size = new System.Drawing.Size(178, 21);
            this.importarArquivoDeRotasToolStripMenuItem.Text = "Importar Arquivo de rotas";
            this.importarArquivoDeRotasToolStripMenuItem.Click += new System.EventHandler(this.importarArquivoDeRotasToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem1,
            this.movimentaçãoToolStripMenuItem});
            this.relatóriosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.relatóriosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("relatóriosToolStripMenuItem.Image")));
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(90, 21);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.BackColor = System.Drawing.Color.ForestGreen;
            this.clientesToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDestinos);
            this.panel1.Controls.Add(this.btnMotorista);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.bntVeiculo);
            this.panel1.Controls.Add(this.BtnCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 96);
            this.panel1.TabIndex = 11;
            // 
            // btnDestinos
            // 
            this.btnDestinos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDestinos.Image = ((System.Drawing.Image)(resources.GetObject("btnDestinos.Image")));
            this.btnDestinos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDestinos.Location = new System.Drawing.Point(458, 3);
            this.btnDestinos.Name = "btnDestinos";
            this.btnDestinos.Size = new System.Drawing.Size(85, 87);
            this.btnDestinos.TabIndex = 5;
            this.btnDestinos.Text = "Destinos";
            this.btnDestinos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDestinos.UseVisualStyleBackColor = true;
            this.btnDestinos.Click += new System.EventHandler(this.btnDestinos_Click);
            // 
            // btnMotorista
            // 
            this.btnMotorista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMotorista.Image = ((System.Drawing.Image)(resources.GetObject("btnMotorista.Image")));
            this.btnMotorista.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMotorista.Location = new System.Drawing.Point(186, 3);
            this.btnMotorista.Name = "btnMotorista";
            this.btnMotorista.Size = new System.Drawing.Size(85, 87);
            this.btnMotorista.TabIndex = 4;
            this.btnMotorista.Text = "Motorista";
            this.btnMotorista.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMotorista.UseVisualStyleBackColor = true;
            this.btnMotorista.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(273, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 87);
            this.button1.TabIndex = 3;
            this.button1.Text = "Lançamento";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImport.Location = new System.Drawing.Point(546, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(85, 87);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Importar";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // bntVeiculo
            // 
            this.bntVeiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntVeiculo.Image = ((System.Drawing.Image)(resources.GetObject("bntVeiculo.Image")));
            this.bntVeiculo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bntVeiculo.Location = new System.Drawing.Point(99, 3);
            this.bntVeiculo.Name = "bntVeiculo";
            this.bntVeiculo.Size = new System.Drawing.Size(85, 87);
            this.bntVeiculo.TabIndex = 1;
            this.bntVeiculo.Text = "Veículo";
            this.bntVeiculo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntVeiculo.UseVisualStyleBackColor = true;
            this.bntVeiculo.Click += new System.EventHandler(this.bntVeiculo_Click);
            // 
            // BtnCliente
            // 
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnCliente.Image")));
            this.BtnCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCliente.Location = new System.Drawing.Point(12, 3);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(85, 87);
            this.BtnCliente.TabIndex = 0;
            this.BtnCliente.Text = "Cliente";
            this.BtnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCliente.UseVisualStyleBackColor = true;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(938, 329);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(938, 329);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // movimentaçãoToolStripMenuItem
            // 
            this.movimentaçãoToolStripMenuItem.BackColor = System.Drawing.Color.ForestGreen;
            this.movimentaçãoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.movimentaçãoToolStripMenuItem.Name = "movimentaçãoToolStripMenuItem";
            this.movimentaçãoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.movimentaçãoToolStripMenuItem.Text = "Movimentação";
            this.movimentaçãoToolStripMenuItem.Click += new System.EventHandler(this.movimentaçãoToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "****Vnt Route****";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motoristasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarArquivoDeRotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button bntVeiculo;
        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.Button btnMotorista;
        private System.Windows.Forms.Button btnDestinos;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoToolStripMenuItem;
    }
}