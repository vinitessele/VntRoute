namespace VntRoute
{
    partial class FrmImport
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportadorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRota = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnListaEnderecos = new System.Windows.Forms.Button();
            this.listBoxDestinos = new System.Windows.Forms.ListBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuáriosToolStripMenuItem,
            this.transportadorasToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            // 
            // transportadorasToolStripMenuItem
            // 
            this.transportadorasToolStripMenuItem.Name = "transportadorasToolStripMenuItem";
            this.transportadorasToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.transportadorasToolStripMenuItem.Text = "Transportadoras";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(150, 150);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(900, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(331, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEndereco);
            this.groupBox1.Controls.Add(this.btnSelecionar);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procurar arquivo";
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndereco.Location = new System.Drawing.Point(125, 30);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(153, 16);
            this.labelEndereco.TabIndex = 1;
            this.labelEndereco.Text = "Endereça do arquivo";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelecionar.Location = new System.Drawing.Point(6, 14);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(113, 44);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Text = "Selecionar arquivo";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRota);
            this.groupBox2.Controls.Add(this.btnAlterar);
            this.groupBox2.Controls.Add(this.btnListaEnderecos);
            this.groupBox2.Controls.Add(this.listBoxDestinos);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 572);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carregar Lista de endereços";
            // 
            // btnRota
            // 
            this.btnRota.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRota.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRota.ForeColor = System.Drawing.Color.Transparent;
            this.btnRota.Location = new System.Drawing.Point(6, 513);
            this.btnRota.Name = "btnRota";
            this.btnRota.Size = new System.Drawing.Size(488, 44);
            this.btnRota.TabIndex = 13;
            this.btnRota.Text = "Gerar Rota";
            this.btnRota.UseVisualStyleBackColor = false;
            this.btnRota.Click += new System.EventHandler(this.btnRota_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.Transparent;
            this.btnAlterar.Location = new System.Drawing.Point(6, 463);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(488, 44);
            this.btnAlterar.TabIndex = 12;
            this.btnAlterar.Text = "Alterar endereço";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnListaEnderecos
            // 
            this.btnListaEnderecos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnListaEnderecos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListaEnderecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaEnderecos.ForeColor = System.Drawing.Color.Transparent;
            this.btnListaEnderecos.Location = new System.Drawing.Point(6, 14);
            this.btnListaEnderecos.Name = "btnListaEnderecos";
            this.btnListaEnderecos.Size = new System.Drawing.Size(488, 44);
            this.btnListaEnderecos.TabIndex = 0;
            this.btnListaEnderecos.Text = "Listar endereços";
            this.btnListaEnderecos.UseVisualStyleBackColor = false;
            this.btnListaEnderecos.Click += new System.EventHandler(this.btnListaEnderecos_Click);
            // 
            // listBoxDestinos
            // 
            this.listBoxDestinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDestinos.FormattingEnabled = true;
            this.listBoxDestinos.ItemHeight = 16;
            this.listBoxDestinos.Location = new System.Drawing.Point(6, 64);
            this.listBoxDestinos.Name = "listBoxDestinos";
            this.listBoxDestinos.Size = new System.Drawing.Size(488, 388);
            this.listBoxDestinos.TabIndex = 11;
            this.listBoxDestinos.DoubleClick += new System.EventHandler(this.listBoxDestinos_DoubleClick);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(527, 53);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(704, 595);
            this.gMapControl1.TabIndex = 11;
            this.gMapControl1.Zoom = 0D;
            // 
            // FrmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1243, 707);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmImport";
            this.Text = "Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportadorasToolStripMenuItem;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnListaEnderecos;
        private System.Windows.Forms.ListBox listBoxDestinos;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRota;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
    }
}

