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
        SizeMode = PictureBoxSizeMode.StretchImage;
        this.Load("tiro.png");
        Width = 30;
        Height = 50;
        BackColor = Color.Transparent;
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
            Python python = ctrl as Python;
            if (python != null)
            {
                if (this.Bounds.IntersectsWith(python.Bounds))
                {
                    python.levarDanoPython(1);
                    Destruir();
                    break;
                }
            }
            JavaScript javascript = ctrl as JavaScript;
            if (javascript != null)
            {
                if (this.Bounds.IntersectsWith(javascript.Bounds))
                {
                    javascript.levarDanoJavaScript(1);
                    Destruir();
                    break;
                }
            }
            Java java = ctrl as Java;
            if (java != null)
            {
                if (this.Bounds.IntersectsWith(java.Bounds))
                {
                    java.levarDanoJava(1);
                    Destruir();
                    break;
                }
            }
            CSharp csharp = ctrl as CSharp;
            if (csharp != null)
            {
                if (this.Bounds.IntersectsWith(csharp.Bounds))
                {
                    csharp.levarDanoCSharp(1);
                    Destruir();
                    break;
                }
            }
            Rust rust = ctrl as Rust;
            if (rust != null)
            {
                if (this.Bounds.IntersectsWith(rust.Bounds))
                {
                    rust.levarDanoRust(1);
                    Destruir();
                    break;
                }
            }
            Inimigo inimigo = ctrl as Inimigo;
            if (inimigo != null && !(ctrl is Python) && !(ctrl is JavaScript) && !(ctrl is Java) && !(ctrl is CSharp) && !(ctrl is Rust))
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