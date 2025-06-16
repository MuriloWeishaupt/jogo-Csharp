using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
	
	public partial class MainForm : Form
	{
		
		private LinguagemProgramacao bossAtual;
		
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
		public Label bossVidaLabel;
		public Panel bossBarPanel;
		public Label bossNameLabel;
		public int bossVidaMaxima = 100;
		public Python bossPython;
		public int faseAtual = 1;
		public int totalFases = 5;
		

		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			fundo.Parent = this;
			fundo.Height = this.Height;
			fundo.Width = this.Width;
			fundo.Load("space.jpg");
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
			this.FormBorderStyle = FormBorderStyle.None;
			
			bossNameLabel = new Label();
			bossNameLabel.Text = "Python";
			bossNameLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
			bossNameLabel.ForeColor = System.Drawing.Color.Black;
			bossNameLabel.BackColor = System.Drawing.Color.Transparent;
			bossNameLabel.AutoSize = false;
			bossNameLabel.Width = 200;
			bossNameLabel.Height = 20;
			bossNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bossNameLabel.Left = 20;
			bossNameLabel.Top = 10;
			this.Controls.Add(bossNameLabel);
			bossNameLabel.BringToFront();
			
			bossBarPanel = new Panel();
			bossBarPanel.Width = 200;
			bossBarPanel.Height = 20;
			bossBarPanel.Left = 20;
			bossBarPanel.Top = bossNameLabel.Bottom + 2;
			bossBarPanel.BackColor = System.Drawing.Color.LimeGreen;
			this.Controls.Add(bossBarPanel);
			bossBarPanel.BringToFront();
			
			player = new Player(fundo, this);
			fundo.Controls.Add(player);
			
			SpawnBossFase();
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			
			if (e.KeyCode == Keys.D) {
			player.MoveDir();
			player.AtualizarLabels();
			}
			
			if (e.KeyCode == Keys.A) {
				player.MoveEsq();
				player.AtualizarLabels();
			}
			
			if (e.KeyCode == Keys.W) {
				player.MoveCima();
				player.AtualizarLabels();
			}
			
			if (e.KeyCode == Keys.S) {
				player.MoveBaixo();
				player.AtualizarLabels();
			}
			
			if (e.KeyCode == Keys.Space && podeAtirarFi) {
				Tiro novoTiro = new Tiro(player.Left, player.Top, this);
				tiros.Add(novoTiro);
				podeAtirarFi = false;
				tiroCoolDown.Start();
			}
			
		}
		
		
		public void SpawnBossFase()
		{

			if (faseAtual == 1)
				fundo.Load("pycharm.png");
			if (faseAtual == 2)
				fundo.Load("vscode.png");
			if (faseAtual == 3)
				fundo.Load("intelij.png");
			if (faseAtual == 4)
				fundo.Load("vscodecsharp.png");
			if (faseAtual == 5)
				fundo.Load("rustfinal.png");


			Control boss = null;
			if (faseAtual == 1)
				boss = new Python(this, fundo);
			else if (faseAtual == 2)
				boss = new JavaScript(this, fundo);
			else if (faseAtual == 3)
				boss = new Java(this, fundo);
			else if (faseAtual == 4)
				boss = new CSharp(this, fundo);
			else if (faseAtual == 5)
				boss = new Rust(this, fundo);

			if (boss != null)
			{
				boss.Left = 200;
				boss.Top = 50;
				fundo.Controls.Add(boss);
				AtualizarBossBar(((LinguagemProgramacao)boss).pontosVida);
				bossNameLabel.Text = ((LinguagemProgramacao)boss).nome;
			}
			
			this.bossAtual = (LinguagemProgramacao)boss;
		}

		public void ProximaFase()
		{
			
			faseAtual++;
			if (faseAtual <= totalFases)
			{
				SpawnBossFase();
			}
		}
		
		public void AtualizarBossBar(int vidaAtual)
		{
			if (vidaAtual < 0) vidaAtual = 0;
			int larguraMaxima = 200;
			bossBarPanel.Width = (int)(larguraMaxima * vidaAtual / (float)bossVidaMaxima);
			if (vidaAtual > bossVidaMaxima / 2)
				bossBarPanel.BackColor = System.Drawing.Color.LimeGreen;
			else if (vidaAtual > bossVidaMaxima / 4)
				bossBarPanel.BackColor = System.Drawing.Color.Orange;
			else
				bossBarPanel.BackColor = System.Drawing.Color.Red;
		}
		
		
		
	}
}
