namespace MegaKeep
{
	partial class MegaKeep
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaKeep));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLocate = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLog = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(97, 86);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(187, 48);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(255, 20);
			this.txtPath.TabIndex = 1;
			this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(127, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Accounts";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnLocate
			// 
			this.btnLocate.Location = new System.Drawing.Point(448, 46);
			this.btnLocate.Name = "btnLocate";
			this.btnLocate.Size = new System.Drawing.Size(40, 23);
			this.btnLocate.TabIndex = 3;
			this.btnLocate.Text = "...";
			this.btnLocate.UseVisualStyleBackColor = true;
			this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(130, 75);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(358, 23);
			this.btnRun.TabIndex = 4;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(127, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(362, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Create a user:pass text file, one line per account and add it below";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(12, 114);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(476, 147);
			this.txtLog.TabIndex = 6;
			// 
			// MegaKeep
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 277);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnLocate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MegaKeep";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MegaKeep";
			this.Load += new System.EventHandler(this.MegaKeep_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLocate;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLog;
	}
}

