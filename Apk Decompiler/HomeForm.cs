/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 2:51
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of HomeForm.
	/// </summary>
	public partial class HomeForm : Form
	{
		public static string apktoolLastVersion = @"2.5.0";
		public static string pathHome = @"C:\Apk Decompiler";
		public static string pathApktoolJar = @"\apktool_" + apktoolLastVersion + @".jar";
		public static string pathApktoolBat = @"\apktool.bat";
		public static string defauldDecompileFile = @"\AndroidManifest.xml";
		
		private ProgressBar p;
		
		public HomeForm(Thread aplashscreen)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			Directory.CreateDirectory(pathHome);
			InitializeComponent();
			
			if (!System.IO.File.Exists(HomeForm.pathHome + HomeForm.pathApktoolBat)) {
				
			}
			
			p = new ProgressBar();
			p.Location = new Point(10, 10);
			p.Size = new Size(100, 30);
			p.MarqueeAnimationSpeed = 30;
			p.Style = ProgressBarStyle.Marquee;
			
			this.button1.Click += new System.EventHandler(downloadResources);
			this.button3.Click += new System.EventHandler(importApk);
			
			aplashscreen.Abort();
			
			DisplayApk(pathHome);
			DisplayDecompiled(pathHome);
			
			this.apkToolToolStripMenuItem.Text = "ApkTool";
			
			
			this.listView1.MouseUp += new MouseEventHandler(listView1_MouseDown);
			this.listView2.MouseUp += new MouseEventHandler(listView2_MouseDown);
			
			progressBarHideCC();
			
			this.devToolStripMenuItem.Click += new System.EventHandler(aboutDeveloper);
			this.apkToolToolStripMenuItem.Click += new System.EventHandler(aboutApkTool);
			this.decompileApkFileToolStripMenuItem.Click += new System.EventHandler(openDecompile);
			this.makeToApkToolStripMenuItem.Click += new System.EventHandler(openBuild);
			this.button2.Click += new System.EventHandler(updatingLists);
			
			this.refreshListsToolStripMenuItem.Click += new System.EventHandler(updatingLists);
			this.downloadResourcesToolStripMenuItem.Click += new System.EventHandler(downloadResources);
			this.importApkToolStripMenuItem.Click += new System.EventHandler(importApk);
			
			this.button4.Click += new System.EventHandler(searchGo);
			this.button5.Click += new System.EventHandler(searchClear);
			
			this.groupBox1.Text = "Доступные .apk для декомпиляции";
			this.groupBox2.Text = "Декомпилированные файлы";
			
//			this.label1.Text =
			
//			this.textBox1.I
			
			foreach(ColumnHeader column in this.listView1.Columns) {
		        column.Width = 240;
		    }
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void searchGo(object sub, EventArgs e) {
			if (textBox1.Text != "") {
		    foreach (ListViewItem item in listView1.Items) {
		        if (item.Text.ToLower().Contains(textBox1.Text.ToLower())) {
		            item.Selected = true;
		        } else {
		            listView1.Items.Remove(item);
		        }
		
		    }
			foreach (ListViewItem item2 in listView2.Items) {
		        if (item2.Text.ToLower().Contains(textBox1.Text.ToLower())) {
		            item2.Selected = true;
		        } else {
		            listView2.Items.Remove(item2);
		        }
		
		    }
	        if (listView1.SelectedItems.Count == 1) {
//	            listView1.Focus();
	        }
		    } else { 
		    	DisplayApk(pathHome);
				DisplayDecompiled(pathHome);
		    }
		}
		private void searchClear(object sub, EventArgs e) {
			DisplayApk(pathHome);
			DisplayDecompiled(pathHome);
			textBox1.Text = "";
		}
		
		private void updatingLists(object sub, EventArgs e) {
			DisplayApk(pathHome);
			DisplayDecompiled(pathHome);
		}
		
		private void downloadResources(object sub, EventArgs e) {
			new DownloadResources().ShowDialog();
		}
		
		private void openBuild(object sub, EventArgs e) {
			new BuildAPK().ShowDialog();
		}
		
		private void openDecompile(object sub, EventArgs e) {
			new DecompileAPK().ShowDialog();
		}
		private void importApk(object sub, EventArgs e) {
			progressBarShowCC();
			p.Show();
			
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

		    openFileDialog1.Filter = "Database files (*.apk)|*.apk" ;
		    openFileDialog1.FilterIndex = 0;
		    openFileDialog1.RestoreDirectory = true ;
		    DialogResult resultFileDialog1 = openFileDialog1.ShowDialog();
		    
//		    p.Show();
		
		    if(resultFileDialog1 == DialogResult.OK) {
		    	String selectedFilePath = openFileDialog1.FileName;
		    	String selectedFileName = Path.GetFileName(openFileDialog1.FileName);
		    	
		    	selectedFileName = selectedFileName.Replace(" ", "_");
		    	selectedFileName = selectedFileName.Replace("(", "_");
		    	selectedFileName = selectedFileName.Replace(")", "_");
		    	selectedFileName = selectedFileName.Replace(",", "_");
		    	selectedFileName = selectedFileName.Replace("-", "_");
		    	
		    	String resultFile = pathHome + @"\" + selectedFileName;
		    	if (!File.Exists(resultFile)) {
			    	FileInfo fi = new FileInfo(selectedFilePath);
					fi.CopyTo(resultFile, true);
			    	DisplayApk(pathHome);
//			    	p.Hide();
			    	progressBarHideCC();
			    	MessageBox.Show("Файл \"" + selectedFileName + "\" импортирован успешно!", "Импорт прошёл успешно!",  MessageBoxButtons.OK, MessageBoxIcon.Information);
		    	} else {
//		    		p.Hide();
		    		progressBarHideCC();
		    		MessageBox.Show("Файл с именем \"" + selectedFileName + "\" уже существует!", "Ошибка импорта!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
		    	}
		    }
		    if(resultFileDialog1 == DialogResult.Cancel) {
//		    	p.Hide();
		    	progressBarHideCC();
		    }
		}
		
		private void aboutDeveloper(object sub, EventArgs e) {
			new About().ShowDialog();
		}
		private void aboutApkTool(object sub, EventArgs e) {
			System.Diagnostics.Process.Start("https://ibotpeaches.github.io/Apktool");
		}
		
		
		public void DisplayApk(string path) {
			this.listView1.Items.Clear();
			string[] files = System.IO.Directory.GetFiles(path);
			for (int x = 0; x < files.Length; x++) {
				if (System.IO.File.Exists(files[x]) && files[x].EndsWith(".apk")) {
					ListViewItem items = new ListViewItem(System.IO.Path.GetFileName(files[x]));
					items.SubItems.Add(files[x]);
					this.listView1.Items.Add(items);
				}
			}
			toolStripStatusLabel1.Text = "APK файлов: " + listView1.Items.Count.ToString();
		}
		
		public void DisplayDecompiled(string path) {
			this.listView2.Items.Clear();
			string[] files2 = System.IO.Directory.GetDirectories(path);
			for (int x = 0; x < files2.Length; x++) {
				if (System.IO.Directory.Exists(files2[x])) {
					if (System.IO.File.Exists(files2[x] + defauldDecompileFile)) {
						ListViewItem items = new ListViewItem(files2[x]);
						String item = files2[x].Replace(path + @"\", "");
						listView2.Items.Add(item + ".apk");
					}
				}
			}
			toolStripStatusLabel2.Text = "Декомпилированных файлов: " + listView2.Items.Count.ToString();
		}
		void listView1_MouseDown(object sender, MouseEventArgs e) {
			bool match = false;
		
		    if (e.Button == System.Windows.Forms.MouseButtons.Right) {
		        foreach (ListViewItem item in listView1.Items) {
		        	if (item.Bounds.Contains(new Point(e.X, e.Y))) {
		    			String selectedItem = item.Text;
		    			String nameSelectedItem = item.Text;
		                MenuItem[] mi = { 
		    				new MenuItem("Декомпилировать", listView1_Menu1_Click), 
		    				new MenuItem("Удалить", listView1_Menu2_Click) 
		    			};
		                listView1.ContextMenu = new ContextMenu(mi);
		                match = true;
		                break;
		            }
		        }
		    	
		        if (match) {
		            listView1.ContextMenu.Show(listView1, new Point(e.X, e.Y));
		        } else {
		            //Show listViews context menu
		        }
		
		    }
		
		}
		void listView1_Menu1_Click(Object sender, EventArgs e) {
			String nameApk = listView1.FocusedItem.Text;
			DialogResult result = MessageBox.Show("Вы действительно хотите начать декомпиляцию файла \"" + nameApk + "\"?", "Подтвердите действие!",  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK) {
				new DecompileAPK().startDecompile(nameApk);
			}
 		}
		void listView1_Menu2_Click(Object sender, EventArgs e) {
			String nameApk = listView1.FocusedItem.Text;
			DialogResult result = MessageBox.Show("Вы действительно хотите удалить файл \"" + nameApk + "\"?", "Подтвердите действие!",  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK) {
				File.Delete(pathHome + @"\" + nameApk);
				DisplayApk(pathHome);
			}
		}
		
		
		void listView2_MouseDown(object sender, MouseEventArgs e) {
			bool match = false;
	
		    if (e.Button == System.Windows.Forms.MouseButtons.Right) {
		        foreach (ListViewItem item in listView2.Items) {
		        	if (item.Bounds.Contains(new Point(e.X, e.Y))) {
		    			String selectedItem = item.Text;
		    			String nameSelectedItem = item.Text;
		                MenuItem[] mi = {
		    				new MenuItem("Собрать в .apk", listView2_Menu1_Click),
		    				new MenuItem("Удалить", listView2_Menu2_Click) 
		    			};
		                listView2.ContextMenu = new ContextMenu(mi);
		                match = true;
		                break;
		            }
		        }
		    	
		        if (match) {
		            listView2.ContextMenu.Show(listView2, new Point(e.X, e.Y));
		        } else {
		            //Show listViews context menu
		        }
		
		    }
		
		}
		void listView2_Menu1_Click(Object sender, EventArgs e) {
			String nameFile = listView2.FocusedItem.Text;
			DialogResult result = MessageBox.Show("Вы действительно хотите начать сборку файла \"" + nameFile + "\"?", "Подтвердите действие!",  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK) {
				new BuildAPK().startBuild(nameFile.Replace(".apk", ""));
			}
 		}
		void listView2_Menu2_Click(Object sender, EventArgs e) {
			String name = listView2.FocusedItem.Text;
			DialogResult result = MessageBox.Show("Вы действительно хотите удалить \"" + name + "\"?", "Подтвердите действие!",  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK) {
				Directory.Delete(pathHome + @"\" + name.Replace(".apk", ""), true);
				DisplayDecompiled(pathHome);
			}
		}
		
		
		void HomeFormLoad(object sender, EventArgs e)
		{
	
		}
		void GroupBox1Enter(object sender, EventArgs e)
		{
	
		}
		
		
		private void progressBarHideCC() {
//			pictureLogo.Visible = true;
//		    progressBar1.Visible = false;
//		    labelProgress1.Visible = false;
		}
		private void progressBarShowCC() {
//			pictureLogo.Visible = false;
//		    progressBar1.Visible = true;
//		    labelProgress1.Visible = true;
		}
	}
}
