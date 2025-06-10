using System;
using System.Windows.Forms;
using System.Drawing;

namespace naveMania
{
	
	public class Nave: PictureBox
	{
			
		public Nave()
		{
		
			Width = 70;
			Height = 70;
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Parent = MainForm.fundo;
		}
		
		public int attack = 10;
		public int hp = 10;
		public int speed = 40;
		public int direcao = 1;
		
		
		
		public void Destruir() {
			MainForm.fundo.Controls.Remove(this);
			Dispose();
		}
	}
}
