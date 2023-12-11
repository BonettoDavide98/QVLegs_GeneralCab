namespace QVLEGS
{
    partial class UCNumericUpDown
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMeno = new System.Windows.Forms.Button();
            this.btnPiu = new System.Windows.Forms.Button();
            this.nud = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nud)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMeno
            // 
            this.btnMeno.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMeno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMeno.FlatAppearance.BorderSize = 0;
            this.btnMeno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeno.ForeColor = System.Drawing.Color.White;
            this.btnMeno.Location = new System.Drawing.Point(6, 6);
            this.btnMeno.Margin = new System.Windows.Forms.Padding(6);
            this.btnMeno.MaximumSize = new System.Drawing.Size(30, 30);
            this.btnMeno.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnMeno.Name = "btnMeno";
            this.btnMeno.Size = new System.Drawing.Size(30, 30);
            this.btnMeno.TabIndex = 0;
            this.btnMeno.Text = "-";
            this.btnMeno.UseVisualStyleBackColor = false;
            this.btnMeno.Click += new System.EventHandler(this.btnMeno_Click);
            this.btnMeno.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMeno_MouseDown);
            this.btnMeno.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMeno_MouseUp);
            // 
            // btnPiu
            // 
            this.btnPiu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPiu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPiu.FlatAppearance.BorderSize = 0;
            this.btnPiu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiu.ForeColor = System.Drawing.Color.White;
            this.btnPiu.Location = new System.Drawing.Point(216, 6);
            this.btnPiu.Margin = new System.Windows.Forms.Padding(6);
            this.btnPiu.MaximumSize = new System.Drawing.Size(30, 30);
            this.btnPiu.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnPiu.Name = "btnPiu";
            this.btnPiu.Size = new System.Drawing.Size(30, 30);
            this.btnPiu.TabIndex = 1;
            this.btnPiu.Text = "+";
            this.btnPiu.UseVisualStyleBackColor = false;
            this.btnPiu.Click += new System.EventHandler(this.btnPiu_Click);
            this.btnPiu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPiu_MouseDown);
            this.btnPiu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPiu_MouseUp);
            // 
            // nud
            // 
            this.nud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud.ForeColor = System.Drawing.Color.White;
            this.nud.Location = new System.Drawing.Point(46, 7);
            this.nud.Margin = new System.Windows.Forms.Padding(6);
            this.nud.Name = "nud";
            this.nud.Size = new System.Drawing.Size(158, 25);
            this.nud.TabIndex = 2;
            this.nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nud.Click += new System.EventHandler(this.nud_Click);
            this.nud.Enter += new System.EventHandler(this.nud_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.nud, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPiu, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMeno, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 40);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // UCNumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(250, 40);
            this.MinimumSize = new System.Drawing.Size(250, 40);
            this.Name = "UCNumericUpDown";
            this.Size = new System.Drawing.Size(250, 40);
            ((System.ComponentModel.ISupportInitialize)(this.nud)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMeno;
        private System.Windows.Forms.Button btnPiu;
        private System.Windows.Forms.NumericUpDown nud;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
