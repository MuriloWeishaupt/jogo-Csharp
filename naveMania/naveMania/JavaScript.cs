using System.Windows.Forms;

namespace naveMania
{
    public class JavaScript : LinguagemProgramacao
    {
        public JavaScript(MainForm form, PictureBox fundo) : base(form, fundo)
        {
            nome = "JavaScript";
            dificuldade = 2;
            pontosVida = 1;
            velocidade = 3;
            Load("javascript.png");
        }

        public void levarDanoJavaScript(int dano)
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
            jogador.levarDano(12);
        }

        public void Defender()
        {
            pontosVida = pontosVida + 5;
            if (pontosVida > 120)
            {
                pontosVida = 120;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
            }
        }
    }
} 