namespace QVLEGS.Wizard
{
    partial class UCStepTestAllineamento
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
            this.lblMinScore = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.panelShape = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSnap = new System.Windows.Forms.Button();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nudMaxAngolo = new QVLEGS.UCNumericUpDown();
            this.chbLimitaAngolo = new System.Windows.Forms.CheckBox();
            this.lblMaxAngolo = new System.Windows.Forms.Label();
            this.nudMinScore = new QVLEGS.UCNumericUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Size = new System.Drawing.Size(900, 30);
            this.Description.Text = "LBL_STEP_TEST_ALLINEAMENTO";
            // 
            // lblMinScore
            // 
            this.lblMinScore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMinScore.AutoSize = true;
            this.lblMinScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinScore.Location = new System.Drawing.Point(3, 0);
            this.lblMinScore.Name = "lblMinScore";
            this.lblMinScore.Size = new System.Drawing.Size(142, 20);
            this.lblMinScore.TabIndex = 9;
            this.lblMinScore.Text = "LBL_SCORE_MIN";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Image = global::QVLEGS.Properties.Resources.imgStop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(282, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 60);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "LBL_STOP";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Image = global::QVLEGS.Properties.Resources.imgStart;
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(146, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(130, 60);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "LBL_RUN";
            this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panelShape
            // 
            this.panelShape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelShape.Location = new System.Drawing.Point(10, 76);
            this.panelShape.Name = "panelShape";
            this.panelShape.Size = new System.Drawing.Size(537, 360);
            this.panelShape.TabIndex = 36;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 177);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(334, 466);
            this.propertyGrid1.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSnap);
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.panelShape);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 646);
            this.panel1.TabIndex = 38;
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Image = global::QVLEGS.Properties.Resources.imgScattaFoto;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(10, 10);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 45;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.Location = new System.Drawing.Point(10, 439);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(537, 201);
            this.lblDescrizione.TabIndex = 41;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_TEST_ALLINEAMENTO";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nudMaxAngolo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chbLimitaAngolo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMaxAngolo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMinScore, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudMinScore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(568, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // nudMaxAngolo
            // 
            this.nudMaxAngolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxAngolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudMaxAngolo.DecimalPlaces = 0;
            this.nudMaxAngolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxAngolo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxAngolo.Location = new System.Drawing.Point(6, 128);
            this.nudMaxAngolo.Margin = new System.Windows.Forms.Padding(6);
            this.nudMaxAngolo.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudMaxAngolo.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudMaxAngolo.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMaxAngolo.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudMaxAngolo.Name = "nudMaxAngolo";
            this.nudMaxAngolo.Size = new System.Drawing.Size(250, 40);
            this.nudMaxAngolo.TabIndex = 42;
            this.nudMaxAngolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxAngolo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chbLimitaAngolo
            // 
            this.chbLimitaAngolo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbLimitaAngolo.AutoSize = true;
            this.chbLimitaAngolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLimitaAngolo.Location = new System.Drawing.Point(3, 75);
            this.chbLimitaAngolo.Name = "chbLimitaAngolo";
            this.chbLimitaAngolo.Size = new System.Drawing.Size(312, 24);
            this.chbLimitaAngolo.TabIndex = 17;
            this.chbLimitaAngolo.Text = "LBL_LIMITA_ANGOLO_CENTRAGGIO";
            this.chbLimitaAngolo.UseVisualStyleBackColor = true;
            // 
            // lblMaxAngolo
            // 
            this.lblMaxAngolo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaxAngolo.AutoSize = true;
            this.lblMaxAngolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxAngolo.Location = new System.Drawing.Point(3, 102);
            this.lblMaxAngolo.Name = "lblMaxAngolo";
            this.lblMaxAngolo.Size = new System.Drawing.Size(276, 20);
            this.lblMaxAngolo.TabIndex = 43;
            this.lblMaxAngolo.Text = "LBL_MAX_ANGOLO_CENTRAGGIO";
            // 
            // nudMinScore
            // 
            this.nudMinScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudMinScore.DecimalPlaces = 1;
            this.nudMinScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinScore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinScore.Location = new System.Drawing.Point(6, 26);
            this.nudMinScore.Margin = new System.Windows.Forms.Padding(6);
            this.nudMinScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinScore.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudMinScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinScore.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudMinScore.Name = "nudMinScore";
            this.nudMinScore.Size = new System.Drawing.Size(250, 40);
            this.nudMinScore.TabIndex = 8;
            this.nudMinScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMinScore.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // UCStepTestAllineamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "UCStepTestAllineamento";
            this.NextStep = "Step5";
            this.PreviousStep = "Step3";
            this.Size = new System.Drawing.Size(916, 690);
            this.StepDescription = "LBL_STEP_TEST_ALLINEAMENTO";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private UCNumericUpDown nudMinScore;
        private System.Windows.Forms.Label lblMinScore;
        private System.Windows.Forms.Panel panelShape;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.CheckBox chbLimitaAngolo;
        private UCNumericUpDown nudMaxAngolo;
        private System.Windows.Forms.Label lblMaxAngolo;
        private System.Windows.Forms.Button btnSnap;
    }
}
