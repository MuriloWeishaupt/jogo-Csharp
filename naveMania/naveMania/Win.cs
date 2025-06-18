
using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
	
	public partial class Win : Form
	{
		
		private MainForm jogoAtual;
		
		public Win(MainForm mainForm)
		{
			
			InitializeComponent();
			this.Load += WinLoad;
			this.jogoAtual = mainForm;
			
			
		}
		
		public PictureBox fundo = new PictureBox();
		
		void WinLoad(object sender, EventArgs e)
		{
			
	        fundo.Parent = this;
	        fundo.Height = this.Height;
	        fundo.Width = this.Width;
	        fundo.Load("zerou-game.png");
	        fundo.SizeMode = PictureBoxSizeMode.StretchImage;
	        this.FormBorderStyle = FormBorderStyle.None;
	        button1.FlatStyle = FlatStyle.Flat;
			button1.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = FlatStyle.Flat;
			button2.FlatAppearance.BorderSize = 0;
        
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			jogoAtual.Close(); 
	        MainForm novoJogo = new MainForm();
	        novoJogo.StartPosition = FormStartPosition.CenterScreen;
	        novoJogo.Show();
	        this.Close();
	        jogoAtual.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
	       
	        jogoAtual.Close(); 
	        MenuForm voltaMenu = new MenuForm();
	        voltaMenu.StartPosition = FormStartPosition.CenterScreen;
	        voltaMenu.Show();
	        this.Close();
	        jogoAtual.Close();
		}
	}
}
