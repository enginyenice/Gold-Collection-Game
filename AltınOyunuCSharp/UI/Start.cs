using AltınOyunuCSharp.Game.Map.Concrete; // Map sınıfının bulunduğu adres
using AltınOyunuCSharp.Game.Player.Concrete.Players; // Oyuncuların sınıflarının bulunduğu adres
using AltınOyunuCSharp.UI;
using System;
using System.Windows.Forms;

namespace AltınOyunuCSharp
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        public Map map;
        public APlayer aPlayer;
        public BPlayer bPlayer;
        public CPlayer cPlayer;
        public DPlayer dPlayer;

        private void StartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            int cordX = Int32.Parse(CordXNum.Text);
            int cordY = Int32.Parse(CordYNum.Text);
            int costA = Int32.Parse(aCostNum.Text);
            int costB = Int32.Parse(bCostNum.Text);
            int costC = Int32.Parse(cCostNum.Text);
            int costD = Int32.Parse(dCostNum.Text);
            int targetCostA = Int32.Parse(aTargetCostNum.Text);
            int targetCostB = Int32.Parse(bTargetCostNum.Text);
            int targetCostC = Int32.Parse(cTargetCostNum.Text);
            int targetCostD = Int32.Parse(dTargetCostNum.Text);
            int moveLenght = Int32.Parse(MoveLenghtNum.Text);
            int goldRate = Int32.Parse(GoldNum.Text);
            int privateGoldRate = Int32.Parse(PrivateGoldNum.Text);
            int startGold = Int32.Parse(StartGoldNum.Text);
            int cGoldShow = Int32.Parse(cGoldShowNum.Text);

            //Map Oluşturma
            this.map = new Map(cordY, cordX);

            // Player Modelleri //
            this.aPlayer = new APlayer(startGold, "A", 0, 0, costA, moveLenght, targetCostA, cordY, cordX);
            this.bPlayer = new BPlayer(startGold, "B", 0, (cordX - 1), costB, moveLenght, targetCostB, cordY, cordX);
            this.cPlayer = new CPlayer(startGold, "C", (cordY - 1), 0, costC, moveLenght, cGoldShow, targetCostC, cordY, cordX);
            this.dPlayer = new DPlayer(startGold, "D", (cordY - 1), (cordX - 1), costD, moveLenght, targetCostD, cordY, cordX);

            // Map Player Yerleşimi
            this.map.AddPlayer(0, 0, "A"); //Player A
            this.map.AddPlayer(0, (cordX - 1), "B"); //Player B
            this.map.AddPlayer((cordY - 1), 0, "C"); //Player C
            this.map.AddPlayer((cordY - 1), (cordX - 1), "D"); //Player D

            //Map Altın Yerleşimi
            this.map.AddAllGold(goldRate, privateGoldRate);

            GameScreen game = new GameScreen(this.map, this.aPlayer, this.bPlayer, this.cPlayer, this.dPlayer, this);

            game.Show();
        }

        private void ExitGameBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Load(object sender, EventArgs e)
        {
        }
    }
}