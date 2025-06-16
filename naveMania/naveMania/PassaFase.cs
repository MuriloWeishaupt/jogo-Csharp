using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{
    public partial class PassaFase : Form
    {
        private MainForm mainForm;
        private LinguagemProgramacao boss;
        
        public PassaFase(MainForm form, LinguagemProgramacao boss)
        {
        	
            InitializeComponent();
            this.mainForm = form;  
            this.boss = boss;
            
            this.BackgroundImage = Image.FromFile("menu-vitoria.png");
		    this.BackgroundImageLayout = ImageLayout.Stretch;
		    this.FormBorderStyle = FormBorderStyle.None;
		    button1.FlatStyle = FlatStyle.Flat;
			button1.FlatAppearance.BorderSize = 0;

        }
        
        void Button1Click(object sender, EventArgs e)
        {
            if (mainForm != null)
            {
            	boss.Dispose();
                mainForm.ProximaFase();
                this.Close();
            }
        }
    }
}