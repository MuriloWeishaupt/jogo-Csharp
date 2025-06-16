
using System;
using System.Drawing;
using System.Windows.Forms;

namespace naveMania
{

	public partial class GameOverForm : Form
{
    private MainForm jogoAtual;

    public GameOverForm(MainForm jogo)
    {
        InitializeComponent();
        this.jogoAtual = jogo;
    }

    public static PictureBox fundo = new PictureBox();

    void GameOverFormLoad(object sender, EventArgs e)
    {
        fundo.Parent = this;
        fundo.Height = this.Height;
        fundo.Width = this.Width;
        fundo.Load("game_over.png");
        fundo.SizeMode = PictureBoxSizeMode.StretchImage;
        button1.FlatStyle = FlatStyle.Flat;
		button1.FlatAppearance.BorderSize = 0;
		button2.FlatStyle = FlatStyle.Flat;
		button2.FlatAppearance.BorderSize = 0;
		this.FormBorderStyle = FormBorderStyle.None;
    }

    void Button1Click(object sender, EventArgs e)
    {
        jogoAtual.Close(); 
        MainForm novoJogo = new MainForm();
        novoJogo.StartPosition = FormStartPosition.CenterScreen;
        novoJogo.Show();
        this.Close();
    }

    void Button2Click(object sender, EventArgs e)
    {
        jogoAtual.Close(); 
        MenuForm voltaMenu = new MenuForm();
        voltaMenu.StartPosition = FormStartPosition.CenterScreen;
        voltaMenu.Show();
        this.Close();
    }
}

}
