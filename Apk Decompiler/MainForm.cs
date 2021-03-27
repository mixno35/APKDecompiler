/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 2:45
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using IniFiles;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.label2.Text = "Загрузка...";
			this.label1.Text = "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			string pathBat = HomeForm.pathHome + HomeForm.pathApktoolBat;
			
			IniFile INI = new IniFile("ad.ini");
			
			INI.Write("Settings", "Language", "en");

			if(!File.Exists(pathBat)) {
			   File.Create(pathBat).Dispose();
			
			   using(TextWriter tw = new StreamWriter(pathBat)) {
			   	tw.WriteLine(DataContent.batDefault().Trim());
			      this.label2.Text += "\nСоздаём .bat файла... ";
			   }
			
			}
			
			if (!DownloadResources.isApkToolDownloaded()) {
//				DownloadResources.runDownloadJarVoid(DownloadResources.urlApktool+HomeForm.apktoolLastVersion+".jar");
				this.label2.Text += "\nТребуется загрузить ресурсы...";
			}
		}
	}
}
