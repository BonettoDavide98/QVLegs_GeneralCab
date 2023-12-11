namespace QVLEGS.Wizard
{
    partial class UCStepTrainAllineamento
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
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.trackBarDimensione = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisegnaManoAdd = new System.Windows.Forms.Button();
            this.btnDisegnaManoRem = new System.Windows.Forms.Button();
            this.btnDisegnaRettangolo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUltimaFoto = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbImgHelp = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensione)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Size = new System.Drawing.Size(1084, 30);
            this.Description.Text = "LBL_STEP_TRAIN_ALLINEAMENTO";
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
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescrizione.Location = new System.Drawing.Point(3, 0);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(432, 201);
            this.lblDescrizione.TabIndex = 40;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_TRAIN_ALLINEAMENTO";
            // 
            // trackBarDimensione
            // 
            this.trackBarDimensione.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.trackBarDimensione.Location = new System.Drawing.Point(3, 69);
            this.trackBarDimensione.Maximum = 620;
            this.trackBarDimensione.Minimum = 20;
            this.trackBarDimensione.Name = "trackBarDimensione";
            this.trackBarDimensione.Size = new System.Drawing.Size(266, 45);
            this.trackBarDimensione.TabIndex = 46;
            this.trackBarDimensione.TickFrequency = 40;
            this.trackBarDimensione.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarDimensione.Value = 20;
            this.trackBarDimensione.Scroll += new System.EventHandler(this.trackBarDimensione_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDisegnaRettangolo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(752, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDisegnaManoAdd);
            this.panel1.Controls.Add(this.trackBarDimensione);
            this.panel1.Controls.Add(this.btnDisegnaManoRem);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 127);
            this.panel1.TabIndex = 51;
            // 
            // btnDisegnaManoAdd
            // 
            this.btnDisegnaManoAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisegnaManoAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaManoAdd.Image = global::QVLEGS.Properties.Resources.imgDisegna;
            this.btnDisegnaManoAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaManoAdd.Location = new System.Drawing.Point(3, 3);
            this.btnDisegnaManoAdd.Name = "btnDisegnaManoAdd";
            this.btnDisegnaManoAdd.Size = new System.Drawing.Size(130, 60);
            this.btnDisegnaManoAdd.TabIndex = 43;
            this.btnDisegnaManoAdd.Text = "BTN_MANO_LIBERA";
            this.btnDisegnaManoAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaManoAdd.UseVisualStyleBackColor = false;
            this.btnDisegnaManoAdd.Click += new System.EventHandler(this.btnDisegnaManoAdd_Click);
            // 
            // btnDisegnaManoRem
            // 
            this.btnDisegnaManoRem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisegnaManoRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaManoRem.Image = global::QVLEGS.Properties.Resources.imgGomma;
            this.btnDisegnaManoRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaManoRem.Location = new System.Drawing.Point(139, 3);
            this.btnDisegnaManoRem.Name = "btnDisegnaManoRem";
            this.btnDisegnaManoRem.Size = new System.Drawing.Size(130, 60);
            this.btnDisegnaManoRem.TabIndex = 45;
            this.btnDisegnaManoRem.Text = "BTN_GOMMA";
            this.btnDisegnaManoRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaManoRem.UseVisualStyleBackColor = false;
            this.btnDisegnaManoRem.Click += new System.EventHandler(this.btnDisegnaManoRem_Click);
            // 
            // btnDisegnaRettangolo
            // 
            this.btnDisegnaRettangolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisegnaRettangolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisegnaRettangolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaRettangolo.Image = global::QVLEGS.Properties.Resources.imgRettangolo;
            this.btnDisegnaRettangolo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaRettangolo.Location = new System.Drawing.Point(3, 136);
            this.btnDisegnaRettangolo.Name = "btnDisegnaRettangolo";
            this.btnDisegnaRettangolo.Size = new System.Drawing.Size(334, 60);
            this.btnDisegnaRettangolo.TabIndex = 42;
            this.btnDisegnaRettangolo.Text = "BTN_ROI_TRAIN";
            this.btnDisegnaRettangolo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaRettangolo.UseVisualStyleBackColor = false;
            this.btnDisegnaRettangolo.Click += new System.EventHandler(this.btnDisegnaRettangolo_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnUltimaFoto);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.btnTest);
            this.panel2.Controls.Add(this.panelContainer);
            this.panel2.Controls.Add(this.btnSnap);
            this.panel2.Controls.Add(this.btnTrain);
            this.panel2.Location = new System.Drawing.Point(12, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 646);
            this.panel2.TabIndex = 51;
            // 
            // btnUltimaFoto
            // 
            this.btnUltimaFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUltimaFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaFoto.Image = global::QVLEGS.Properties.Resources.img;
            this.btnUltimaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimaFoto.Location = new System.Drawing.Point(282, 10);
            this.btnUltimaFoto.Name = "btnUltimaFoto";
            this.btnUltimaFoto.Size = new System.Drawing.Size(130, 60);
            this.btnUltimaFoto.TabIndex = 52;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 442);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(731, 201);
            this.tableLayoutPanel2.TabIndex = 51;
            // 
            // pbImgHelp
            // 
            this.pbImgHelp.BackgroundImage = global::QVLEGS.Properties.Resources.centraggioBlob;
            this.pbImgHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImgHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImgHelp.Location = new System.Drawing.Point(441, 3);
            this.pbImgHelp.Name = "pbImgHelp";
            this.pbImgHelp.Size = new System.Drawing.Size(287, 195);
            this.pbImgHelp.TabIndex = 41;
            this.pbImgHelp.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Image = global::QVLEGS.Properties.Resources.reloadPiccolo2;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(10, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(130, 60);
            this.btnTest.TabIndex = 50;
            this.btnTest.Text = "BTN_TEST";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Image = global::QVLEGS.Properties.Resources.imgScattaFoto;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(146, 11);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 49;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.Image = global::QVLEGS.Properties.Resources.imgImpara;
            this.btnTrain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrain.Location = new System.Drawing.Point(418, 10);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(130, 60);
            this.btnTrain.TabIndex = 4;
            this.btnTrain.Text = "BTN_TRAIN";
            this.btnTrain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrain.UseVisualStyleBackColor = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // UCStepTrainAllineamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStepTrainAllineamento";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(1100, 690);
            this.StepDescription = "LBL_STEP_TRAIN_ALLINEAMENTO";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDimensione)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.TrackBar trackBarDimensione;
        private System.Windows.Forms.Button btnDisegnaManoRem;
        private System.Windows.Forms.Button btnDisegnaManoAdd;
        private System.Windows.Forms.Button btnDisegnaRettangolo;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbImgHelp;
        private System.Windows.Forms.Button btnUltimaFoto;
    }
}
