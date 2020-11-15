using AltınOyunuCSharp.Game.Player.Concrete;
using System;
using System.Windows.Forms;

namespace AltınOyunuCSharp.UI
{
    public partial class ScoreBoard : Form
    {
        private APlayer aPlayer;
        private BPlayer bPlayer;
        private CPlayer cPlayer;
        private DPlayer dPlayer;

        public ScoreBoard(APlayer aPlayer, BPlayer bPlayer, CPlayer cPlayer, DPlayer dPlayer)
        {
            this.aPlayer = aPlayer;
            this.bPlayer = bPlayer;
            this.cPlayer = cPlayer;
            this.dPlayer = dPlayer;

            InitializeComponent();
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            label10.Text = aPlayer.GetTotalNumberOfSteps().ToString();
            label11.Text = bPlayer.GetTotalNumberOfSteps().ToString();
            label12.Text = cPlayer.GetTotalNumberOfSteps().ToString();
            label13.Text = dPlayer.GetTotalNumberOfSteps().ToString();

            label18.Text = aPlayer.GetTotalAmountOfGoldSpent().ToString();
            label19.Text = bPlayer.GetTotalAmountOfGoldSpent().ToString();
            label20.Text = cPlayer.GetTotalAmountOfGoldSpent().ToString();
            label21.Text = dPlayer.GetTotalAmountOfGoldSpent().ToString();

            label14.Text = aPlayer.GetTotalAmountOfGoldEarned().ToString();
            label15.Text = bPlayer.GetTotalAmountOfGoldEarned().ToString();
            label16.Text = cPlayer.GetTotalAmountOfGoldEarned().ToString();
            label17.Text = dPlayer.GetTotalAmountOfGoldEarned().ToString();

            label22.Text = aPlayer.GetPlayerGold().ToString();
            label23.Text = bPlayer.GetPlayerGold().ToString();
            label24.Text = cPlayer.GetPlayerGold().ToString();
            label25.Text = dPlayer.GetPlayerGold().ToString();
            ALog.DataSource = aPlayer.GetLog();
            BLog.DataSource = bPlayer.GetLog();
            CLog.DataSource = cPlayer.GetLog();
            DLog.DataSource = dPlayer.GetLog();

            aPlayer.WriteToFile();
            bPlayer.WriteToFile();
            cPlayer.WriteToFile();
            dPlayer.WriteToFile();
        }
    }
}