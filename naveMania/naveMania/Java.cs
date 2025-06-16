using System.Windows.Forms;

namespace naveMania
{
    public class Java : LinguagemProgramacao
    {
        public Java(MainForm form, PictureBox fundo) : base(form, fundo)
        {
            nome = "Java";
            dificuldade = 3;
            pontosVida = 1;
            velocidade = 2;
            Load("java.png");
        }

        public void levarDanoJava(int dano)
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
            jogador.levarDano(15);
        }

        public void Defender()
        {
            pontosVida = pontosVida + 8;
            if (pontosVida > 140)
            {
                pontosVida = 140;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
            }
        }
    }
} 