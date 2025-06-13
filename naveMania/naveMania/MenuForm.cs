using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{

	public partial class MenuForm : Form
	{
		public MenuForm()
		{
			
			InitializeComponent();
			
			Button startButton = new Button();
			startButton.Text = "Iniciar Jogo";
			startButton.Width = 120;
			startButton.Height = 40;
			startButton.Top = 100;
			startButton.Left = 100;
		}
		
		public static PictureBox fundo = new PictureBox();
		
		void MenuFormLoad(object sender, EventArgs e)
		{
			fundo.Parent = this;
			fundo.Height = this.Height;
			fundo.Width = this.Width;
			fundo.Load("menu-start.png");
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Hide();
			MainForm jogo = new MainForm();
			jogo.ShowDialog();
		}
	}
}
