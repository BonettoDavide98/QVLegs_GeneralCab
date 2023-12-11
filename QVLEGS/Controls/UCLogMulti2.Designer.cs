﻿namespace QVLEGS
{
    partial class UCLogMulti2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ucTabControl = new QVLEGS.UCTabControl();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.panelImage2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.panelImage1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDescrizione = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRagioneScarto2 = new System.Windows.Forms.Label();
            this.lblRagioneScarto1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnIngrandisci = new System.Windows.Forms.Button();
            this.btnDescrizione = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ucTabControl.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageDescrizione.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 304);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2020-11-12 09:00";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ucTabControl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(810, 285);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // ucTabControl
            // 
            this.ucTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.ucTabControl.Controls.Add(this.tabPageImage);
            this.ucTabControl.Controls.Add(this.tabPageDescrizione);
            this.ucTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl.HideTab = true;
            this.ucTabControl.Location = new System.Drawing.Point(63, 3);
            this.ucTabControl.Multiline = true;
            this.ucTabControl.Name = "ucTabControl";
            this.ucTabControl.SelectedIndex = 0;
            this.ucTabControl.Size = new System.Drawing.Size(744, 279);
            this.ucTabControl.TabIndex = 2;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.tableLayoutPanel1);
            this.tabPageImage.Location = new System.Drawing.Point(23, 4);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(717, 271);
            this.tabPageImage.TabIndex = 0;
            this.tabPageImage.Text = "Img";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 265);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lblCam2);
            this.panel2.Controls.Add(this.panelImage2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 265);
            this.panel2.TabIndex = 8;
            // 
            // lblCam2
            // 
            this.lblCam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam2.Location = new System.Drawing.Point(5, 0);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(237, 23);
            this.lblCam2.TabIndex = 8;
            this.lblCam2.Text = "BTN_CAM_2";
            this.lblCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage2
            // 
            this.panelImage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage2.BackColor = System.Drawing.Color.Transparent;
            this.panelImage2.Location = new System.Drawing.Point(8, 27);
            this.panelImage2.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage2.Name = "panelImage2";
            this.panelImage2.Size = new System.Drawing.Size(234, 233);
            this.panelImage2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblCam1);
            this.panel1.Controls.Add(this.panelImage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 265);
            this.panel1.TabIndex = 7;
            // 
            // lblCam1
            // 
            this.lblCam1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam1.Location = new System.Drawing.Point(5, 0);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(237, 23);
            this.lblCam1.TabIndex = 7;
            this.lblCam1.Text = "BTN_CAM_1";
            this.lblCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage1
            // 
            this.panelImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage1.BackColor = System.Drawing.Color.Transparent;
            this.panelImage1.Location = new System.Drawing.Point(8, 27);
            this.panelImage1.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage1.Name = "panelImage1";
            this.panelImage1.Size = new System.Drawing.Size(234, 233);
            this.panelImage1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(503, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 265);
            this.label1.TabIndex = 9;
            this.label1.Text = "MOTIVO SCARTO";
            // 
            // tabPageDescrizione
            // 
            this.tabPageDescrizione.Controls.Add(this.tableLayoutPanel2);
            this.tabPageDescrizione.Location = new System.Drawing.Point(23, 4);
            this.tabPageDescrizione.Name = "tabPageDescrizione";
            this.tabPageDescrizione.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescrizione.Size = new System.Drawing.Size(478, 137);
            this.tabPageDescrizione.TabIndex = 1;
            this.tabPageDescrizione.Text = "Descr";
            this.tabPageDescrizione.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(472, 131);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblRagioneScarto2
            // 
            this.lblRagioneScarto2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto2.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto2.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto2.Location = new System.Drawing.Point(134, 0);
            this.lblRagioneScarto2.Name = "lblRagioneScarto2";
            this.lblRagioneScarto2.Size = new System.Drawing.Size(125, 131);
            this.lblRagioneScarto2.TabIndex = 0;
            this.lblRagioneScarto2.Text = "MOTIVO SCARTO";
            // 
            // lblRagioneScarto1
            // 
            this.lblRagioneScarto1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto1.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto1.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto1.Location = new System.Drawing.Point(3, 0);
            this.lblRagioneScarto1.Name = "lblRagioneScarto1";
            this.lblRagioneScarto1.Size = new System.Drawing.Size(125, 131);
            this.lblRagioneScarto1.TabIndex = 1;
            this.lblRagioneScarto1.Text = "MOTIVO SCARTO";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnIngrandisci);
            this.panel6.Controls.Add(this.btnDescrizione);
            this.panel6.Controls.Add(this.btnImage);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(54, 279);
            this.panel6.TabIndex = 3;
            // 
            // btnIngrandisci
            // 
            this.btnIngrandisci.BackgroundImage = global::QVLEGS.Properties.Resources.img_ingrandisci;
            this.btnIngrandisci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIngrandisci.Location = new System.Drawing.Point(7, 92);
            this.btnIngrandisci.Name = "btnIngrandisci";
            this.btnIngrandisci.Size = new System.Drawing.Size(40, 40);
            this.btnIngrandisci.TabIndex = 2;
            this.btnIngrandisci.UseVisualStyleBackColor = true;
            this.btnIngrandisci.Click += new System.EventHandler(this.btnIngrandisci_Click);
            // 
            // btnDescrizione
            // 
            this.btnDescrizione.BackgroundImage = global::QVLEGS.Properties.Resources.img_text;
            this.btnDescrizione.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDescrizione.Location = new System.Drawing.Point(7, 49);
            this.btnDescrizione.Name = "btnDescrizione";
            this.btnDescrizione.Size = new System.Drawing.Size(40, 40);
            this.btnDescrizione.TabIndex = 1;
            this.btnDescrizione.UseVisualStyleBackColor = true;
            this.btnDescrizione.Click += new System.EventHandler(this.btnDescrizione_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::QVLEGS.Properties.Resources.iconfinder_icon_image_211677_1_;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImage.Location = new System.Drawing.Point(7, 7);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(40, 40);
            this.btnImage.TabIndex = 0;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // UCLogMulti2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCLogMulti2";
            this.Size = new System.Drawing.Size(816, 304);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ucTabControl.ResumeLayout(false);
            this.tabPageImage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageDescrizione.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelImage1;
        private System.Windows.Forms.Panel panelImage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblRagioneScarto2;
        private System.Windows.Forms.Label lblRagioneScarto1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private UCTabControl ucTabControl;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.TabPage tabPageDescrizione;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnIngrandisci;
        private System.Windows.Forms.Button btnDescrizione;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.Label lblCam1;
    }
}
