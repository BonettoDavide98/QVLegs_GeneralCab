namespace QVLEGS
{
    partial class FormWizardMaskCamera
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
            this.btnChiudi = new System.Windows.Forms.Button();
            this.lblIstruzioni = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStartAcq = new System.Windows.Forms.Button();
            this.btnStopAcq = new System.Windows.Forms.Button();
            this.btnTerminaTrain = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisegnaManoAdd = new System.Windows.Forms.Button();
            this.btnDisegnaManoRem = new System.Windows.Forms.Button();
            this.trackBarDimensione = new System.Windows.Forms.TrackBar();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensione)).BeginInit();
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
            this.lblIstruzioni.Text = "LBL_ISTRUZIONI_STEP_MASK";
            this.lblIstruzioni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnStartAcq, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStopAcq, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTerminaTrain, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(538, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 616);
            this.tableLayoutPanel1.TabIndex = 353;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 469);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 144);
            this.pictureBox1.TabIndex = 355;
            this.pictureBox1.TabStop = false;
            // 
            // btnStartAcq
            // 
            this.btnStartAcq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnStartAcq, 2);
            this.btnStartAcq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnStartAcq.Location = new System.Drawing.Point(3, 3);
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
            this.btnStopAcq.Location = new System.Drawing.Point(3, 41);
            this.btnStopAcq.Name = "btnStopAcq";
            this.btnStopAcq.Size = new System.Drawing.Size(471, 32);
            this.btnStopAcq.TabIndex = 354;
            this.btnStopAcq.Text = "LBL_BTN_STOP_ACQ";
            this.btnStopAcq.UseVisualStyleBackColor = true;
            this.btnStopAcq.Click += new System.EventHandler(this.btnStopAcq_Click);
            // 
            // btnTerminaTrain
            // 
            this.btnTerminaTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnTerminaTrain, 2);
            this.btnTerminaTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnTerminaTrain.Location = new System.Drawing.Point(3, 214);
            this.btnTerminaTrain.Name = "btnTerminaTrain";
            this.btnTerminaTrain.Size = new System.Drawing.Size(471, 32);
            this.btnTerminaTrain.TabIndex = 356;
            this.btnTerminaTrain.Text = "LBL_BTN_TERMINA";
            this.btnTerminaTrain.UseVisualStyleBackColor = true;
            this.btnTerminaTrain.Click += new System.EventHandler(this.btnTerminaTrain_Click);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnDisegnaManoAdd);
            this.panel1.Controls.Add(this.btnDisegnaManoRem);
            this.panel1.Controls.Add(this.trackBarDimensione);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 129);
            this.panel1.TabIndex = 358;
            // 
            // btnDisegnaManoAdd
            // 
            this.btnDisegnaManoAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaManoAdd.Image = global::QVLEGS.Properties.Resources.imgDisegna;
            this.btnDisegnaManoAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaManoAdd.Location = new System.Drawing.Point(3, 3);
            this.btnDisegnaManoAdd.Name = "btnDisegnaManoAdd";
            this.btnDisegnaManoAdd.Size = new System.Drawing.Size(130, 60);
            this.btnDisegnaManoAdd.TabIndex = 355;
            this.btnDisegnaManoAdd.Text = "BTN_MANO_LIBERA";
            this.btnDisegnaManoAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaManoAdd.UseVisualStyleBackColor = true;
            this.btnDisegnaManoAdd.Click += new System.EventHandler(this.btnDisegnaManoAdd_Click);
            // 
            // btnDisegnaManoRem
            // 
            this.btnDisegnaManoRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaManoRem.Image = global::QVLEGS.Properties.Resources.imgGomma;
            this.btnDisegnaManoRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaManoRem.Location = new System.Drawing.Point(139, 3);
            this.btnDisegnaManoRem.Name = "btnDisegnaManoRem";
            this.btnDisegnaManoRem.Size = new System.Drawing.Size(130, 60);
            this.btnDisegnaManoRem.TabIndex = 356;
            this.btnDisegnaManoRem.Text = "BTN_GOMMA";
            this.btnDisegnaManoRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaManoRem.UseVisualStyleBackColor = true;
            this.btnDisegnaManoRem.Click += new System.EventHandler(this.btnDisegnaManoRem_Click);
            // 
            // trackBarDimensione
            // 
            this.trackBarDimensione.Location = new System.Drawing.Point(3, 69);
            this.trackBarDimensione.Maximum = 620;
            this.trackBarDimensione.Minimum = 20;
            this.trackBarDimensione.Name = "trackBarDimensione";
            this.trackBarDimensione.Size = new System.Drawing.Size(266, 45);
            this.trackBarDimensione.TabIndex = 357;
            this.trackBarDimensione.TickFrequency = 40;
            this.trackBarDimensione.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarDimensione.Value = 20;
            this.trackBarDimensione.Scroll += new System.EventHandler(this.trackBarDimensione_Scroll);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(12, 142);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(517, 614);
            this.panelContainer.TabIndex = 355;
            // 
            // FormWizardMaskCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.lblIstruzioni);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWizardMaskCamera";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensione)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChiudi;
        public System.Windows.Forms.Label lblIstruzioni;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStartAcq;
        private System.Windows.Forms.Button btnStopAcq;
        private System.Windows.Forms.Button btnTerminaTrain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDisegnaManoAdd;
        private System.Windows.Forms.Button btnDisegnaManoRem;
        private System.Windows.Forms.TrackBar trackBarDimensione;
        private System.Windows.Forms.Panel panelContainer;
    }
}