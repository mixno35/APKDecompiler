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
	public partial class DecompileAPK : Form
	{
		private string resultNoExt = HomeForm.pathHome;
		
		public DecompileAPK()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!System.IO.File.Exists(HomeForm.pathHome + HomeForm.pathApktoolBat)) {
				MessageBox.Show("Отсутствует инициализационный .bat файл! Возможно вы забыли его скачать или скопировать в папку", "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			DisplayApk(HomeForm.pathHome);
			this.label1.Text = HomeForm.pathHome;
			try {
				this.comboBox1.SelectedIndex = 0;
			} catch (Exception e) {}
			this.button3.Visible = false;
			this.button1.Click += new System.EventHandler(runDecompiling);
			this.button2.Click += new System.EventHandler(refreshApkFiles);
			this.button3.Click += new System.EventHandler(openPathDecompiled);
			this.button4.Click += new System.EventHandler(importApk);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void openExplorerPath(object sub, EventHandler e) {
			
		}
		
		private void importApk(object sub, EventArgs e) {
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

		    openFileDialog1.Filter = "Database files (*.apk)|*.apk" ;
		    openFileDialog1.FilterIndex = 0;
		    openFileDialog1.RestoreDirectory = true ;
		
		    if(openFileDialog1.ShowDialog() == DialogResult.OK) {
		    	String selectedFilePath = openFileDialog1.FileName;
		    	String selectedFileName = Path.GetFileName(openFileDialog1.FileName);
		    	
		    	selectedFileName = selectedFileName.Replace(" ", "_");
		    	selectedFileName = selectedFileName.Replace("(", "_");
		    	selectedFileName = selectedFileName.Replace(")", "_");
		    	selectedFileName = selectedFileName.Replace(",", "_");
		    	selectedFileName = selectedFileName.Replace("-", "_");
		    	
		    	String resultFile = HomeForm.pathHome + @"\" + selectedFileName;
		    	if (!File.Exists(resultFile)) {
			    	FileInfo fi = new FileInfo(selectedFilePath);
					fi.CopyTo(resultFile, true);
			    	DisplayApk(HomeForm.pathHome);
			    	MessageBox.Show("Файл \"" + selectedFileName + "\" импортирован успешно!", "Импорт прошёл успешно!",  MessageBoxButtons.OK, MessageBoxIcon.Information);
		    	} else {
		    		MessageBox.Show("Файл с именем \"" + selectedFileName + "\" уже существует!", "Ошибка импорта!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
		    	}
		    }
		}
		
		private void refreshApkFiles(object sender, EventArgs e) {
			DisplayApk(HomeForm.pathHome);
		}
		
		public void DisplayApk(string path) {
			this.comboBox1.Items.Clear();
			string[] files = System.IO.Directory.GetFiles(path);
			for (int x = 0; x < files.Length; x++) {
				if (System.IO.File.Exists(files[x]) && files[x].EndsWith(".apk")) {
					this.comboBox1.Items.Add(System.IO.Path.GetFileName(files[x]));
				}
			}
		}
		
		private void runDecompiling(object sender, EventArgs e) {
			startDecompile(this.comboBox1.SelectedItem.ToString());
		}
		
		public void startDecompile(String apkString) {
			if (!System.IO.File.Exists(HomeForm.pathHome + HomeForm.pathApktoolBat)) {
				MessageBox.Show("Не удалось найти исполнительный .bat файл!", "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				try {
					string selectItemAPK = apkString;
					string noExt = selectItemAPK.Replace(".apk", "");
					resultNoExt = HomeForm.pathHome + @"\" + noExt;
					string resultPathAPK = HomeForm.pathHome + @"\" + selectItemAPK;
					this.label1.Text = resultNoExt;
					button3.Visible = true;
					//MessageBox.Show(resultPathAPK);
					string cmdText = @"/k echo Maked by. ApkTool and SXBaby && cd " + HomeForm.pathHome + " && apktool d " + selectItemAPK;
					Process.Start("cmd.exe", cmdText);
				} catch (Exception ex) {
					MessageBox.Show("Что-то явно пошло не так, не удалось получить .apk файл!\n" + ex.ToString(), "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		private void openPathDecompiled(object sender, EventArgs e) {
			Process.Start("explorer.exe", resultNoExt);
		}
	}
}
