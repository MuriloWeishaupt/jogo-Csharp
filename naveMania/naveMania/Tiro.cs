using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
public class Tiro : PictureBox
{
    private Timer timerTiro = new Timer();
    private MainForm mainForm;
    


    public Tiro(int x, int y, MainForm mainForm)
    {
        this.mainForm = mainForm;
        mainForm.fundo.Controls.Add(this); 

        Width = 10;
        Height = 30;
        BackColor = Color.Yellow;
        Location = new Point(x + 30, y);
        BringToFront();

        timerTiro.Interval = 30;
        timerTiro.Tick += Mover;
        timerTiro.Start();
    }

    private void Mover(object sender, EventArgs e)
    {
        Top -= 15;

        if (Top < 30)
        {
            Destruir();
            return;
        }

        foreach (Control ctrl in mainForm.fundo.Controls)
        {
        	Inimigo inimigo = ctrl as Inimigo;
            if (inimigo != null)
            {
                if (this.Bounds.IntersectsWith(inimigo.Bounds))
                {
                    inimigo.levarDano(1);
                    Destruir();
                    break;
                }
            }
        }
    }

    public void Destruir()
    {
        timerTiro.Stop();
        timerTiro.Dispose();
        mainForm.fundo.Controls.Remove(this);
        mainForm.tiros.Remove(this);
        Dispose();
    }
}
}