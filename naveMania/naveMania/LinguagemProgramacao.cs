using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
    public class LinguagemProgramacao : Inimigo
    {
        public string nome;
        public int dificuldade;
        public int pontosVida;
        public int velocidade;

        public LinguagemProgramacao(MainForm form, PictureBox fundo) : base(form, fundo)
        {

        }

        public void ReceberDano(int dano)
        {
            pontosVida = pontosVida - dano;
            if (pontosVida < 0)
            {
                pontosVida = 0;
            }
        }

        public void Mover()
        {
            Left = Left + velocidade;
        }
    }
} 