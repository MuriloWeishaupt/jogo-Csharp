using System;
using System.Windows.Forms;
using System.Drawing;

namespace naveMania
{

	public class Player: Nave
	{
		private MainForm mainForm;
		public static bool gameOverativo = false;
		
		public Player(PictureBox fundo, MainForm mainForm) : base(fundo)
		{
			Load("navePlayer.gif");
			Left = 200;
			Top = 200;
		}
		
		public void MoveDir()
			{
				Left += speed;
				if ( Left >= 1000) {
					Left = 0;
				}
				
				if (direcao == -1) {
					direcao = 1;
				}
			}
		
		public void MoveEsq() {
			Left -= speed;
			if (Left <= 0) {
				Left = 1000;
			}
			
			if (direcao == 1) {
				direcao = -1;
			}
		}
		
		public void MoveCima() {
			Top -= speed;
			if (Top <= 0) {
				Top = 0;
			}
		}
		
		public void MoveBaixo() {
			Top += speed;
			if (Top >= 360) {
				Top = 360;
			}
		}
		
		
		public void levarDano(int dano) {
			hp -= dano;
			if (hp <= 0) {
				Destruir();
				if (!gameOverativo) {
					gameOverativo = true;
					GameOverForm gameOver = new GameOverForm(mainForm);
					gameOver.ShowDialog();
				}
				
				

			}
		}
	}
}
