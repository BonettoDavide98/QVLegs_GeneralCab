namespace QVLEGS.Pagine
{
    partial class UCPaginaQuery
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitolo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxOra = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCambiaCAM1 = new System.Windows.Forms.Button();
            this.btnCambiaCAM2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOraQuery = new System.Windows.Forms.Label();
            this.lblDataQuery = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.Color.White;
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(908, 64);
            this.lblTitolo.TabIndex = 43;
            this.lblTitolo.Text = "LBL_FRM_QUERY";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 487);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(629, 481);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(638, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 481);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.textBoxOra, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxData, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 149);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(261, 34);
            this.tableLayoutPanel5.TabIndex = 102;
            // 
            // textBoxOra
            // 
            this.textBoxOra.Location = new System.Drawing.Point(133, 3);
            this.textBoxOra.Name = "textBoxOra";
            this.textBoxOra.Size = new System.Drawing.Size(125, 22);
            this.textBoxOra.TabIndex = 99;
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(3, 3);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(124, 22);
            this.textBoxData.TabIndex = 98;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnCambiaCAM1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCambiaCAM2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(261, 100);
            this.tableLayoutPanel3.TabIndex = 96;
            // 
            // btnCambiaCAM1
            // 
            this.btnCambiaCAM1.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCambiaCAM1.FlatAppearance.BorderSize = 0;
            this.btnCambiaCAM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiaCAM1.Location = new System.Drawing.Point(4, 4);
            this.btnCambiaCAM1.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiaCAM1.Name = "btnCambiaCAM1";
            this.btnCambiaCAM1.Size = new System.Drawing.Size(102, 74);
            this.btnCambiaCAM1.TabIndex = 94;
            this.btnCambiaCAM1.Text = "BTN_CAMBIA_CAM_1";
            this.btnCambiaCAM1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiaCAM1.UseVisualStyleBackColor = false;
            this.btnCambiaCAM1.Click += new System.EventHandler(this.btnCambiaCAM1_Click);
            // 
            // btnCambiaCAM2
            // 
            this.btnCambiaCAM2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCambiaCAM2.FlatAppearance.BorderSize = 0;
            this.btnCambiaCAM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiaCAM2.Location = new System.Drawing.Point(134, 4);
            this.btnCambiaCAM2.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiaCAM2.Name = "btnCambiaCAM2";
            this.btnCambiaCAM2.Size = new System.Drawing.Size(102, 74);
            this.btnCambiaCAM2.TabIndex = 93;
            this.btnCambiaCAM2.Text = "BTN_CAMBIA_CAM_2";
            this.btnCambiaCAM2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiaCAM2.UseVisualStyleBackColor = false;
            this.btnCambiaCAM2.Click += new System.EventHandler(this.btnCambiaCAM2_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblOraQuery, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDataQuery, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 109);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(261, 34);
            this.tableLayoutPanel4.TabIndex = 101;
            // 
            // lblOraQuery
            // 
            this.lblOraQuery.AutoSize = true;
            this.lblOraQuery.ForeColor = System.Drawing.Color.White;
            this.lblOraQuery.Location = new System.Drawing.Point(133, 0);
            this.lblOraQuery.Name = "lblOraQuery";
            this.lblOraQuery.Size = new System.Drawing.Size(116, 34);
            this.lblOraQuery.TabIndex = 97;
            this.lblOraQuery.Text = "LBL_INTERVALLO_ORA";
            // 
            // lblDataQuery
            // 
            this.lblDataQuery.AutoSize = true;
            this.lblDataQuery.ForeColor = System.Drawing.Color.White;
            this.lblDataQuery.Location = new System.Drawing.Point(3, 0);
            this.lblDataQuery.Name = "lblDataQuery";
            this.lblDataQuery.Size = new System.Drawing.Size(116, 34);
            this.lblDataQuery.TabIndex = 96;
            this.lblDataQuery.Text = "LBL_INTERVALLO_DATA";
            // 
            // UCPaginaQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitolo);
            this.Name = "UCPaginaQuery";
            this.Size = new System.Drawing.Size(908, 551);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCambiaCAM2;
        private System.Windows.Forms.Button btnCambiaCAM1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblOraQuery;
        private System.Windows.Forms.Label lblDataQuery;
        private System.Windows.Forms.TextBox textBoxOra;
        private System.Windows.Forms.TextBox textBoxData;
    }
}
