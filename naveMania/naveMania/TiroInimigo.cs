using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
    public class TiroInimigo : PictureBox
    {
        private Timer timerTiro = new Timer();

        public TiroInimigo(int x, int y)
        {
            Width = 10;
            Height = 30;
            BackColor = Color.Red;
            Location = new Point(x + 30, y + 60);
            Parent = MainForm.fundo;
            BringToFront();

            timerTiro.Interval = 20;
            timerTiro.Tick += Mover;
            timerTiro.Start();
        }

        private void Mover(object sender, EventArgs e)
        {
            Top += 10; 

            if (Top > MainForm.fundo.Height)
            {
                timerTiro.Stop();
                Dispose();
                return;
            }

            if (this.Bounds.IntersectsWith(MainForm.player.Bounds))
            {
                MainForm.player.levarDano(1);
                timerTiro.Stop();
                MainForm.fundo.Controls.Remove(this);
                Dispose();
            }
        }
    }
}
