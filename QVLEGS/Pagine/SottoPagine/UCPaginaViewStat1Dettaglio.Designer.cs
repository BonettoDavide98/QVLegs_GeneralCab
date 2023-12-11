namespace QVLEGS.Pagine.SottoPagine
{
    partial class UCPaginaViewStat1Dettaglio
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTurnoPrecedente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUltimaOra = new System.Windows.Forms.Label();
            this.lblTurnoAttuale = new System.Windows.Forms.Label();
            this.lblTurnoPrecedente = new System.Windows.Forms.Label();
            this.chartTurnoAttuale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUltimaOra = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoAttuale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltimaOra)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTurnoPrecedente
            // 
            this.chartTurnoPrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTurnoPrecedente.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea1.Name = "ChartArea1";
            this.chartTurnoPrecedente.ChartAreas.Add(chartArea1);
            this.chartTurnoPrecedente.Location = new System.Drawing.Point(3, 23);
            this.chartTurnoPrecedente.Name = "chartTurnoPrecedente";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BackSecondaryColor = System.Drawing.Color.Red;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Blue;
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            this.chartTurnoPrecedente.Series.Add(series1);
            this.chartTurnoPrecedente.Size = new System.Drawing.Size(282, 447);
            this.chartTurnoPrecedente.TabIndex = 44;
            this.chartTurnoPrecedente.Text = "chart1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblUltimaOra, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTurnoAttuale, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTurnoPrecedente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTurnoAttuale, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartUltimaOra, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartTurnoPrecedente, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 473);
            this.tableLayoutPanel1.TabIndex = 47;
            // 
            // lblUltimaOra
            // 
            this.lblUltimaOra.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUltimaOra.AutoSize = true;
            this.lblUltimaOra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaOra.ForeColor = System.Drawing.Color.White;
            this.lblUltimaOra.Location = new System.Drawing.Point(645, 0);
            this.lblUltimaOra.Name = "lblUltimaOra";
            this.lblUltimaOra.Size = new System.Drawing.Size(150, 20);
            this.lblUltimaOra.TabIndex = 51;
            this.lblUltimaOra.Text = "LBL_ULTIMA_ORA";
            // 
            // lblTurnoAttuale
            // 
            this.lblTurnoAttuale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTurnoAttuale.AutoSize = true;
            this.lblTurnoAttuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoAttuale.ForeColor = System.Drawing.Color.White;
            this.lblTurnoAttuale.Location = new System.Drawing.Point(340, 0);
            this.lblTurnoAttuale.Name = "lblTurnoAttuale";
            this.lblTurnoAttuale.Size = new System.Drawing.Size(184, 20);
            this.lblTurnoAttuale.TabIndex = 50;
            this.lblTurnoAttuale.Text = "LBL_TURNO_ATTUALE";
            // 
            // lblTurnoPrecedente
            // 
            this.lblTurnoPrecedente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTurnoPrecedente.AutoSize = true;
            this.lblTurnoPrecedente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoPrecedente.ForeColor = System.Drawing.Color.White;
            this.lblTurnoPrecedente.Location = new System.Drawing.Point(33, 0);
            this.lblTurnoPrecedente.Name = "lblTurnoPrecedente";
            this.lblTurnoPrecedente.Size = new System.Drawing.Size(221, 20);
            this.lblTurnoPrecedente.TabIndex = 48;
            this.lblTurnoPrecedente.Text = "LBL_TURNO_PRECEDENTE";
            // 
            // chartTurnoAttuale
            // 
            this.chartTurnoAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTurnoAttuale.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea2.Name = "ChartArea1";
            this.chartTurnoAttuale.ChartAreas.Add(chartArea2);
            this.chartTurnoAttuale.Location = new System.Drawing.Point(291, 23);
            this.chartTurnoAttuale.Name = "chartTurnoAttuale";
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series2.BackSecondaryColor = System.Drawing.Color.Red;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Blue;
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Name = "Series1";
            this.chartTurnoAttuale.Series.Add(series2);
            this.chartTurnoAttuale.Size = new System.Drawing.Size(282, 447);
            this.chartTurnoAttuale.TabIndex = 48;
            this.chartTurnoAttuale.Text = "chart1";
            // 
            // chartUltimaOra
            // 
            this.chartUltimaOra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartUltimaOra.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            chartArea3.Name = "ChartArea1";
            this.chartUltimaOra.ChartAreas.Add(chartArea3);
            this.chartUltimaOra.Location = new System.Drawing.Point(579, 23);
            this.chartUltimaOra.Name = "chartUltimaOra";
            series3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series3.BackSecondaryColor = System.Drawing.Color.Red;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Blue;
            series3.IsValueShownAsLabel = true;
            series3.LabelBackColor = System.Drawing.Color.Transparent;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Name = "Series1";
            this.chartUltimaOra.Series.Add(series3);
            this.chartUltimaOra.Size = new System.Drawing.Size(283, 447);
            this.chartUltimaOra.TabIndex = 49;
            this.chartUltimaOra.Text = "chart1";
            // 
            // UCPaginaViewStat1Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UCPaginaViewStat1Dettaglio";
            this.Size = new System.Drawing.Size(865, 473);
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoAttuale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltimaOra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnoPrecedente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnoAttuale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUltimaOra;
        private System.Windows.Forms.Label lblUltimaOra;
        private System.Windows.Forms.Label lblTurnoAttuale;
        private System.Windows.Forms.Label lblTurnoPrecedente;
    }
}
