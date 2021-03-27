/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 26.03.2021
 * Время: 19:18
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using IniFiles;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of About.
	/// </summary>
	public partial class About : Form
	{
		
		private IniFile INI = new IniFile("ad.ini");
		
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			this.label1.BorderStyle = BorderStyle.Fixed3D;
			
			this.label2.Text = version;
			
			this.label3.Text = "Данная программа созданна для быстрой работы с ApkTool. Для корректной работы программы, загрузите ресурсы.";
			
			this.label4.BorderStyle = BorderStyle.Fixed3D;
			
			this.label5.Text = "SXBaby";
			
			this.linkLabel1.Text = "Telegram";
			this.linkLabel1.Click += new System.EventHandler(developerTelegram);
			
			this.button1.Click += new System.EventHandler(downloadResources);
			this.button2.Click += new System.EventHandler(instruction);
			this.button3.Click += new System.EventHandler(saveLanguage);
			
			this.comboBox1.Items.Add("Русский");
			try {
				this.comboBox1.SelectedIndex = 0;
			} catch (Exception e) {}
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void downloadResources(object sub, EventArgs e) {
			new DownloadResources().ShowDialog();
		}
		
		private void instruction(object sub, EventArgs e) {
			new Instruction().ShowDialog();
		}
		
		private void developerTelegram(object sub, EventArgs e) {
			System.Diagnostics.Process.Start("https://t.me/sx_baby");
		}
		
		private void saveLanguage(object sub, EventArgs e) {
			if (comboBox1.Text == "Русский") {
				INI.Write("Settings", "Language", "ru");
			}
			MessageBox.Show("Language switched to : " + comboBox1.Text);
		}
	}
}
