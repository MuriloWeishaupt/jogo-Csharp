using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{

	public class Tiro: PictureBox
	{
			
		private Timer timerTiro = new Timer();
		
		public Tiro(int x, int y)
		{
			Width = 10;
			Height = 30;
			BackColor = Color.Yellow;
			Location = new Point(x + 30, y);
			Parent = MainForm.fundo;
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
		        timerTiro.Stop();
		        Dispose();
		        return;
		    }
		
		    foreach (Control ctrl in MainForm.fundo.Controls) 
		    {
		    	if (ctrl is Inimigo) {
		    		Inimigo inimigo = (Inimigo)ctrl;
		    		if (this.Bounds.IntersectsWith(inimigo.Bounds)) {
		    			inimigo.levarDano(1);
		    			this.Destruir();
		    			break;
		    		}
		    	}
		       
		    }
		}
		
		private void Destruir() {
			timerTiro.Stop();
			timerTiro.Dispose();
			MainForm.fundo.Controls.Remove(this);
			MainForm.tiros.Remove(this);
			Dispose();
		}
	}
}
