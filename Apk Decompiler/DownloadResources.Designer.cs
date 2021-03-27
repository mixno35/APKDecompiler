/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 6:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Apk_Decompiler
{
	partial class DownloadResources
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadResources));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(13, 128);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(437, 13);
			this.progressBar1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 75);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(438, 34);
			this.button1.TabIndex = 2;
			this.button1.Text = "Загрузить";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(13, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(437, 21);
			this.comboBox1.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.label1.Location = new System.Drawing.Point(13, 188);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(437, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "Возможно, придётся подождать...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoEllipsis = true;
			this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(5);
			this.label2.Size = new System.Drawing.Size(463, 37);
			this.label2.TabIndex = 13;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.Location = new System.Drawing.Point(375, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "Удалить";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// DownloadResources
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(462, 213);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DownloadResources";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Загрузка ресурсов";
			this.ResumeLayout(false);

		}
	}
}
