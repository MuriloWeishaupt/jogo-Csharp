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
			
			tiroCoolDown.Interval = 200;
			tiroCoolDown.Tick += (s, e) => {
			podeAtirarFi = true;
			tiroCoolDown.Stop();
			};
		}
		
		
		public Player player;
		public PictureBox fundo = new PictureBox();
		public List<Tiro> tiros = new List<Tiro>();
		Timer tiroCoolDown = new Timer();
		bool podeAtirarFi = true;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			fundo.Parent = this;
			fundo.Height = this.Height;
			fundo.Width = this.Width;
			fundo.Load("space.jpg");
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
			
			player = new Player(fundo, this);
			fundo.Controls.Add(player);
			
			SpawnInimigos(1);
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
				Tiro novoTiro = new Tiro(player.Left, player.Top, this);
				tiros.Add(novoTiro);
				podeAtirarFi = false;
				tiroCoolDown.Start();
			}
			
		}
		
		
		public void SpawnInimigos(int quant) {
			for (int i = 0; i < quant; i++) {
				Inimigo novoInimigo = new Inimigo(this, fundo);
				novoInimigo.Left = 50 + i * 150;
				novoInimigo.Top = 0;
				fundo.Controls.Add(novoInimigo);
			}
		}
		
		
		
	}
}
