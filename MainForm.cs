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

using System;
using System.Windows.Forms;

namespace AIPTags
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public string RootPath
		{
			get
			{
				return rootPathTextBox.Text;
			}
		}

		public string DestPath
		{
			get
			{
				return destTextBox.Text;
			}
		}

		public bool ShowUntagged
		{
			get
			{
				return showUntaggedCheckBox.Checked;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void enableDisableOKButton()
		{
			OKButton.Enabled = rootPathTextBox.Text.Length > 0 && destTextBox.Text.Length > 0;
		}

		private void rootPathTextBox_TextChanged(object sender, EventArgs e)
		{
			enableDisableOKButton();
		}

		private void destTextBox_TextChanged(object sender, EventArgs e)
		{
			enableDisableOKButton();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void rootPathButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					rootPathTextBox.Text = fbd.SelectedPath;
		}

		private void destButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Microsoft Excel files (*.xlsx)|*.xlsx";
			sfd.DefaultExt = "xlsx";
			sfd.AddExtension = true;
			sfd.CheckPathExists = true;
			sfd.FilterIndex = 0;

			if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
				destTextBox.Text = sfd.FileName;
		}
	}
}
