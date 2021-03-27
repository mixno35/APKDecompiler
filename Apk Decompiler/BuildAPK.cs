/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 5:41
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of DecompileAPK.
	/// </summary>
	public partial class BuildAPK : Form
	{
		private string resultNoExt = HomeForm.pathHome;
		
		public BuildAPK()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!System.IO.File.Exists(HomeForm.pathHome + HomeForm.pathApktoolBat)) {
				MessageBox.Show("Отсутствует инициализационный .bat файл! Возможно вы забыли его скачать или скопировать в папку", "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			DisplayDecompiled(HomeForm.pathHome);
			try {
				this.comboBox1.SelectedIndex = 0;
			} catch (Exception e) {}
			this.button1.Click += new System.EventHandler(runBuild);
			this.button2.Click += new System.EventHandler(refreshDecompiledFiles);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void openExplorerPath(object sub, EventHandler e) {
			
		}
		
		private void refreshDecompiledFiles(object sender, EventArgs e) {
			DisplayDecompiled(HomeForm.pathHome);
		}
		
		public void DisplayDecompiled(string path) {
			this.comboBox1.Items.Clear();
			string[] files2 = System.IO.Directory.GetDirectories(path);
			for (int x = 0; x < files2.Length; x++) {
				if (System.IO.Directory.Exists(files2[x])) {
					if (System.IO.File.Exists(files2[x] + HomeForm.defauldDecompileFile)) {
						ListViewItem items = new ListViewItem(files2[x]);
						String item = files2[x].Replace(path + @"\", "");
						comboBox1.Items.Add(item + ".apk");
					}
				}
			}
		}
		
		private void runBuild(object sender, EventArgs e) {
			startBuild(this.comboBox1.SelectedItem.ToString().Replace(".apk", ""));
		}
		
		public void startBuild(String pathBuild) {
			if (!System.IO.File.Exists(HomeForm.pathHome + HomeForm.pathApktoolBat)) {
				MessageBox.Show("Не удалось найти исполнительный .bat файл!", "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				try {
					string selectItemAPK = pathBuild;
					string noExt = selectItemAPK.Replace(".apk", "");
					resultNoExt = HomeForm.pathHome + @"\" + noExt;
					string resultPathAPK = HomeForm.pathHome + @"\" + selectItemAPK;
					//MessageBox.Show(resultPathAPK);
					string cmdText = @"/k echo Maked by. ApkTool and SXBaby && cd " + HomeForm.pathHome + " && apktool b " + selectItemAPK;
					Process.Start("cmd.exe", cmdText);
				} catch (Exception ex) {
					MessageBox.Show("Что-то явно пошло не так!\n" + ex.ToString(), "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		private void openPathBuilded(object sender, EventArgs e) {
			Process.Start("explorer.exe", resultNoExt);
		}
	}
}
