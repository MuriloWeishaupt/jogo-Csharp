using System.Windows.Forms;

namespace naveMania
{
    public class CSharp : LinguagemProgramacao
    {
        public CSharp(MainForm form, PictureBox fundo) : base(form, fundo)
        {
            nome = "CSharp";
            dificuldade = 4;
            pontosVida = 1;
            velocidade = 2;
            Load("csharp.png");
        }

        public void levarDanoCSharp(int dano)
        {
            pontosVida = pontosVida - dano;
            if (pontosVida < 0)
            {
                pontosVida = 0;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
                if (pontosVida <= 0)
                {
                    this.Hide();
                	PassaFase pf = new PassaFase(mainForm, this);
                	pf.Show();
                }
            }
        }

        public void Atacar(Player jogador)
        {
            jogador.levarDano(18);
        }

        public void Defender()
        {
            pontosVida = pontosVida + 10;
            if (pontosVida > 180)
            {
                pontosVida = 180;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
            }
        }
    }
} 