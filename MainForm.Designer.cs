//NVD AIPTags
//Copyright © 2020, Nikolay Dudkin

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program.If not, see<https://www.gnu.org/licenses/>.

namespace AIPTags
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.rootPathGroupBox = new System.Windows.Forms.GroupBox();
			this.rootPathTextBox = new System.Windows.Forms.TextBox();
			this.rootPathButton = new System.Windows.Forms.Button();
			this.destGroupBox = new System.Windows.Forms.GroupBox();
			this.destTextBox = new System.Windows.Forms.TextBox();
			this.destButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.showUntaggedCheckBox = new System.Windows.Forms.CheckBox();
			this.rootPathGroupBox.SuspendLayout();
			this.destGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// rootPathGroupBox
			// 
			this.rootPathGroupBox.Controls.Add(this.rootPathTextBox);
			this.rootPathGroupBox.Controls.Add(this.rootPathButton);
			this.rootPathGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.rootPathGroupBox.Location = new System.Drawing.Point(0, 0);
			this.rootPathGroupBox.Name = "rootPathGroupBox";
			this.rootPathGroupBox.Size = new System.Drawing.Size(693, 52);
			this.rootPathGroupBox.TabIndex = 0;
			this.rootPathGroupBox.TabStop = false;
			this.rootPathGroupBox.Text = "Root path:";
			// 
			// rootPathTextBox
			// 
			this.rootPathTextBox.Location = new System.Drawing.Point(12, 19);
			this.rootPathTextBox.Name = "rootPathTextBox";
			this.rootPathTextBox.ReadOnly = true;
			this.rootPathTextBox.Size = new System.Drawing.Size(594, 20);
			this.rootPathTextBox.TabIndex = 1;
			this.rootPathTextBox.TextChanged += new System.EventHandler(this.rootPathTextBox_TextChanged);
			// 
			// rootPathButton
			// 
			this.rootPathButton.Location = new System.Drawing.Point(612, 17);
			this.rootPathButton.Name = "rootPathButton";
			this.rootPathButton.Size = new System.Drawing.Size(75, 23);
			this.rootPathButton.TabIndex = 1;
			this.rootPathButton.Text = "...";
			this.rootPathButton.UseVisualStyleBackColor = true;
			this.rootPathButton.Click += new System.EventHandler(this.rootPathButton_Click);
			// 
			// destGroupBox
			// 
			this.destGroupBox.Controls.Add(this.destTextBox);
			this.destGroupBox.Controls.Add(this.destButton);
			this.destGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.destGroupBox.Location = new System.Drawing.Point(0, 52);
			this.destGroupBox.Name = "destGroupBox";
			this.destGroupBox.Size = new System.Drawing.Size(693, 52);
			this.destGroupBox.TabIndex = 1;
			this.destGroupBox.TabStop = false;
			this.destGroupBox.Text = "Destination file:";
			// 
			// destTextBox
			// 
			this.destTextBox.Location = new System.Drawing.Point(12, 19);
			this.destTextBox.Name = "destTextBox";
			this.destTextBox.ReadOnly = true;
			this.destTextBox.Size = new System.Drawing.Size(594, 20);
			this.destTextBox.TabIndex = 1;
			this.destTextBox.TextChanged += new System.EventHandler(this.destTextBox_TextChanged);
			// 
			// destButton
			// 
			this.destButton.Location = new System.Drawing.Point(612, 17);
			this.destButton.Name = "destButton";
			this.destButton.Size = new System.Drawing.Size(75, 23);
			this.destButton.TabIndex = 1;
			this.destButton.Text = "...";
			this.destButton.UseVisualStyleBackColor = true;
			this.destButton.Click += new System.EventHandler(this.destButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.Enabled = false;
			this.OKButton.Location = new System.Drawing.Point(12, 108);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "&OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(93, 108);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// showUntaggedCheckBox
			// 
			this.showUntaggedCheckBox.AutoSize = true;
			this.showUntaggedCheckBox.Location = new System.Drawing.Point(586, 113);
			this.showUntaggedCheckBox.Name = "showUntaggedCheckBox";
			this.showUntaggedCheckBox.Size = new System.Drawing.Size(101, 17);
			this.showUntaggedCheckBox.TabIndex = 4;
			this.showUntaggedCheckBox.Text = "Show untagged";
			this.showUntaggedCheckBox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(693, 142);
			this.Controls.Add(this.showUntaggedCheckBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.destGroupBox);
			this.Controls.Add(this.rootPathGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "AIPTags";
			this.rootPathGroupBox.ResumeLayout(false);
			this.rootPathGroupBox.PerformLayout();
			this.destGroupBox.ResumeLayout(false);
			this.destGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox rootPathGroupBox;
		private System.Windows.Forms.TextBox rootPathTextBox;
		private System.Windows.Forms.Button rootPathButton;
		private System.Windows.Forms.GroupBox destGroupBox;
		private System.Windows.Forms.TextBox destTextBox;
		private System.Windows.Forms.Button destButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.CheckBox showUntaggedCheckBox;
	}
}