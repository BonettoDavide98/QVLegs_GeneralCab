namespace QVLEGS.Wizard
{
    partial class UCStep5Cam3_Foto1
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nudDistMax = new QVLEGS.UCNumericUpDown();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.nudDistMin = new QVLEGS.UCNumericUpDown();
            this.lblDistMin = new System.Windows.Forms.Label();
            this.lblDistMax = new System.Windows.Forms.Label();
            this.btnDrawCircle1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUltimaFoto = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.pbImgHelp = new System.Windows.Forms.PictureBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Description.ForeColor = System.Drawing.Color.White;
            this.Description.Size = new System.Drawing.Size(1084, 30);
            this.Description.Text = "LBL_STEP_INTEGRITA";
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(10, 76);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(721, 360);
            this.panelContainer.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nudDistMax, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.nudDistMin, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblDistMin, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDistMax, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDrawCircle1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(752, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // nudDistMax
            // 
            this.nudDistMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudDistMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudDistMax.DecimalPlaces = 1;
            this.nudDistMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistMax.ForeColor = System.Drawing.Color.White;
            this.nudDistMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDistMax.Location = new System.Drawing.Point(45, 92);
            this.nudDistMax.Margin = new System.Windows.Forms.Padding(6);
            this.nudDistMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDistMax.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudDistMax.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDistMax.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudDistMax.Name = "nudDistMax";
            this.nudDistMax.Size = new System.Drawing.Size(250, 40);
            this.nudDistMax.TabIndex = 47;
            this.nudDistMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDistMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 213);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(334, 460);
            this.propertyGrid1.TabIndex = 39;
            // 
            // nudDistMin
            // 
            this.nudDistMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudDistMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudDistMin.DecimalPlaces = 1;
            this.nudDistMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistMin.ForeColor = System.Drawing.Color.White;
            this.nudDistMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDistMin.Location = new System.Drawing.Point(45, 164);
            this.nudDistMin.Margin = new System.Windows.Forms.Padding(6);
            this.nudDistMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDistMin.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudDistMin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDistMin.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudDistMin.Name = "nudDistMin";
            this.nudDistMin.Size = new System.Drawing.Size(250, 40);
            this.nudDistMin.TabIndex = 48;
            this.nudDistMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDistMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblDistMin
            // 
            this.lblDistMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistMin.AutoSize = true;
            this.lblDistMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDistMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistMin.ForeColor = System.Drawing.Color.White;
            this.lblDistMin.Location = new System.Drawing.Point(3, 138);
            this.lblDistMin.Name = "lblDistMin";
            this.lblDistMin.Size = new System.Drawing.Size(193, 20);
            this.lblDistMin.TabIndex = 49;
            this.lblDistMin.Text = "LBL_DIST_MIN_1_CAM3";
            // 
            // lblDistMax
            // 
            this.lblDistMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistMax.AutoSize = true;
            this.lblDistMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDistMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistMax.ForeColor = System.Drawing.Color.White;
            this.lblDistMax.Location = new System.Drawing.Point(3, 66);
            this.lblDistMax.Name = "lblDistMax";
            this.lblDistMax.Size = new System.Drawing.Size(199, 20);
            this.lblDistMax.TabIndex = 0;
            this.lblDistMax.Text = "LBL_DIST_MAX_1_CAM3";
            // 
            // btnDrawCircle1
            // 
            this.btnDrawCircle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawCircle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDrawCircle1.FlatAppearance.BorderSize = 0;
            this.btnDrawCircle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawCircle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawCircle1.ForeColor = System.Drawing.Color.White;
            this.btnDrawCircle1.Image = global::QVLEGS.Properties.Resources.imgRettangolo;
            this.btnDrawCircle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawCircle1.Location = new System.Drawing.Point(3, 3);
            this.btnDrawCircle1.Name = "btnDrawCircle1";
            this.btnDrawCircle1.Size = new System.Drawing.Size(334, 60);
            this.btnDrawCircle1.TabIndex = 45;
            this.btnDrawCircle1.Text = "BTN_ROI_CAM_3";
            this.btnDrawCircle1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDrawCircle1.UseVisualStyleBackColor = false;
            this.btnDrawCircle1.Click += new System.EventHandler(this.btnDrawCircle1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnUltimaFoto);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.panelContainer);
            this.panel1.Controls.Add(this.btnSnap);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 646);
            this.panel1.TabIndex = 40;
            // 
            // btnUltimaFoto
            // 
            this.btnUltimaFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUltimaFoto.FlatAppearance.BorderSize = 0;
            this.btnUltimaFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimaFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaFoto.ForeColor = System.Drawing.Color.White;
            this.btnUltimaFoto.Image = global::QVLEGS.Properties.Resources.img;
            this.btnUltimaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimaFoto.Location = new System.Drawing.Point(282, 10);
            this.btnUltimaFoto.Name = "btnUltimaFoto";
            this.btnUltimaFoto.Size = new System.Drawing.Size(130, 60);
            this.btnUltimaFoto.TabIndex = 46;
            this.btnUltimaFoto.Text = "BTN_ULTIMA_FOTO";
            this.btnUltimaFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimaFoto.UseVisualStyleBackColor = false;
            this.btnUltimaFoto.Click += new System.EventHandler(this.btnUltimaFoto_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lblDescrizione, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbImgHelp, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 442);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(728, 201);
            this.tableLayoutPanel2.TabIndex = 45;
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescrizione.ForeColor = System.Drawing.Color.White;
            this.lblDescrizione.Location = new System.Drawing.Point(3, 0);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(430, 201);
            this.lblDescrizione.TabIndex = 42;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_INTEGRITA";
            // 
            // pbImgHelp
            // 
            this.pbImgHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImgHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImgHelp.Location = new System.Drawing.Point(439, 3);
            this.pbImgHelp.Name = "pbImgHelp";
            this.pbImgHelp.Size = new System.Drawing.Size(286, 195);
            this.pbImgHelp.TabIndex = 43;
            this.pbImgHelp.TabStop = false;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Image = global::QVLEGS.Properties.Resources.img_log;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(418, 10);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(130, 60);
            this.btnLog.TabIndex = 44;
            this.btnLog.Text = "BTN_LOG";
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Image = global::QVLEGS.Properties.Resources.reloadPiccolo2;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(10, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(130, 60);
            this.btnTest.TabIndex = 43;
            this.btnTest.Text = "BTN_TEST";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSnap.FlatAppearance.BorderSize = 0;
            this.btnSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.ForeColor = System.Drawing.Color.White;
            this.btnSnap.Image = global::QVLEGS.Properties.Resources.imgScattaFoto;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(146, 10);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 11;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Visible = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // UCStep5Cam3_Foto1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStep5Cam3_Foto1";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(1100, 690);
            this.StepDescription = "LBL_STEP_INTEGRITA";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDistMax;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbImgHelp;
        private System.Windows.Forms.Button btnUltimaFoto;
        private System.Windows.Forms.Button btnDrawCircle1;
        private UCNumericUpDown nudDistMax;
        private UCNumericUpDown nudDistMin;
        private System.Windows.Forms.Label lblDistMin;
    }
}
