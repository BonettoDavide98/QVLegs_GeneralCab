namespace QVLEGS.Pagine
{
    partial class UCPaginaRicette
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.dvgFormatiIntestazione = new System.Windows.Forms.DataGridView();
            this.dgvColDescrizioneFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImporta = new System.Windows.Forms.Button();
            this.dgvColIdFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatoIntestazioneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEsporta = new System.Windows.Forms.Button();
            this.btnCopiaFormato = new System.Windows.Forms.Button();
            this.btnNuovoFormato = new System.Windows.Forms.Button();
            this.btnEliminaFormatoGenerale = new System.Windows.Forms.Button();
            this.btnCaricaFormatoAllCamera = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFormatiIntestazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatoIntestazioneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnImporta, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnEsporta, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnCopiaFormato, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnNuovoFormato, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEliminaFormatoGenerale, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnCaricaFormatoAllCamera, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(696, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 372);
            this.tableLayoutPanel2.TabIndex = 43;
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitolo.ForeColor = System.Drawing.Color.White;
            this.lblTitolo.Location = new System.Drawing.Point(3, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(849, 32);
            this.lblTitolo.TabIndex = 40;
            this.lblTitolo.Text = "LBL_FRM_FORMATI";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dvgFormatiIntestazione
            // 
            this.dvgFormatiIntestazione.AllowUserToAddRows = false;
            this.dvgFormatiIntestazione.AllowUserToDeleteRows = false;
            this.dvgFormatiIntestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgFormatiIntestazione.AutoGenerateColumns = false;
            this.dvgFormatiIntestazione.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgFormatiIntestazione.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgFormatiIntestazione.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dvgFormatiIntestazione.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFormatiIntestazione.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColIdFormato,
            this.dgvColDescrizioneFormato});
            this.dvgFormatiIntestazione.DataSource = this.formatoIntestazioneBindingSource;
            this.dvgFormatiIntestazione.Location = new System.Drawing.Point(0, 35);
            this.dvgFormatiIntestazione.MultiSelect = false;
            this.dvgFormatiIntestazione.Name = "dvgFormatiIntestazione";
            this.dvgFormatiIntestazione.ReadOnly = true;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgFormatiIntestazione.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dvgFormatiIntestazione.RowTemplate.Height = 35;
            this.dvgFormatiIntestazione.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgFormatiIntestazione.Size = new System.Drawing.Size(690, 402);
            this.dvgFormatiIntestazione.TabIndex = 44;
            // 
            // dgvColDescrizioneFormato
            // 
            this.dgvColDescrizioneFormato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColDescrizioneFormato.DataPropertyName = "DescrizioneFormato";
            this.dgvColDescrizioneFormato.HeaderText = "LBL_DESCRIZIONE";
            this.dgvColDescrizioneFormato.Name = "dgvColDescrizioneFormato";
            this.dgvColDescrizioneFormato.ReadOnly = true;
            // 
            // btnImporta
            // 
            this.btnImporta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnImporta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImporta.FlatAppearance.BorderSize = 0;
            this.btnImporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImporta.ForeColor = System.Drawing.Color.White;
            this.btnImporta.Image = global::QVLEGS.Properties.Resources.LoadFrom_32x32;
            this.btnImporta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImporta.Location = new System.Drawing.Point(3, 297);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(154, 72);
            this.btnImporta.TabIndex = 47;
            this.btnImporta.Text = "BTN_IMPORT";
            this.btnImporta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImporta.UseVisualStyleBackColor = false;
            this.btnImporta.Click += new System.EventHandler(this.btnImporta_Click);
            // 
            // dgvColIdFormato
            // 
            this.dgvColIdFormato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvColIdFormato.DataPropertyName = "IdFormato";
            this.dgvColIdFormato.HeaderText = "LBL_ID";
            this.dgvColIdFormato.Name = "dgvColIdFormato";
            this.dgvColIdFormato.ReadOnly = true;
            this.dgvColIdFormato.Width = 94;
            // 
            // formatoIntestazioneBindingSource
            // 
            this.formatoIntestazioneBindingSource.DataSource = typeof(QVLEGS.DataType.Formato);
            // 
            // btnEsporta
            // 
            this.btnEsporta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEsporta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEsporta.FlatAppearance.BorderSize = 0;
            this.btnEsporta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEsporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEsporta.ForeColor = System.Drawing.Color.White;
            this.btnEsporta.Image = global::QVLEGS.Properties.Resources.Export_32x32;
            this.btnEsporta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEsporta.Location = new System.Drawing.Point(3, 223);
            this.btnEsporta.Name = "btnEsporta";
            this.btnEsporta.Size = new System.Drawing.Size(154, 68);
            this.btnEsporta.TabIndex = 46;
            this.btnEsporta.Text = "BTN_EXPORT";
            this.btnEsporta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEsporta.UseVisualStyleBackColor = false;
            this.btnEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
            // 
            // btnCopiaFormato
            // 
            this.btnCopiaFormato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCopiaFormato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopiaFormato.FlatAppearance.BorderSize = 0;
            this.btnCopiaFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiaFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCopiaFormato.ForeColor = System.Drawing.Color.White;
            this.btnCopiaFormato.Image = global::QVLEGS.Properties.Resources.imgCopia;
            this.btnCopiaFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiaFormato.Location = new System.Drawing.Point(3, 58);
            this.btnCopiaFormato.Name = "btnCopiaFormato";
            this.btnCopiaFormato.Size = new System.Drawing.Size(154, 49);
            this.btnCopiaFormato.TabIndex = 45;
            this.btnCopiaFormato.Text = "BTN_COPIA";
            this.btnCopiaFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiaFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopiaFormato.UseVisualStyleBackColor = false;
            this.btnCopiaFormato.Click += new System.EventHandler(this.btnCopiaFormato_Click);
            // 
            // btnNuovoFormato
            // 
            this.btnNuovoFormato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnNuovoFormato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuovoFormato.FlatAppearance.BorderSize = 0;
            this.btnNuovoFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuovoFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNuovoFormato.ForeColor = System.Drawing.Color.White;
            this.btnNuovoFormato.Image = global::QVLEGS.Properties.Resources.imgNuovo;
            this.btnNuovoFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuovoFormato.Location = new System.Drawing.Point(3, 3);
            this.btnNuovoFormato.Name = "btnNuovoFormato";
            this.btnNuovoFormato.Size = new System.Drawing.Size(154, 49);
            this.btnNuovoFormato.TabIndex = 28;
            this.btnNuovoFormato.Text = "BTN_NUOVO";
            this.btnNuovoFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuovoFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuovoFormato.UseVisualStyleBackColor = false;
            this.btnNuovoFormato.Click += new System.EventHandler(this.btnNuovoFormato_Click);
            // 
            // btnEliminaFormatoGenerale
            // 
            this.btnEliminaFormatoGenerale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEliminaFormatoGenerale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminaFormatoGenerale.FlatAppearance.BorderSize = 0;
            this.btnEliminaFormatoGenerale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminaFormatoGenerale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEliminaFormatoGenerale.ForeColor = System.Drawing.Color.White;
            this.btnEliminaFormatoGenerale.Image = global::QVLEGS.Properties.Resources.imgGomma;
            this.btnEliminaFormatoGenerale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminaFormatoGenerale.Location = new System.Drawing.Point(3, 113);
            this.btnEliminaFormatoGenerale.Name = "btnEliminaFormatoGenerale";
            this.btnEliminaFormatoGenerale.Size = new System.Drawing.Size(154, 49);
            this.btnEliminaFormatoGenerale.TabIndex = 37;
            this.btnEliminaFormatoGenerale.Text = "BTN_ELIMINA";
            this.btnEliminaFormatoGenerale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminaFormatoGenerale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminaFormatoGenerale.UseVisualStyleBackColor = false;
            this.btnEliminaFormatoGenerale.Click += new System.EventHandler(this.btnEliminaFormatoGenerale_Click);
            // 
            // btnCaricaFormatoAllCamera
            // 
            this.btnCaricaFormatoAllCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCaricaFormatoAllCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCaricaFormatoAllCamera.FlatAppearance.BorderSize = 0;
            this.btnCaricaFormatoAllCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaricaFormatoAllCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCaricaFormatoAllCamera.ForeColor = System.Drawing.Color.White;
            this.btnCaricaFormatoAllCamera.Image = global::QVLEGS.Properties.Resources.imgApplica;
            this.btnCaricaFormatoAllCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaricaFormatoAllCamera.Location = new System.Drawing.Point(3, 168);
            this.btnCaricaFormatoAllCamera.Name = "btnCaricaFormatoAllCamera";
            this.btnCaricaFormatoAllCamera.Size = new System.Drawing.Size(154, 49);
            this.btnCaricaFormatoAllCamera.TabIndex = 35;
            this.btnCaricaFormatoAllCamera.Text = "BTN_CARICA ";
            this.btnCaricaFormatoAllCamera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCaricaFormatoAllCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaricaFormatoAllCamera.UseVisualStyleBackColor = false;
            this.btnCaricaFormatoAllCamera.Click += new System.EventHandler(this.btnCaricaFormatoAllCamera_Click);
            // 
            // UCPaginaRicette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.dvgFormatiIntestazione);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblTitolo);
            this.Name = "UCPaginaRicette";
            this.Size = new System.Drawing.Size(859, 440);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFormatiIntestazione)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatoIntestazioneBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnNuovoFormato;
        private System.Windows.Forms.Button btnEliminaFormatoGenerale;
        private System.Windows.Forms.Button btnCaricaFormatoAllCamera;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.BindingSource formatoIntestazioneBindingSource;
        private System.Windows.Forms.DataGridView dvgFormatiIntestazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColIdFormato;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColDescrizioneFormato;
        private System.Windows.Forms.Button btnCopiaFormato;
        private System.Windows.Forms.Button btnEsporta;
        private System.Windows.Forms.Button btnImporta;
    }
}
