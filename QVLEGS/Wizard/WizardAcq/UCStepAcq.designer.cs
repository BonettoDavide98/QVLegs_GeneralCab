﻿namespace QVLEGS.Wizard
{
    partial class UCStepAcq
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
            this.lblExpo = new System.Windows.Forms.Label();
            this.lblGain = new System.Windows.Forms.Label();
            this.nudExpo = new QVLEGS.UCNumericUpDown();
            this.nudGain = new QVLEGS.UCNumericUpDown();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSnap = new System.Windows.Forms.Button();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Description.ForeColor = System.Drawing.Color.White;
            this.Description.Size = new System.Drawing.Size(900, 30);
            this.Description.Text = "LBL_STEP_ACQ";
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(10, 76);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(537, 360);
            this.panelContainer.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblExpo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblGain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudExpo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudGain, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(568, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblExpo
            // 
            this.lblExpo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpo.AutoSize = true;
            this.lblExpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblExpo.ForeColor = System.Drawing.Color.White;
            this.lblExpo.Location = new System.Drawing.Point(3, 0);
            this.lblExpo.Name = "lblExpo";
            this.lblExpo.Size = new System.Drawing.Size(106, 24);
            this.lblExpo.TabIndex = 0;
            this.lblExpo.Text = "LBL_EXPO";
            // 
            // lblGain
            // 
            this.lblGain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGain.AutoSize = true;
            this.lblGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblGain.ForeColor = System.Drawing.Color.White;
            this.lblGain.Location = new System.Drawing.Point(3, 76);
            this.lblGain.Name = "lblGain";
            this.lblGain.Size = new System.Drawing.Size(97, 24);
            this.lblGain.TabIndex = 1;
            this.lblGain.Text = "LBL_GAIN";
            // 
            // nudExpo
            // 
            this.nudExpo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudExpo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudExpo.DecimalPlaces = 0;
            this.nudExpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudExpo.ForeColor = System.Drawing.Color.White;
            this.nudExpo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudExpo.Location = new System.Drawing.Point(6, 30);
            this.nudExpo.Margin = new System.Windows.Forms.Padding(6);
            this.nudExpo.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudExpo.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudExpo.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudExpo.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudExpo.Name = "nudExpo";
            this.nudExpo.Size = new System.Drawing.Size(250, 40);
            this.nudExpo.TabIndex = 2;
            this.nudExpo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudExpo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudGain
            // 
            this.nudGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudGain.DecimalPlaces = 0;
            this.nudGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGain.ForeColor = System.Drawing.Color.White;
            this.nudGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGain.Location = new System.Drawing.Point(6, 106);
            this.nudGain.Margin = new System.Windows.Forms.Padding(6);
            this.nudGain.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGain.MaximumSize = new System.Drawing.Size(250, 40);
            this.nudGain.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGain.MinimumSize = new System.Drawing.Size(250, 40);
            this.nudGain.Name = "nudGain";
            this.nudGain.Size = new System.Drawing.Size(250, 40);
            this.nudGain.TabIndex = 3;
            this.nudGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGain.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 155);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(334, 488);
            this.propertyGrid1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSnap);
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.panelContainer);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 646);
            this.panel1.TabIndex = 4;
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
            this.btnSnap.Location = new System.Drawing.Point(10, 10);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 43;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Visible = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.ForeColor = System.Drawing.Color.White;
            this.lblDescrizione.Location = new System.Drawing.Point(10, 439);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(537, 201);
            this.lblDescrizione.TabIndex = 42;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_ACQ";
            // 
            // UCStepAcq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStepAcq";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(916, 690);
            this.StepDescription = "LBL_STEP_ACQ";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblExpo;
        private System.Windows.Forms.Label lblGain;
        private UCNumericUpDown nudExpo;
        private UCNumericUpDown nudGain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnSnap;
    }
}
