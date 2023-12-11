namespace QVLEGS.Wizard
{
    partial class UCStep1Cam5_Foto2
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
            this.btnDisegnaRettangolo = new System.Windows.Forms.Button();
            this.lblThresholdMax = new System.Windows.Forms.Label();
            this.nudThreshold = new QVLEGS.UCNumericUpDown();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.nudDistMax = new QVLEGS.UCNumericUpDown();
            this.lblDistMax = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Controls.Add(this.btnDisegnaRettangolo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblThresholdMax, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudThreshold, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.nudDistMax, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDistMax, 0, 5);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // btnDisegnaRettangolo
            // 
            this.btnDisegnaRettangolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisegnaRettangolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisegnaRettangolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaRettangolo.ForeColor = System.Drawing.Color.White;
            this.btnDisegnaRettangolo.Image = global::QVLEGS.Properties.Resources.imgRettangolo;
            this.btnDisegnaRettangolo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaRettangolo.Location = new System.Drawing.Point(3, 3);
            this.btnDisegnaRettangolo.Name = "btnDisegnaRettangolo";
            this.btnDisegnaRettangolo.Size = new System.Drawing.Size(334, 60);
            this.btnDisegnaRettangolo.TabIndex = 45;
            this.btnDisegnaRettangolo.Text = "BTN_ROI_LEFT_CAM2";
            this.btnDisegnaRettangolo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaRettangolo.UseVisualStyleBackColor = false;
            this.btnDisegnaRettangolo.Click += new System.EventHandler(this.btnDisegnaRettangolo_Click);
            // 
            // lblThresholdMax
            // 
            this.lblThresholdMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThresholdMax.AutoSize = true;
            this.lblThresholdMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblThresholdMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThresholdMax.ForeColor = System.Drawing.Color.White;
            this.lblThresholdMax.Location = new System.Drawing.Point(3, 66);
            this.lblThresholdMax.Name = "lblThresholdMax";
            this.lblThresholdMax.Size = new System.Drawing.Size(248, 20);
            this.lblThresholdMax.TabIndex = 46;
            this.lblThresholdMax.Text = "LBL_THRESHOLD_LEFT_CAM2";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudThreshold.DecimalPlaces = 0;
            this.nudThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Location = new System.Drawing.Point(45, 92);
            this.nudThreshold.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThreshold.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudThreshold.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudThreshold.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(250, 40);
            this.nudThreshold.TabIndex = 46;
            this.nudThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudThreshold.Value = new decimal(new int[] {
            100,
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
            this.propertyGrid1.Size = new System.Drawing.Size(334, 430);
            this.propertyGrid1.TabIndex = 39;
            // 
            // nudDistMax
            // 
            this.nudDistMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudDistMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudDistMax.DecimalPlaces = 1;
            this.nudDistMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDistMax.Location = new System.Drawing.Point(45, 164);
            this.nudDistMax.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudDistMax.Maximum = new decimal(new int[] {
            100000,
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
            this.nudDistMax.TabIndex = 48;
            this.nudDistMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDistMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblDistMax
            // 
            this.lblDistMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistMax.AutoSize = true;
            this.lblDistMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDistMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistMax.ForeColor = System.Drawing.Color.White;
            this.lblDistMax.Location = new System.Drawing.Point(3, 138);
            this.lblDistMax.Name = "lblDistMax";
            this.lblDistMax.Size = new System.Drawing.Size(184, 20);
            this.lblDistMax.TabIndex = 49;
            this.lblDistMax.Text = "LBL_AREA_MAX_LEFT";
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
            // UCStep1Cam5_Foto2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStep1Cam5_Foto2";
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
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLog;
        private UCNumericUpDown nudThreshold;
        private System.Windows.Forms.Label lblThresholdMax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbImgHelp;
        private System.Windows.Forms.Button btnUltimaFoto;
        private System.Windows.Forms.Button btnDisegnaRettangolo;
        private UCNumericUpDown nudDistMax;
        private System.Windows.Forms.Label lblDistMax;
    }
}
