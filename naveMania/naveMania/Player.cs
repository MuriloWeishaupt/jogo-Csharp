using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
	public class Player : PictureBox
	{
		private MainForm mainForm;
		public static bool gameOverativo = false;
		public Label labelNome;
		public Label labelVida;
		public bool estaVivo;

		public Player(PictureBox fundo, MainForm mainForm)
		{
			this.mainForm = mainForm;
			estaVivo = true;
			Width = 90;
			Height = 90;
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Load("navePlayer.gif");
			Left = 200;
			Top = 200;
			Parent = fundo;

			labelNome = new Label();
			labelNome.Text = "Player";
			labelNome.AutoSize = true;
			labelNome.BackColor = System.Drawing.Color.Transparent;
			labelNome.ForeColor = System.Drawing.Color.White;
			labelNome.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
			fundo.Controls.Add(labelNome);

			labelVida = new Label();
			labelVida.Text = "Vida: " + pontosVida + "/100";
			labelVida.AutoSize = true;
			labelVida.BackColor = System.Drawing.Color.Transparent;
			labelVida.ForeColor = System.Drawing.Color.Lime;
			labelVida.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
			fundo.Controls.Add(labelVida);

			AtualizarLabels();
		}

		public int pontosVida = 100;
		public int pontuacao = 0;
		public int nivel = 1;
		public int velocidade = 20;
		public int direcao = 1;

		public void AtualizarLabels()
		{
			labelNome.Left = this.Left + (this.Width - labelNome.Width) / 2;
			labelNome.Top = this.Top - 30;
			labelVida.Left = this.Left + (this.Width - labelVida.Width) / 2;
			labelVida.Top = this.Top - 15;
			labelVida.Text = "Vida: " + pontosVida + "/100";
		}

		public void levarDano(int dano)
		{
			
			if (!estaVivo) return;
			
			pontosVida = pontosVida - dano;
			if (pontosVida <= 0)
			{
				pontosVida = 0;
				estaVivo = false;
				
				if (!gameOverativo)
				{
					gameOverativo = true;
					GameOverForm gameOver = new GameOverForm(mainForm);
					gameOver.ShowDialog();
				}
			}
			AtualizarLabels();
		}

		public void MoveDir()
		{
			if (!estaVivo) return;
			
			Left = Left + velocidade;
			if (Left >= 1000)
			{
				Left = 0;
			}
			if (direcao == -1)
			{
				direcao = 1;
			}
			AtualizarLabels();
		}

		public void MoveEsq()
		{
			if (!estaVivo) return;
			
			Left = Left - velocidade;
			if (Left <= 0)
			{
				Left = 1000;
			}
			if (direcao == 1)
			{
				direcao = -1;
			}
			AtualizarLabels();
		}

		public void MoveCima()
		{
			if (!estaVivo) return;
			
			Top = Top - velocidade;
			if (Top <= 0)
			{
				Top = 0;
			}
			AtualizarLabels();
		}

		public void MoveBaixo()
		{
			if (!estaVivo) return;
			
			Top = Top + velocidade;
			if (Top >= 360)
			{
				Top = 360;
			}
			AtualizarLabels();
		}

		public void Atacar(LinguagemProgramacao alvo)
		{
			if (!estaVivo) return;
			
			int dano = 100 + (nivel * 20);
			alvo.ReceberDano(dano);
			if (alvo.pontosVida <= 0 )
			{
				pontuacao = pontuacao + 500;
				nivel = nivel + 1;
				mainForm.ProximaFase();
			}
		}
		
		public void Resetar() {
			pontosVida = 100;
			nivel = 1;
			estaVivo = true;
			gameOverativo = false;
			
			AtualizarLabels();
		}
	}
}
