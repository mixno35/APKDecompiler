/*
 * Создано в SharpDevelop.
 * Пользователь: Admin
 * Дата: 11.07.2020
 * Время: 5:41
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Apk_Decompiler
{
	partial class BuildAPK
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Button button1;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildAPK));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(527, 49);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите декомпилированный файл";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(7, 20);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(514, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.flowLayoutPanel2.Controls.Add(this.button1);
			this.flowLayoutPanel2.Controls.Add(this.button2);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 223);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(12, 15, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(553, 108);
			this.flowLayoutPanel2.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 15);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(527, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "Собрать";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 59);
			this.button2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(527, 34);
			this.button2.TabIndex = 1;
			this.button2.Text = "Обновить список декомпилированных файлов";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// BuildAPK
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(552, 330);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BuildAPK";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Собрать в .apk";
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
