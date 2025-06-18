using System.Windows.Forms;

namespace naveMania
{
    public class Rust : LinguagemProgramacao
    {
    	
        public Rust(MainForm form, PictureBox fundo) : base(form, fundo)
        {
        	
        	this.mainForm = form;
        	
            nome = "Rust";
            dificuldade = 5;
            pontosVida = 1;
            velocidade = 3;
            Load("rust.png");
        }
        
        private bool bossDerrotado = false;

        public void levarDanoRust(int dano)
        {
            pontosVida = pontosVida - dano;
            if (pontosVida < 0)
            {
                pontosVida = 0;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
                if (pontosVida <= 0 && !bossDerrotado)
                {
                	bossDerrotado  = true;
                	this.Hide();
                    Win deuBom = new Win(mainForm);
                    deuBom.ShowDialog();
                }
            }
        }

        public void Atacar(Player jogador)
        {
            jogador.levarDano(20);
        }

        public void Defender()
        {
            pontosVida = pontosVida + 12;
            if (pontosVida > 200)
            {
                pontosVida = 200;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
            }
        }
    }
} 