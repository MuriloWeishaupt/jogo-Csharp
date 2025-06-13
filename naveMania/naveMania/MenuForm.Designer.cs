/*
 * Created by SharpDevelop.
 * User: muril
 * Date: 11/06/2025
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace naveMania
{
	partial class MenuForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(473, 306);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(141, 60);
			this.button1.TabIndex = 0;
			this.button1.Text = "Iniciar Jogo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1109, 582);
			this.Controls.Add(this.button1);
			this.Name = "MenuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MenuForm";
			this.Load += new System.EventHandler(this.MenuFormLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
	}
}
