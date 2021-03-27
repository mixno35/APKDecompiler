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

namespace Apk_Decompiler
{
	/// <summary>
	/// Description of Instruction.
	/// </summary>
	public partial class Instruction : Form
	{
		public Instruction()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.panel1.AutoScroll = false;
			this.panel1.HorizontalScroll.Enabled = false;
			this.panel1.HorizontalScroll.Visible = false;
			this.panel1.HorizontalScroll.Maximum = 0;
			this.panel1.AutoScroll = true;
			
			this.MouseWheel += new MouseEventHandler(Panel1_MouseWheel);
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void Panel1_MouseWheel(object sender, MouseEventArgs e) {
        	panel1.Focus();
        }
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://www.oracle.com/java/technologies/javase-downloads.html");
		}
	}
}
