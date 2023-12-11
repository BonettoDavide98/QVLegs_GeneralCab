namespace QVLEGS.Utilities
{
    partial class UCHWndCtrlManager
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnOpenMenu = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCommenta = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.btnZoomMeno = new System.Windows.Forms.Button();
            this.chbAnnotazioni = new System.Windows.Forms.CheckBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnZoomPiu = new System.Windows.Forms.Button();
            this.chbMuovi = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.btnOpenMenu);
            this.panel.Controls.Add(this.panelMenu);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(441, 396);
            this.panel.TabIndex = 1;
            // 
            // btnOpenMenu
            // 
            this.btnOpenMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMenu.BackColor = System.Drawing.Color.Black;
            this.btnOpenMenu.BackgroundImage = global::QVLEGS.Properties.Resources.menuSmall_colored;
            this.btnOpenMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenMenu.FlatAppearance.BorderSize = 0;
            this.btnOpenMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMenu.Location = new System.Drawing.Point(401, 0);
            this.btnOpenMenu.Name = "btnOpenMenu";
            this.btnOpenMenu.Size = new System.Drawing.Size(40, 40);
            this.btnOpenMenu.TabIndex = 0;
            this.btnOpenMenu.UseVisualStyleBackColor = false;
            this.btnOpenMenu.Click += new System.EventHandler(this.btnOpenMenu_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.Controls.Add(this.btnCommenta);
            this.panelMenu.Controls.Add(this.btnSalva);
            this.panelMenu.Controls.Add(this.btnResetZoom);
            this.panelMenu.Controls.Add(this.btnZoomMeno);
            this.panelMenu.Controls.Add(this.chbAnnotazioni);
            this.panelMenu.Controls.Add(this.btnChiudi);
            this.panelMenu.Controls.Add(this.btnZoomPiu);
            this.panelMenu.Controls.Add(this.chbMuovi);
            this.panelMenu.Location = new System.Drawing.Point(198, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(242, 87);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Visible = false;
            this.panelMenu.MouseLeave += new System.EventHandler(this.panelMenu_MouseLeave);
            // 
            // btnCommenta
            // 
            this.btnCommenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommenta.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCommenta.BackgroundImage = global::QVLEGS.Properties.Resources.img_diagnostica;
            this.btnCommenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCommenta.FlatAppearance.BorderSize = 0;
            this.btnCommenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommenta.Location = new System.Drawing.Point(6, 40);
            this.btnCommenta.Name = "btnCommenta";
            this.btnCommenta.Size = new System.Drawing.Size(40, 40);
            this.btnCommenta.TabIndex = 61;
            this.btnCommenta.UseVisualStyleBackColor = false;
            this.btnCommenta.Visible = false;
            this.btnCommenta.Click += new System.EventHandler(this.btnCommenta_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSalva.BackgroundImage = global::QVLEGS.Properties.Resources.btnSave_Image;
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Location = new System.Drawing.Point(6, 3);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(40, 40);
            this.btnSalva.TabIndex = 60;
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetZoom.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResetZoom.BackgroundImage = global::QVLEGS.Properties.Resources.zoom_fit_Size1;
            this.btnResetZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetZoom.FlatAppearance.BorderSize = 0;
            this.btnResetZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetZoom.Location = new System.Drawing.Point(150, 3);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(40, 40);
            this.btnResetZoom.TabIndex = 55;
            this.btnResetZoom.UseVisualStyleBackColor = false;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // btnZoomMeno
            // 
            this.btnZoomMeno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomMeno.BackColor = System.Drawing.Color.Gainsboro;
            this.btnZoomMeno.BackgroundImage = global::QVLEGS.Properties.Resources.zoom_out_1;
            this.btnZoomMeno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomMeno.FlatAppearance.BorderSize = 0;
            this.btnZoomMeno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomMeno.Location = new System.Drawing.Point(101, 3);
            this.btnZoomMeno.Name = "btnZoomMeno";
            this.btnZoomMeno.Size = new System.Drawing.Size(40, 40);
            this.btnZoomMeno.TabIndex = 54;
            this.btnZoomMeno.UseVisualStyleBackColor = false;
            this.btnZoomMeno.Click += new System.EventHandler(this.btnZoomMeno_Click);
            // 
            // chbAnnotazioni
            // 
            this.chbAnnotazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAnnotazioni.AutoSize = true;
            this.chbAnnotazioni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chbAnnotazioni.Checked = true;
            this.chbAnnotazioni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAnnotazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAnnotazioni.Location = new System.Drawing.Point(50, 48);
            this.chbAnnotazioni.Name = "chbAnnotazioni";
            this.chbAnnotazioni.Size = new System.Drawing.Size(120, 24);
            this.chbAnnotazioni.TabIndex = 57;
            this.chbAnnotazioni.Text = "  Annotazioni";
            this.chbAnnotazioni.UseVisualStyleBackColor = true;
            this.chbAnnotazioni.CheckedChanged += new System.EventHandler(this.chbAnnotazioni_CheckedChanged);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackgroundImage = global::QVLEGS.Properties.Resources.chiudi;
            this.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Location = new System.Drawing.Point(199, 3);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(40, 40);
            this.btnChiudi.TabIndex = 59;
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnZoomPiu
            // 
            this.btnZoomPiu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomPiu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnZoomPiu.BackgroundImage = global::QVLEGS.Properties.Resources.zoom_in_1;
            this.btnZoomPiu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomPiu.FlatAppearance.BorderSize = 0;
            this.btnZoomPiu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomPiu.Location = new System.Drawing.Point(52, 3);
            this.btnZoomPiu.Name = "btnZoomPiu";
            this.btnZoomPiu.Size = new System.Drawing.Size(40, 40);
            this.btnZoomPiu.TabIndex = 53;
            this.btnZoomPiu.UseVisualStyleBackColor = false;
            this.btnZoomPiu.Click += new System.EventHandler(this.btnZoomPiu_Click);
            // 
            // chbMuovi
            // 
            this.chbMuovi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbMuovi.AutoSize = true;
            this.chbMuovi.BackgroundImage = global::QVLEGS.Properties.Resources.move2;
            this.chbMuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chbMuovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMuovi.Location = new System.Drawing.Point(170, 46);
            this.chbMuovi.Name = "chbMuovi";
            this.chbMuovi.Size = new System.Drawing.Size(80, 33);
            this.chbMuovi.TabIndex = 56;
            this.chbMuovi.Text = "        ";
            this.chbMuovi.UseVisualStyleBackColor = true;
            this.chbMuovi.CheckedChanged += new System.EventHandler(this.chbMuovi_CheckedChanged);
            // 
            // UCHWndCtrlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "UCHWndCtrlManager";
            this.Size = new System.Drawing.Size(441, 396);
            this.panel.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnOpenMenu;
        private System.Windows.Forms.Button btnZoomMeno;
        private System.Windows.Forms.Button btnResetZoom;
        private System.Windows.Forms.Button btnZoomPiu;
        private System.Windows.Forms.CheckBox chbMuovi;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.CheckBox chbAnnotazioni;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCommenta;
    }
}
