namespace QVLEGS
{
    partial class FormMasterGMM
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
            this.btnImpostazioni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImpostazioni
            // 
            this.btnImpostazioni.Image = global::QVLEGS.Properties.Resources.img_impostazioni;
            this.btnImpostazioni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpostazioni.Location = new System.Drawing.Point(206, 12);
            this.btnImpostazioni.Name = "btnImpostazioni";
            this.btnImpostazioni.Size = new System.Drawing.Size(192, 60);
            this.btnImpostazioni.TabIndex = 5;
            this.btnImpostazioni.Text = "BTN_IMPOSTAZIONI";
            this.btnImpostazioni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImpostazioni.UseVisualStyleBackColor = true;
            this.btnImpostazioni.Click += new System.EventHandler(this.btnImpostazioni_Click);
            // 
            // FormMasterGMM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 411);
            this.Controls.Add(this.btnImpostazioni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(620, 450);
            this.MinimumSize = new System.Drawing.Size(620, 450);
            this.Name = "FormMasterGMM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master GMM";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImpostazioni;
    }
}