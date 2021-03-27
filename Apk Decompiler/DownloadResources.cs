/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 6:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Windows;
using System.IO;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of DownloadResources.
	/// </summary>
	public partial class DownloadResources : Form
	{
		
		public static string urlApktool = @"https://bitbucket.org/iBotPeaches/apktool/downloads/apktool_";
		
		string apktool;
		bool isApktool = false;
		
		public DownloadResources()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			
			this.progressBar1.Visible = false;
			this.button2.Visible = false;

			this.comboBox1.Items.Add(urlApktool+"2.5.0.jar");
			this.comboBox1.Items.Add(urlApktool+"2.4.1.jar");		
			this.comboBox1.Items.Add(urlApktool+"2.3.4.jar");
			this.comboBox1.Items.Add(urlApktool+"2.3.3.jar");
			this.comboBox1.Items.Add(urlApktool+"2.3.2.jar");
			this.comboBox1.Items.Add(urlApktool+"2.3.1.jar");
			this.comboBox1.Items.Add(urlApktool+"2.3.0.jar");
			this.comboBox1.Items.Add(urlApktool+"2.2.4.jar");
			this.comboBox1.Items.Add(urlApktool+"2.2.3.jar");
			this.comboBox1.Items.Add(urlApktool+"2.2.2.jar");
			this.comboBox1.Items.Add(urlApktool+"2.2.1.jar");
			this.comboBox1.Items.Add(urlApktool+"2.2.0.jar");
			this.comboBox1.Items.Add(urlApktool+"2.1.1.jar");
			this.comboBox1.Items.Add(urlApktool+"2.1.0.jar");
			this.comboBox1.Items.Add(urlApktool+"2.0.3.jar");
			this.comboBox1.Items.Add(urlApktool+"2.0.2.jar");
			this.comboBox1.Items.Add(urlApktool+"2.0.1.jar");
			this.comboBox1.Items.Add(urlApktool+"2.0.0.jar");
			this.comboBox1.SelectedIndex = 0;
			
			this.label2.Text = "Нет ни одной активной версии Apktool!";
			
			this.button1.Click += new System.EventHandler(runDownloadJar);
			this.button2.Click += new System.EventHandler(deleteJar);
			
			versionApktool();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void runDownloadJar(object sender, EventArgs e) {
			try {
				if (isApktool) {
					MessageBox.Show("Уже есть активная версия Apktool! Удалите активную версию и загрузите желаемую...", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				} else {
					if (this.comboBox1.SelectedItem.ToString().Equals("")) {
						MessageBox.Show("Выберите ссылку для загрузки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else {
//						this.progressBar1.Visible = true;
						runDownloadJarVoid(this.comboBox1.SelectedItem.ToString());
						versionApktool();
//						FileDownloader.DownloadFile(this.comboBox1.SelectedItem.ToString(), HomeForm.pathHome + HomeForm.pathApktoolJar, 99999);
					}
				}
			} catch (Exception ex) {
				MessageBox.Show("Что-то явно пошло не так: " + ex.Message, "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
//			WebClient webClient = new WebClient();
//			webClient.DownloadFile(this.comboBox1.SelectedItem.ToString(), HomeForm.pathHome + HomeForm.pathApktoolJar);
		}
		public static void wc_DownloadProgressChangedJar(object sender, DownloadProgressChangedEventArgs e) {
//			try {
//				progressBar1.Value = e.ProgressPercentage;
//			} catch (Exception e2) {}
		}
		
		private void versionApktool() {
			string[] files = System.IO.Directory.GetFiles(HomeForm.pathHome);
			for (int x = 0; x < files.Length; x++) {
				if (!isApktool) {
					if (files[x].EndsWith(".jar")) {
						apktool = System.IO.Path.GetFileName(files[x]);
						isApktool = true;
						label2.Text = "Текущая версия Apktool: " + apktool.Replace("apktool_", "").Replace(".jar", "");
						this.button2.Visible = true;
					}
				}
			}
		}
		
		public static bool isApkToolDownloaded() {
			bool r = false;
			string[] files = System.IO.Directory.GetFiles(HomeForm.pathHome);
			for (int x = 0; x < files.Length; x++) {
				if (files[x].EndsWith(".jar")) {
					r = true;
				}
			}
			
			return r;
		}
		
		private void deleteJar(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show("Вы действительно хотите удалить файл \"" + apktool + "\"?", "Подтвердите действие!",  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK) {
				File.Delete(HomeForm.pathHome + @"\" + apktool);
				versionApktool();
				this.label2.Text = "Нет ни одной активной версии Apktool!";
				isApktool = false;
				this.button2.Visible = false;
			}
		}
		
		public static void runDownloadJarVoid(string url) {
			using (WebClient wc = new WebClient()) {
//		        wc.DownloadProgressChanged += wc_DownloadProgressChangedJar;
		        wc.DownloadFile(url, HomeForm.pathHome +  @"\" + System.IO.Path.GetFileName(url));
		    }
		}
	}
}
