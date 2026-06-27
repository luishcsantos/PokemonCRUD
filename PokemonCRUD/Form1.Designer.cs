namespace PokemonCRUD
{
    partial class Form1
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
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.picPokemon = new System.Windows.Forms.PictureBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTipos = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVerSalvos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(44, 40);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(156, 20);
            this.txtBusca.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(44, 78);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(156, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // picPokemon
            // 
            this.picPokemon.Location = new System.Drawing.Point(254, 40);
            this.picPokemon.Name = "picPokemon";
            this.picPokemon.Size = new System.Drawing.Size(208, 204);
            this.picPokemon.TabIndex = 2;
            this.picPokemon.TabStop = false;
            this.picPokemon.Click += new System.EventHandler(this.picPokemon_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(509, 40);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "label1";
            this.lblNome.Click += new System.EventHandler(this.lblNome_Click);
            // 
            // lblTipos
            // 
            this.lblTipos.AutoSize = true;
            this.lblTipos.Location = new System.Drawing.Point(509, 64);
            this.lblTipos.Name = "lblTipos";
            this.lblTipos.Size = new System.Drawing.Size(35, 13);
            this.lblTipos.TabIndex = 4;
            this.lblTipos.Text = "label1";
            this.lblTipos.Click += new System.EventHandler(this.lblTipos_Click);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(509, 88);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(35, 13);
            this.lblAltura.TabIndex = 5;
            this.lblAltura.Text = "label1";
            this.lblAltura.Click += new System.EventHandler(this.lblAltura_Click);
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(509, 111);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(35, 13);
            this.lblPeso.TabIndex = 6;
            this.lblPeso.Text = "label1";
            this.lblPeso.Click += new System.EventHandler(this.lblPeso_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(509, 134);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(35, 13);
            this.lblStats.TabIndex = 7;
            this.lblStats.Text = "label1";
            this.lblStats.Click += new System.EventHandler(this.lblStats_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(254, 272);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(208, 23);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVerSalvos
            // 
            this.btnVerSalvos.Location = new System.Drawing.Point(254, 301);
            this.btnVerSalvos.Name = "btnVerSalvos";
            this.btnVerSalvos.Size = new System.Drawing.Size(208, 23);
            this.btnVerSalvos.TabIndex = 9;
            this.btnVerSalvos.Text = "Ver Pokémons Salvos";
            this.btnVerSalvos.UseVisualStyleBackColor = true;
            this.btnVerSalvos.Click += new System.EventHandler(this.btnVerSalvos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerSalvos);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblTipos);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.picPokemon);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusca);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox picPokemon;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTipos;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVerSalvos;
    }
}

