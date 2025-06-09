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

			timerMovimento.Interval = 80;
			timerMovimento.Tick += Movimento;
			timerMovimento.Enabled = true;
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
