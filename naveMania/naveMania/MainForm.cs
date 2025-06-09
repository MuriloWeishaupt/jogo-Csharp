using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			fundo.Controls.Add(inimigo);
			fundo.Controls.Add(player);
			
			tiroCoolDown.Interval = 200;
			tiroCoolDown.Tick += (s, e) => {
				podeAtirarFi = true;
				tiroCoolDown.Stop();
			};
		}
		
		public static PictureBox fundo = new PictureBox();
		Player player = new Player();
		Inimigo inimigo = new Inimigo();
		public static List<Tiro> tiros = new List<Tiro>();
		Timer tiroCoolDown = new Timer();
		bool podeAtirarFi = true;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			fundo.Parent = this;
			fundo.Height = this.Height;
			fundo.Width = this.Width;
			fundo.Load("space.jpg");
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.D) {
			player.MoveDir();
			}
			
			if (e.KeyCode == Keys.A) {
				player.MoveEsq();
			}
			
			if (e.KeyCode == Keys.W) {
				player.MoveCima();
			}
			
			if (e.KeyCode == Keys.S) {
				player.MoveBaixo();
			}
			
			if (e.KeyCode == Keys.Space && podeAtirarFi) {
				Tiro novoTiro = new Tiro(player.Left, player.Top);
				tiros.Add(novoTiro);
				podeAtirarFi = false;
				tiroCoolDown.Start();
			}
			
		}
		
		
		
	}
}
