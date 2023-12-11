namespace QVLEGS
{
    partial class FormWizardClassificatoreGMM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.hMainWndCntrlCamera1 = new HalconDotNet.HWindowControl();
            this.btnFotoNext = new System.Windows.Forms.Button();
            this.lblIstruzioni = new System.Windows.Forms.Label();
            this.btnConferma = new System.Windows.Forms.Button();
            this.dgvDifetti = new System.Windows.Forms.DataGridView();
            this.ColNomeDifetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAggiungiRiga = new System.Windows.Forms.Button();
            this.btnPulisciRiga = new System.Windows.Forms.Button();
            this.lblNomeDifetto = new System.Windows.Forms.Label();
            this.btnFotoPrev = new System.Windows.Forms.Button();
            this.btnStartAcq = new System.Windows.Forms.Button();
            this.btnStopAcq = new System.Windows.Forms.Button();
            this.cmbNomeDifetto = new System.Windows.Forms.ComboBox();
            this.btnTerminaTrain = new System.Windows.Forms.Button();
            this.btnEliminaRiga = new System.Windows.Forms.Button();
            this.lblNumFoto = new System.Windows.Forms.Label();
            this.btnSnap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDifetti)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackColor = System.Drawing.Color.Transparent;
            this.btnChiudi.BackgroundImage = global::QVLEGS.Properties.Resources.chiudi;
            this.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChiudi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChiudi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnChiudi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChiudi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiudi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChiudi.Location = new System.Drawing.Point(978, 3);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(40, 40);
            this.btnChiudi.TabIndex = 341;
            this.btnChiudi.UseVisualStyleBackColor = false;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // hMainWndCntrlCamera1
            // 
            this.hMainWndCntrlCamera1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hMainWndCntrlCamera1.BackColor = System.Drawing.SystemColors.Control;
            this.hMainWndCntrlCamera1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hMainWndCntrlCamera1.BorderColor = System.Drawing.SystemColors.Control;
            this.hMainWndCntrlCamera1.ImagePart = new System.Drawing.Rectangle(0, 0, 836, 580);
            this.hMainWndCntrlCamera1.Location = new System.Drawing.Point(12, 142);
            this.hMainWndCntrlCamera1.Name = "hMainWndCntrlCamera1";
            this.hMainWndCntrlCamera1.Size = new System.Drawing.Size(517, 614);
            this.hMainWndCntrlCamera1.TabIndex = 348;
            this.hMainWndCntrlCamera1.WindowSize = new System.Drawing.Size(517, 614);
            // 
            // btnFotoNext
            // 
            this.btnFotoNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFotoNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnFotoNext.Location = new System.Drawing.Point(241, 411);
            this.btnFotoNext.Name = "btnFotoNext";
            this.btnFotoNext.Size = new System.Drawing.Size(233, 32);
            this.btnFotoNext.TabIndex = 349;
            this.btnFotoNext.Text = "LBL_BTN_FOTO";
            this.btnFotoNext.UseVisualStyleBackColor = true;
            this.btnFotoNext.Click += new System.EventHandler(this.btnFotoNext_Click);
            // 
            // lblIstruzioni
            // 
            this.lblIstruzioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIstruzioni.BackColor = System.Drawing.SystemColors.Control;
            this.lblIstruzioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIstruzioni.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIstruzioni.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIstruzioni.Location = new System.Drawing.Point(7, 3);
            this.lblIstruzioni.Name = "lblIstruzioni";
            this.lblIstruzioni.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIstruzioni.Size = new System.Drawing.Size(959, 100);
            this.lblIstruzioni.TabIndex = 350;
            this.lblIstruzioni.Text = "LBL_RICETTA_CORRENTE";
            this.lblIstruzioni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConferma
            // 
            this.btnConferma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnConferma, 2);
            this.btnConferma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnConferma.Location = new System.Drawing.Point(3, 373);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(471, 32);
            this.btnConferma.TabIndex = 351;
            this.btnConferma.Text = "LBL_BTN_CONFERMA";
            this.btnConferma.UseVisualStyleBackColor = true;
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // dgvDifetti
            // 
            this.dgvDifetti.AllowUserToAddRows = false;
            this.dgvDifetti.AllowUserToDeleteRows = false;
            this.dgvDifetti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDifetti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDifetti.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDifetti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDifetti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDifetti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNomeDifetto});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvDifetti, 2);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDifetti.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDifetti.Location = new System.Drawing.Point(3, 3);
            this.dgvDifetti.MultiSelect = false;
            this.dgvDifetti.Name = "dgvDifetti";
            this.dgvDifetti.ReadOnly = true;
            this.dgvDifetti.Size = new System.Drawing.Size(471, 150);
            this.dgvDifetti.TabIndex = 352;
            this.dgvDifetti.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDifetti_CellEnter);
            // 
            // ColNomeDifetto
            // 
            this.ColNomeDifetto.HeaderText = "LBL_NOME_DIFETTO";
            this.ColNomeDifetto.Name = "ColNomeDifetto";
            this.ColNomeDifetto.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.btnAggiungiRiga, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPulisciRiga, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNomeDifetto, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnFotoPrev, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnConferma, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.dgvDifetti, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartAcq, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStopAcq, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbNomeDifetto, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnTerminaTrain, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.btnFotoNext, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminaRiga, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(538, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 616);
            this.tableLayoutPanel1.TabIndex = 353;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QVLEGS.Properties.Resources.colorPickerNastro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 144);
            this.pictureBox1.TabIndex = 355;
            this.pictureBox1.TabStop = false;
            // 
            // btnAggiungiRiga
            // 
            this.btnAggiungiRiga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAggiungiRiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnAggiungiRiga.Location = new System.Drawing.Point(3, 159);
            this.btnAggiungiRiga.Name = "btnAggiungiRiga";
            this.btnAggiungiRiga.Size = new System.Drawing.Size(232, 32);
            this.btnAggiungiRiga.TabIndex = 359;
            this.btnAggiungiRiga.Text = "LBL_BTN_ADD_ROW";
            this.btnAggiungiRiga.UseVisualStyleBackColor = true;
            this.btnAggiungiRiga.Click += new System.EventHandler(this.btnAggiungiRiga_Click);
            // 
            // btnPulisciRiga
            // 
            this.btnPulisciRiga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPulisciRiga, 2);
            this.btnPulisciRiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnPulisciRiga.Location = new System.Drawing.Point(3, 197);
            this.btnPulisciRiga.Name = "btnPulisciRiga";
            this.btnPulisciRiga.Size = new System.Drawing.Size(471, 32);
            this.btnPulisciRiga.TabIndex = 358;
            this.btnPulisciRiga.Text = "LBL_BTN_CLEAR_ROW";
            this.btnPulisciRiga.UseVisualStyleBackColor = true;
            this.btnPulisciRiga.Click += new System.EventHandler(this.btnPulisciRiga_Click);
            // 
            // lblNomeDifetto
            // 
            this.lblNomeDifetto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNomeDifetto.AutoSize = true;
            this.lblNomeDifetto.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeDifetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblNomeDifetto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNomeDifetto.Location = new System.Drawing.Point(3, 308);
            this.lblNomeDifetto.Name = "lblNomeDifetto";
            this.lblNomeDifetto.Size = new System.Drawing.Size(201, 24);
            this.lblNomeDifetto.TabIndex = 354;
            this.lblNomeDifetto.Text = "LBL_NOME_DIFETTO";
            // 
            // btnFotoPrev
            // 
            this.btnFotoPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFotoPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnFotoPrev.Location = new System.Drawing.Point(3, 411);
            this.btnFotoPrev.Name = "btnFotoPrev";
            this.btnFotoPrev.Size = new System.Drawing.Size(232, 32);
            this.btnFotoPrev.TabIndex = 354;
            this.btnFotoPrev.Text = "LBL_BTN_FOTO";
            this.btnFotoPrev.UseVisualStyleBackColor = true;
            this.btnFotoPrev.Click += new System.EventHandler(this.btnFotoPrev_Click);
            // 
            // btnStartAcq
            // 
            this.btnStartAcq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnStartAcq, 2);
            this.btnStartAcq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnStartAcq.Location = new System.Drawing.Point(3, 235);
            this.btnStartAcq.Name = "btnStartAcq";
            this.btnStartAcq.Size = new System.Drawing.Size(471, 32);
            this.btnStartAcq.TabIndex = 353;
            this.btnStartAcq.Text = "LBL_BTN_START_ACQ";
            this.btnStartAcq.UseVisualStyleBackColor = true;
            this.btnStartAcq.Click += new System.EventHandler(this.btnStartAcq_Click);
            // 
            // btnStopAcq
            // 
            this.btnStopAcq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnStopAcq, 2);
            this.btnStopAcq.Enabled = false;
            this.btnStopAcq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnStopAcq.Location = new System.Drawing.Point(3, 273);
            this.btnStopAcq.Name = "btnStopAcq";
            this.btnStopAcq.Size = new System.Drawing.Size(471, 32);
            this.btnStopAcq.TabIndex = 354;
            this.btnStopAcq.Text = "LBL_BTN_STOP_ACQ";
            this.btnStopAcq.UseVisualStyleBackColor = true;
            this.btnStopAcq.Click += new System.EventHandler(this.btnStopAcq_Click);
            // 
            // cmbNomeDifetto
            // 
            this.cmbNomeDifetto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbNomeDifetto, 2);
            this.cmbNomeDifetto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNomeDifetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNomeDifetto.FormattingEnabled = true;
            this.cmbNomeDifetto.Location = new System.Drawing.Point(3, 335);
            this.cmbNomeDifetto.Name = "cmbNomeDifetto";
            this.cmbNomeDifetto.Size = new System.Drawing.Size(471, 32);
            this.cmbNomeDifetto.TabIndex = 355;
            // 
            // btnTerminaTrain
            // 
            this.btnTerminaTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnTerminaTrain, 2);
            this.btnTerminaTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnTerminaTrain.Location = new System.Drawing.Point(3, 581);
            this.btnTerminaTrain.Name = "btnTerminaTrain";
            this.btnTerminaTrain.Size = new System.Drawing.Size(471, 32);
            this.btnTerminaTrain.TabIndex = 356;
            this.btnTerminaTrain.Text = "LBL_BTN_TERMINA";
            this.btnTerminaTrain.UseVisualStyleBackColor = true;
            this.btnTerminaTrain.Click += new System.EventHandler(this.btnTerminaTrain_Click);
            // 
            // btnEliminaRiga
            // 
            this.btnEliminaRiga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminaRiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnEliminaRiga.Location = new System.Drawing.Point(241, 159);
            this.btnEliminaRiga.Name = "btnEliminaRiga";
            this.btnEliminaRiga.Size = new System.Drawing.Size(233, 32);
            this.btnEliminaRiga.TabIndex = 357;
            this.btnEliminaRiga.Text = "LBL_BTN_DELETE_ROW";
            this.btnEliminaRiga.UseVisualStyleBackColor = true;
            this.btnEliminaRiga.Click += new System.EventHandler(this.btnEliminaRiga_Click);
            // 
            // lblNumFoto
            // 
            this.lblNumFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumFoto.BackColor = System.Drawing.Color.Transparent;
            this.lblNumFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblNumFoto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNumFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumFoto.Location = new System.Drawing.Point(12, 103);
            this.lblNumFoto.Name = "lblNumFoto";
            this.lblNumFoto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNumFoto.Size = new System.Drawing.Size(1003, 36);
            this.lblNumFoto.TabIndex = 354;
            this.lblNumFoto.Text = "X / X";
            this.lblNumFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSnap
            // 
            this.btnSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnap.BackgroundImage = global::QVLEGS.Properties.Resources.btnSalvaFoto_Image;
            this.btnSnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSnap.FlatAppearance.BorderSize = 0;
            this.btnSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Location = new System.Drawing.Point(978, 60);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(40, 40);
            this.btnSnap.TabIndex = 355;
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // FormWizardClassificatoreGMM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.lblNumFoto);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.hMainWndCntrlCamera1);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.lblIstruzioni);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWizardClassificatoreGMM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDifetti)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChiudi;
        private HalconDotNet.HWindowControl hMainWndCntrlCamera1;
        private System.Windows.Forms.Button btnFotoNext;
        public System.Windows.Forms.Label lblIstruzioni;
        private System.Windows.Forms.Button btnConferma;
        private System.Windows.Forms.DataGridView dgvDifetti;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNomeDifetto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStartAcq;
        private System.Windows.Forms.Button btnStopAcq;
        private System.Windows.Forms.ComboBox cmbNomeDifetto;
        private System.Windows.Forms.Button btnTerminaTrain;
        private System.Windows.Forms.Button btnEliminaRiga;
        private System.Windows.Forms.Button btnFotoPrev;
        private System.Windows.Forms.Label lblNomeDifetto;
        private System.Windows.Forms.Button btnPulisciRiga;
        private System.Windows.Forms.Button btnAggiungiRiga;
        public System.Windows.Forms.Label lblNumFoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSnap;
    }
}