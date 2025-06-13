using System;
using System.Windows.Forms;

namespace naveMania
{
	public class Inimigo : Nave
	{
		private int direcaoHorizontal = 1;
		public Timer timerMovimento = new Timer();
		private Timer timerAtirar = new Timer();
		private MainForm mainForm;

		public Inimigo(MainForm form, PictureBox fundo): base(fundo)
		{
			
			mainForm = form;
			
			Height = 95;
			Width = 120;
			Top = 70;
			Left = 50;

			Load("naveInimigo.gif");
			
			hp = 10;

			timerMovimento.Interval = 80;
			timerMovimento.Tick += Movimento;
			timerMovimento.Enabled = true;
			timerAtirar.Interval = 500;
			timerAtirar.Tick += Atirar;
			timerAtirar.Enabled = true;
		}
		
		
		private void Atirar(object sender, EventArgs e) {
			TiroInimigo tiro = new TiroInimigo(Left, Top, mainForm);
		}
		
		

		private void Movimento(object sender, EventArgs e)
		{
			Left += speed * direcaoHorizontal;


			if (Left >= 700)
			{
				direcaoHorizontal = -1;
			}
			else if (Left <= 50)
			{
				direcaoHorizontal = 1;
			}
		}
		
		public void levarDano(int dano) {
			hp -= dano;
			if (hp <= 0) {
				Destruir();
			}
		}

		public void Destruir()
		{
			timerMovimento.Stop();
			timerAtirar.Stop();
			this.Dispose();
			mainForm.SpawnInimigos(2);
		}
	}
}
