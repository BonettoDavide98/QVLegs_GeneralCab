namespace QVLEGS.Wizard
{
    partial class UCStep18Cam1_Foto2
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
            this.nudAreaMinBlack = new QVLEGS.UCNumericUpDown();
            this.btnDrawRect1 = new System.Windows.Forms.Button();
            this.nudAreaMaxBlack = new QVLEGS.UCNumericUpDown();
            this.lblAreaMax = new System.Windows.Forms.Label();
            this.lblThresholdMin = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lblAreaMin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUltimaFoto = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.pbImgHelp = new System.Windows.Forms.PictureBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.ucCheckbox1 = new QVLEGS.UCCheckbox();
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
            this.tableLayoutPanel1.Controls.Add(this.ucCheckbox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudAreaMinBlack, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnDrawRect1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudAreaMaxBlack, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAreaMax, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblThresholdMin, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblAreaMin, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(752, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
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
            // nudAreaMinBlack
            // 
            this.nudAreaMinBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudAreaMinBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudAreaMinBlack.DecimalPlaces = 0;
            this.nudAreaMinBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAreaMinBlack.ForeColor = System.Drawing.Color.White;
            this.nudAreaMinBlack.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAreaMinBlack.Location = new System.Drawing.Point(45, 240);
            this.nudAreaMinBlack.Margin = new System.Windows.Forms.Padding(6);
            this.nudAreaMinBlack.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAreaMinBlack.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudAreaMinBlack.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAreaMinBlack.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudAreaMinBlack.Name = "nudAreaMinBlack";
            this.nudAreaMinBlack.Size = new System.Drawing.Size(250, 40);
            this.nudAreaMinBlack.TabIndex = 50;
            this.nudAreaMinBlack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAreaMinBlack.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAreaMinBlack.Visible = false;
            // 
            // btnDrawRect1
            // 
            this.btnDrawRect1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawRect1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDrawRect1.FlatAppearance.BorderSize = 0;
            this.btnDrawRect1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawRect1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawRect1.ForeColor = System.Drawing.Color.White;
            this.btnDrawRect1.Image = global::QVLEGS.Properties.Resources.imgRettangolo;
            this.btnDrawRect1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawRect1.Location = new System.Drawing.Point(3, 3);
            this.btnDrawRect1.Name = "btnDrawRect1";
            this.btnDrawRect1.Size = new System.Drawing.Size(334, 50);
            this.btnDrawRect1.TabIndex = 45;
            this.btnDrawRect1.Text = "BTN_ROI_1_CAM2";
            this.btnDrawRect1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDrawRect1.UseVisualStyleBackColor = false;
            this.btnDrawRect1.Click += new System.EventHandler(this.btnDrawRect1_Click);
            // 
            // nudAreaMaxBlack
            // 
            this.nudAreaMaxBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudAreaMaxBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudAreaMaxBlack.DecimalPlaces = 0;
            this.nudAreaMaxBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAreaMaxBlack.ForeColor = System.Drawing.Color.White;
            this.nudAreaMaxBlack.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAreaMaxBlack.Location = new System.Drawing.Point(45, 168);
            this.nudAreaMaxBlack.Margin = new System.Windows.Forms.Padding(6);
            this.nudAreaMaxBlack.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAreaMaxBlack.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudAreaMaxBlack.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAreaMaxBlack.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudAreaMaxBlack.Name = "nudAreaMaxBlack";
            this.nudAreaMaxBlack.Size = new System.Drawing.Size(250, 40);
            this.nudAreaMaxBlack.TabIndex = 48;
            this.nudAreaMaxBlack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAreaMaxBlack.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudAreaMaxBlack.Visible = false;
            // 
            // lblAreaMax
            // 
            this.lblAreaMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAreaMax.AutoSize = true;
            this.lblAreaMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblAreaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaMax.ForeColor = System.Drawing.Color.White;
            this.lblAreaMax.Location = new System.Drawing.Point(3, 142);
            this.lblAreaMax.Name = "lblAreaMax";
            this.lblAreaMax.Size = new System.Drawing.Size(250, 20);
            this.lblAreaMax.TabIndex = 49;
            this.lblAreaMax.Text = "LBL_AREA_MAX_BLACK_CAM2";
            this.lblAreaMax.Visible = false;
            // 
            // lblThresholdMin
            // 
            this.lblThresholdMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThresholdMin.AutoSize = true;
            this.lblThresholdMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblThresholdMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThresholdMin.ForeColor = System.Drawing.Color.White;
            this.lblThresholdMin.Location = new System.Drawing.Point(3, 56);
            this.lblThresholdMin.Name = "lblThresholdMin";
            this.lblThresholdMin.Size = new System.Drawing.Size(208, 20);
            this.lblThresholdMin.TabIndex = 0;
            this.lblThresholdMin.Text = "LBL_THRESHOLD_BLACK";
            this.lblThresholdMin.Visible = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 289);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(334, 392);
            this.propertyGrid1.TabIndex = 39;
            // 
            // lblAreaMin
            // 
            this.lblAreaMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAreaMin.AutoSize = true;
            this.lblAreaMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblAreaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaMin.ForeColor = System.Drawing.Color.White;
            this.lblAreaMin.Location = new System.Drawing.Point(3, 214);
            this.lblAreaMin.Name = "lblAreaMin";
            this.lblAreaMin.Size = new System.Drawing.Size(244, 20);
            this.lblAreaMin.TabIndex = 51;
            this.lblAreaMin.Text = "LBL_AREA_MIN_BLACK_CAM2";
            this.lblAreaMin.Visible = false;
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
            this.pbImgHelp.BackgroundImage = global::QVLEGS.Properties.Resources.Cam1foto2_18;
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
            // ucCheckbox1
            // 
            this.ucCheckbox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ucCheckbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCheckbox1.Checked = false;
            this.ucCheckbox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucCheckbox1.Location = new System.Drawing.Point(70, 79);
            this.ucCheckbox1.MaximumSize = new System.Drawing.Size(200, 60);
            this.ucCheckbox1.MinimumSize = new System.Drawing.Size(200, 60);
            this.ucCheckbox1.Name = "ucCheckbox1";
            this.ucCheckbox1.Size = new System.Drawing.Size(200, 60);
            this.ucCheckbox1.TabIndex = 1;
            // 
            // UCStep18Cam1_Foto2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStep18Cam1_Foto2";
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
        private System.Windows.Forms.Label lblThresholdMin;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbImgHelp;
        private System.Windows.Forms.Button btnUltimaFoto;
        private System.Windows.Forms.Button btnDrawRect1;
        private UCNumericUpDown nudAreaMaxBlack;
        private System.Windows.Forms.Label lblAreaMax;
        private UCNumericUpDown nudAreaMinBlack;
        private System.Windows.Forms.Label lblAreaMin;
        private UCCheckbox ucCheckbox1;
    }
}
