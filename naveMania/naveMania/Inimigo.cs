using System;
using System.Windows.Forms;

namespace naveMania
{
	public class Inimigo : Nave
	{
		private int direcaoHorizontal = 1;
		public Timer timerMovimento = new Timer();

		public Inimigo()
		{
			Height = 95;
			Width = 120;
			Top = 70;
			Left = 50;

			Load("naveInimigo.gif");
			
			hp = 10;

			timerMovimento.Interval = 80;
			timerMovimento.Tick += Movimento;
			timerMovimento.Enabled = true;
		}
		
		public void levarDano(int dano) {
			hp -= dano;
			if (hp <= 0) {
				Destruir();
			}
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

		public void Destruir()
		{
			timerMovimento.Enabled = false;
			MainForm.fundo.Controls.Remove(this);
			this.Dispose();
		}
	}
}
