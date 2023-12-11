using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TSWizardDemo
{
	public class DemoWizard : TSWizards.BaseWizard
	{
		private System.ComponentModel.IContainer components = null;

		public DemoWizard()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Logo = new Bitmap(typeof(DemoWizard), "customLogo.jpg");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // wizardTop
            // 
            this.wizardTop.Size = new System.Drawing.Size(490, 64);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(12, 8);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(300, 8);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(396, 8);
            // 
            // panelStep
            // 
            this.panelStep.BackColor = System.Drawing.SystemColors.Control;
            this.panelStep.Location = new System.Drawing.Point(0, 64);
            this.panelStep.Size = new System.Drawing.Size(490, 293);
            // 
            // DemoWizard
            // 
            this.AllowClose = TSWizards.AllowClose.Ask;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(490, 357);
            this.FirstStepName = "Step1";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DemoWizard";
            this.Text = "Wait On Us ordering wizard";
            this.LoadSteps += new System.EventHandler(this.DemoWizard_LoadSteps);
            this.ResumeLayout(false);

		}
		#endregion

		private void DemoWizard_LoadSteps(object sender, System.EventArgs e)
		{
			AddStep("Step1", new Step1());
			AddStep("Step2", new Step2());
			AddStep("Step3", new Step3());
            AddStep("Step4", new Step4());
            AddStep("StepProva", new StepProva());

			AddStep("Step5", new Step5());
		}
	}
}

