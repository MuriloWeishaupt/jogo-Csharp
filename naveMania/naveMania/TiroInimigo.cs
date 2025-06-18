using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
    public class TiroInimigo : PictureBox
    {
        private Timer timerTiro = new Timer();
        private MainForm mainForm; 

 
        public TiroInimigo(int x, int y, MainForm form)
        {
            this.mainForm = form;
            mainForm.fundo.Controls.Add(this);
            SizeMode = PictureBoxSizeMode.StretchImage;
            this.Load("tiroDown.png");

            Width = 30;
            Height = 50;
            BackColor = Color.Transparent;
            Location = new Point(x + 30, y + 60);
            BringToFront();

            timerTiro.Interval = 20;
            timerTiro.Tick += Mover;
            timerTiro.Start();
        }

        private void Mover(object sender, EventArgs e)
        {
            Top += 10;

            if (Top > mainForm.fundo.Height)
            {
                timerTiro.Stop();
                mainForm.fundo.Controls.Remove(this);
                Dispose();
                return;
            }

            if (this.Bounds.IntersectsWith(mainForm.player.Bounds))
            {
                mainForm.player.levarDano(1);
                timerTiro.Stop();
                mainForm.fundo.Controls.Remove(this);
                Dispose();
            }
        }
    }
}
