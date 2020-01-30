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

using Microsoft.InformationProtection;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AIPTags
{
	class Program
	{
		static string msipPath = "";
		static bool showuntagged = false;
		static List<(string path, string tag, string author, DateTime date)> tagList = null;
		static int tagged;
		static int all;

		[STAThread]
		static void Main(string[] args)
		{
			Console.Out.WriteLine(string.Format("{0} {1}\r\n{2}", ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute))).Title, Assembly.GetExecutingAssembly().GetName().Version, ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute))).Copyright));

			msipPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
			if (!File.Exists(Path.Combine(msipPath, "MSIP.API.dll")))
			{
				msipPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Microsoft Azure Information Protection");
				if (!File.Exists(Path.Combine(msipPath, "MSIP.API.dll")))
				{
					msipPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Microsoft Azure Information Protection");
					if (!File.Exists(Path.Combine(msipPath, "MSIP.API.dll")))
					{
						Console.Out.WriteLine("\r\nError: Microsoft Azure Information Protection not found!");
						return;
					}
				}
			}

			AppDomain.CurrentDomain.AssemblyResolve += LoadAssembly;

			Core(args);
		}

		static void Core(string[] args)
		{
			string rootPath;
			string outFileName;

			if (args.Length == 0)
			{
				MainForm mainForm = new MainForm();
				if (mainForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					rootPath = mainForm.RootPath;
					outFileName = mainForm.DestPath;
					showuntagged = mainForm.ShowUntagged;
				}
				else
					return;
			}
			else
			{
				if (args.Length < 2 || !Directory.Exists(args[0]))
				{
					Console.Out.WriteLine("\r\nUsage: AIPTags.exe root_path output_file.xlsx [ShowUntagged]");
					return;
				}
				else
				{
					rootPath = args[0];
					outFileName = args[1];
					showuntagged = (args.Length == 3) && args[2].Equals("showuntagged", StringComparison.InvariantCultureIgnoreCase);
				}
			}

			tagged = all = 0;

			tagList = new List<(string, string, string, DateTime)>();

			AIPSession session = new AIPSession();

			Console.Out.WriteLine();

			ToHere();
			To("Evaluating ");
			ToHere();

			getDirectoryFileTags(session, rootPath);

			To("(" + tagged +"/" + all + "): done.");

			Console.Out.WriteLine();

			if (tagList.Count > 1000000)
			{
				To("Error: too many files/tags!");
				return;
			}

			ToHere();
			To("Exporting: ");
			ToHere();
			To("0%");

			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("AIPTags");

			ws.Cells[1, 1].Value = "Path";
			ws.Cells[1, 2].Value = "Tag";
			ws.Cells[1, 3].Value = "Author";
			ws.Cells[1, 4].Value = "Date";

			for (int i = 1; i < 5; i++)
			{
				ws.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
				ws.Cells[1, i].Style.Font.Bold = true;
				ws.Cells[1, i].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
				ws.Cells[1, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);
			}

			for (int i = 0; i < tagList.Count; i++)
			{
				ws.Cells[i + 2, 1].Value = tagList[i].path;
				ws.Cells[i + 2, 2].Value = tagList[i].tag ?? "";
				ws.Cells[i + 2, 3].Value = tagList[i].author ?? "";
				if (tagList[i].date.Year > 1950)
					ws.Cells[i + 2, 4].Value = tagList[i].date.ToLocalTime();

				ws.Cells[i + 2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
				ws.Cells[i + 2, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
				ws.Cells[i + 2, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
				ws.Cells[i + 2, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
				ws.Cells[i + 2, 4].Style.Numberformat.Format = "yyyy-MM-dd HH:mm";

				To(string.Format("{0}%", (int)(((double)i) / ((double)tagList.Count) * 100.0)));
			}

			ws.Column(1).Width = 100;
			ws.Column(2).Width = 30;
			ws.Column(3).Width = 30;
			ws.Column(4).Width = 25;

			ws.View.FreezePanes(2, 1);

			ws.Cells[1, 1, 1, 4].AutoFilter = true;

			using (FileStream fs = new FileStream(outFileName, FileMode.Create, FileAccess.ReadWrite))
			{
				excelPackage.SaveAs(fs);
			}

			To("done.");

			Console.Out.WriteLine();
		}

		static void getDirectoryFileTags(AIPSession session, string root)
		{
			To("(" + tagged + "/" + all + "): " + root);

			string[] tmp = null;

			try
			{
				tmp = Directory.GetFiles(root, "*.*");
			}
			catch { }

			if (tmp != null)
			{
				foreach (string fileName in tmp)
				{
					bool added = false;

					try
					{
						FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						AIPFile af = session.Open(fs, fileName);

						AIPTag[] tags = af.GetTags();

						foreach (AIPTag tag in tags)
						{
							DateTime date = DateTime.MinValue;
							DateTime.TryParse(tag.SetDate, out date);

							tagList.Add((fileName, tag.Name, tag.Owner, date));
							added = true;
							tagged++;
						}

						af.Dispose();
						fs.Close();
					}
					catch
					{ }

					if (!added && showuntagged)
					{
						tagList.Add((fileName, "", "", DateTime.MinValue));
					}

					all++;
				}
			}

			tmp = null;

			try
			{
				tmp = Directory.GetDirectories(root);
			}
			catch { }

			if (tmp != null)
			{
				foreach (string path in tmp)
				{
					getDirectoryFileTags(session, path);
				}
			}
		}

		private static int console_len = 0;
		private static int console_row = 0;
		private static int console_col = 0;

		private static void ToHere()
		{
			console_len = 0;
			console_row = Console.CursorTop;
			console_col = Console.CursorLeft;
		}

		private static void To(string str)
		{
			Console.SetCursorPosition(console_col, console_row);
			Console.Out.Write(str);
			Console.Write(new String(' ', Math.Max(0, console_len - str.Length)));
			console_len = str.Length;
		}

		private static Assembly LoadAssembly(object sender, ResolveEventArgs args)
		{
			if (args != null && !string.IsNullOrEmpty(args.Name))
			{
				var assemblyName = args.Name.Split(new string[] { "," }, StringSplitOptions.None)[0];
				var assemblyPath = Path.Combine(msipPath, string.Format("{0}.{1}", assemblyName, "dll"));

				if (File.Exists(assemblyPath))
					return Assembly.LoadFrom(assemblyPath);
			}

			return null;
		}
	}
}
