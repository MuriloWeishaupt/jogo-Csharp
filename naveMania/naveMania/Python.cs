using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
    public class Python : LinguagemProgramacao
    {
        public Python(MainForm form, PictureBox fundo) : base(form, fundo)
        {
            nome = "Python";
            dificuldade = 1;
            pontosVida = 1;
            velocidade = 2;
            Load("python.png");
        }

        public void levarDanoPython(int dano)
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
                    mainForm.ProximaFase();
                    this.Dispose();
                }
            }
        }

        public void Atacar(Player jogador)
        {
            jogador.levarDano(10);
        }

        public void Defender()
        {
            pontosVida = pontosVida + 5;
            if (pontosVida > 100)
            {
                pontosVida = 100;
            }
            if (mainForm != null)
            {
                mainForm.AtualizarBossBar(pontosVida);
            }
        }
    }
} 