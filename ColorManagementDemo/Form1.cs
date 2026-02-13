using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Atalasoft.Imaging.ColorManagement;
using Atalasoft.Imaging.WinControls;
using Atalasoft.Imaging.Codec;
using WinDemoHelperMethods;

namespace ColorManagementDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private ColorProfile inputProfile = null;
		private Atalasoft.Imaging.WinControls.WorkspaceViewer viewer;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnInputProfile;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private System.Windows.Forms.Button btnMonitorProfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnTargetProfile;
		private System.Windows.Forms.TextBox txtInputProfile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMonitorProfile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTargetProfile;
		private System.Windows.Forms.CheckBox chkColorManage;
		private System.Windows.Forms.ComboBox cmbRenderIntent;
		private System.Windows.Forms.ComboBox cmbProofIntent;
		private System.Windows.Forms.Button AboutBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			// Ensure decoders are setup
			HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.viewer = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnInputProfile = new System.Windows.Forms.Button();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.btnMonitorProfile = new System.Windows.Forms.Button();
			this.cmbRenderIntent = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTargetProfile = new System.Windows.Forms.Button();
			this.txtInputProfile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMonitorProfile = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTargetProfile = new System.Windows.Forms.TextBox();
			this.chkColorManage = new System.Windows.Forms.CheckBox();
			this.cmbProofIntent = new System.Windows.Forms.ComboBox();
			this.AboutBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// viewer
			// 
			this.viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.viewer.ColorManage = true;
			this.viewer.DisplayProfile = null;
			this.viewer.Location = new System.Drawing.Point(0, 160);
			this.viewer.Magnifier.BackColor = System.Drawing.Color.White;
			this.viewer.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.viewer.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.viewer.Name = "viewer";
			this.viewer.OutputProfile = null;
			this.viewer.Selection = null;
			this.viewer.Size = new System.Drawing.Size(524, 280);
			this.viewer.TabIndex = 0;
			this.viewer.Text = "workspaceViewer1";
			this.viewer.ImageChanged += new Atalasoft.Imaging.ImageEventHandler(this.viewer_NewImage);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(8, 16);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Load Image";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnInputProfile
			// 
			this.btnInputProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInputProfile.Location = new System.Drawing.Point(360, 64);
			this.btnInputProfile.Name = "btnInputProfile";
			this.btnInputProfile.Size = new System.Drawing.Size(24, 23);
			this.btnInputProfile.TabIndex = 2;
			this.btnInputProfile.Text = "...";
			this.btnInputProfile.Click += new System.EventHandler(this.btnInputProfile_Click);
			// 
			// btnMonitorProfile
			// 
			this.btnMonitorProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMonitorProfile.Location = new System.Drawing.Point(360, 96);
			this.btnMonitorProfile.Name = "btnMonitorProfile";
			this.btnMonitorProfile.Size = new System.Drawing.Size(24, 23);
			this.btnMonitorProfile.TabIndex = 3;
			this.btnMonitorProfile.Text = "...";
			this.btnMonitorProfile.Click += new System.EventHandler(this.btnMonitorProfile_Click);
			// 
			// cmbRenderIntent
			// 
			this.cmbRenderIntent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbRenderIntent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRenderIntent.Items.AddRange(new object[] {
																 "Pictures",
																 "Proof",
																 "Graphics",
																 "Match"});
			this.cmbRenderIntent.Location = new System.Drawing.Point(400, 80);
			this.cmbRenderIntent.Name = "cmbRenderIntent";
			this.cmbRenderIntent.Size = new System.Drawing.Size(121, 21);
			this.cmbRenderIntent.TabIndex = 4;
			this.cmbRenderIntent.SelectedIndexChanged += new System.EventHandler(this.cmbRenderIntent_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(408, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Rendering Intent:";
			// 
			// btnTargetProfile
			// 
			this.btnTargetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTargetProfile.Location = new System.Drawing.Point(360, 128);
			this.btnTargetProfile.Name = "btnTargetProfile";
			this.btnTargetProfile.Size = new System.Drawing.Size(24, 23);
			this.btnTargetProfile.TabIndex = 6;
			this.btnTargetProfile.Text = "...";
			this.btnTargetProfile.Click += new System.EventHandler(this.btnTargetProfile_Click);
			// 
			// txtInputProfile
			// 
			this.txtInputProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputProfile.Location = new System.Drawing.Point(96, 64);
			this.txtInputProfile.Name = "txtInputProfile";
			this.txtInputProfile.Size = new System.Drawing.Size(256, 20);
			this.txtInputProfile.TabIndex = 7;
			this.txtInputProfile.Text = "";
			this.txtInputProfile.TextChanged += new System.EventHandler(this.txtInputProfile_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Input Profile:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Monitor Profile:";
			// 
			// txtMonitorProfile
			// 
			this.txtMonitorProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMonitorProfile.Location = new System.Drawing.Point(96, 96);
			this.txtMonitorProfile.Name = "txtMonitorProfile";
			this.txtMonitorProfile.Size = new System.Drawing.Size(256, 20);
			this.txtMonitorProfile.TabIndex = 9;
			this.txtMonitorProfile.Text = "";
			this.txtMonitorProfile.TextChanged += new System.EventHandler(this.txtMonitorProfile_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Target Profile:";
			// 
			// txtTargetProfile
			// 
			this.txtTargetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTargetProfile.Location = new System.Drawing.Point(96, 128);
			this.txtTargetProfile.Name = "txtTargetProfile";
			this.txtTargetProfile.Size = new System.Drawing.Size(256, 20);
			this.txtTargetProfile.TabIndex = 11;
			this.txtTargetProfile.Text = "";
			this.txtTargetProfile.TextChanged += new System.EventHandler(this.txtTargetProfile_TextChanged);
			// 
			// chkColorManage
			// 
			this.chkColorManage.Location = new System.Drawing.Point(96, 16);
			this.chkColorManage.Name = "chkColorManage";
			this.chkColorManage.Size = new System.Drawing.Size(160, 24);
			this.chkColorManage.TabIndex = 13;
			this.chkColorManage.Text = "Enable Color Management";
			this.chkColorManage.CheckedChanged += new System.EventHandler(this.chkColorManage_CheckedChanged);
			// 
			// cmbProofIntent
			// 
			this.cmbProofIntent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbProofIntent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProofIntent.Items.AddRange(new object[] {
																"Pictures",
																"Proof",
																"Graphics",
																"Match"});
			this.cmbProofIntent.Location = new System.Drawing.Point(400, 128);
			this.cmbProofIntent.Name = "cmbProofIntent";
			this.cmbProofIntent.Size = new System.Drawing.Size(121, 21);
			this.cmbProofIntent.TabIndex = 15;
			this.cmbProofIntent.SelectedIndexChanged += new System.EventHandler(this.cmbProofIntent_SelectedIndexChanged);
			// 
			// AboutBtn
			// 
			this.AboutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AboutBtn.Location = new System.Drawing.Point(408, 16);
			this.AboutBtn.Name = "AboutBtn";
			this.AboutBtn.Size = new System.Drawing.Size(88, 24);
			this.AboutBtn.TabIndex = 16;
			this.AboutBtn.Text = "About ...";
			this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 446);
			this.Controls.Add(this.AboutBtn);
			this.Controls.Add(this.cmbProofIntent);
			this.Controls.Add(this.chkColorManage);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTargetProfile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMonitorProfile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtInputProfile);
			this.Controls.Add(this.btnTargetProfile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbRenderIntent);
			this.Controls.Add(this.btnMonitorProfile);
			this.Controls.Add(this.btnInputProfile);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.viewer);
			this.Name = "Form1";
			this.Text = "Color Management Demo";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			try
			{
				// try to locate images folder
				string imagesFolder = Application.ExecutablePath;
				// we assume we are running under the DotImage install folder
				int pos = imagesFolder.IndexOf("DotImage ");
				if (pos != -1)
				{
					imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images";
				}

				//use this folder as starting point			
				this.openFileDialog1.InitialDirectory = imagesFolder;

				// Filter to image types that are licensed
				this.openFileDialog1.Filter = HelperMethods.CreateDialogFilter(true);

				if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
				{
					viewer.Open(this.openFileDialog1.FileName);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void viewer_NewImage(object sender, Atalasoft.Imaging.ImageEventArgs e)
		{
			if (e.Image.ColorProfile == null)
				e.Image.ColorProfile = this.inputProfile;
		}

		private void btnInputProfile_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog2.InitialDirectory = ColorProfile.GetProfileDirectory();
			if (this.openFileDialog2.ShowDialog(this) == DialogResult.OK)
			{
				txtInputProfile.Text = this.openFileDialog2.FileName;
			}

		}

		private void SetInputProfile()
		{
			try
			{
				if (txtInputProfile.Text.Length > 0)
					this.inputProfile = new ColorProfile(txtInputProfile.Text);
				else
					this.inputProfile = null;
				
				if (this.viewer.Image != null)
					this.viewer.Image.ColorProfile = this.inputProfile;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void btnMonitorProfile_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog2.InitialDirectory = ColorProfile.GetProfileDirectory();
			if (this.openFileDialog2.ShowDialog(this) == DialogResult.OK)
			{
				txtMonitorProfile.Text = this.openFileDialog2.FileName;
			}
		}

		private void SetMonitorProfile()
		{
			try
			{
				if (txtMonitorProfile.Text.Length > 0)
					viewer.DisplayProfile = new ColorProfile(txtMonitorProfile.Text);
				else
					viewer.DisplayProfile = null;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void cmbRenderIntent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				viewer.RenderingIntent = (RenderingIntent)cmbRenderIntent.SelectedIndex;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void btnTargetProfile_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog2.InitialDirectory = ColorProfile.GetProfileDirectory();
			if (this.openFileDialog2.ShowDialog(this) == DialogResult.OK)
			{
				txtTargetProfile.Text = this.openFileDialog2.FileName;
			}
		}

		private void SetTargetProfile()
		{
			try
			{
				if (txtTargetProfile.Text.Length > 0)
					viewer.OutputProfile = new ColorProfile(txtTargetProfile.Text);
				else
					viewer.OutputProfile = null;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void txtTargetProfile_TextChanged(object sender, System.EventArgs e)
		{
			SetTargetProfile();
		}

		private void txtMonitorProfile_TextChanged(object sender, System.EventArgs e)
		{
			SetMonitorProfile();
		}

		private void txtInputProfile_TextChanged(object sender, System.EventArgs e)
		{
			SetInputProfile();
		}

		private void chkColorManage_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				viewer.ColorManage = chkColorManage.Checked;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			chkColorManage.Checked = viewer.ColorManage;
			this.cmbRenderIntent.SelectedIndex = 0;
			this.cmbProofIntent.SelectedIndex = 3;
		}

		private void cmbProofIntent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				viewer.ProofIntent = (RenderingIntent)cmbProofIntent.SelectedIndex;
				viewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
		}

		private void AboutBtn_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft DotImage Color Management Demo",
				"DotImage Color Management Demo");
			aboutBox.Description = @"The Color Management Demo demonstrates how DotImage can use color profiles to display images correctly, and create virtual proofs of images.";
			aboutBox.ShowDialog();
		}
	}
}
