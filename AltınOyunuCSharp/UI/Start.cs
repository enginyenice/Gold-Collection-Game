using AltınOyunuCSharp.Game.Map.Concrete;
using AltınOyunuCSharp.Game.Player.Concrete;
using AltınOyunuCSharp.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            int cordX = Int32.Parse(CordXTxT.Text);
            int cordY = Int32.Parse(CordYTxT.Text);
            int costA = Int32.Parse(aCostTxT.Text);
            int costB = Int32.Parse(bCostTxT.Text);
            int costC = Int32.Parse(cCostTxT.Text);
            int costD = Int32.Parse(dCostTxT.Text);
            int targetCostA = Int32.Parse(aTargetCostTxT.Text);
            int targetCostB = Int32.Parse(bTargetCostTxT.Text);
            int targetCostC = Int32.Parse(cTargetCostTxT.Text);
            int targetCostD = Int32.Parse(dTargetCostTxT.Text);
            int moveLenght = Int32.Parse(MoveLenghtTxT.Text);
            int goldRate = Int32.Parse(GoldTxT.Text);
            int privateGoldRate = Int32.Parse(PrivateGoldTxT.Text);
            int startGold = Int32.Parse(StartGoldTxT.Text);
            int cGoldShow = Int32.Parse(cGoldShowTxT.Text);

            //Map Oluşturma
            this.map = new Map(cordY, cordX);

            // Player Modelleri //
            this.aPlayer = new APlayer(startGold, "A", 0, 0, costA, moveLenght, targetCostA,cordY,cordX);
            this.bPlayer = new BPlayer(startGold, "B", 0, (cordX - 1), costB, moveLenght, targetCostB, cordY, cordX);
            this.cPlayer = new CPlayer(startGold, "C", (cordY - 1), 0, costC, moveLenght, cGoldShow, targetCostC,cordY,cordX);
            this.dPlayer = new DPlayer(startGold, "D", (cordY - 1), (cordX - 1), costD, moveLenght, targetCostD,cordY,cordX);

            // Map Player Yerleşimi
            this.map.AddPlayer(0, 0, "A"); //Player A
            this.map.AddPlayer(0, (cordX - 1), "B"); //Player B
            this.map.AddPlayer((cordY - 1), 0, "C"); //Player C
            this.map.AddPlayer((cordY - 1), (cordX - 1), "D"); //Player D

            //Map Altın Yerleşimi
            this.map.AddAllGold(goldRate, privateGoldRate);

            //Oyun Ekranının Açılması
            GameBoard gameBoard = new GameBoard(this.map, this.aPlayer, this.bPlayer, this.cPlayer, this.dPlayer,this);
            this.Hide();
            gameBoard.Show();
        }
        private void StartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            int cordX = Int32.Parse(CordXTxT.Text);
            int cordY = Int32.Parse(CordYTxT.Text);
            int costA = Int32.Parse(aCostTxT.Text);
            int costB = Int32.Parse(bCostTxT.Text);
            int costC = Int32.Parse(cCostTxT.Text);
            int costD = Int32.Parse(dCostTxT.Text);
            int targetCostA = Int32.Parse(aTargetCostTxT.Text);
            int targetCostB = Int32.Parse(bTargetCostTxT.Text);
            int targetCostC = Int32.Parse(cTargetCostTxT.Text);
            int targetCostD = Int32.Parse(dTargetCostTxT.Text);
            int moveLenght = Int32.Parse(MoveLenghtTxT.Text);
            int goldRate = Int32.Parse(GoldTxT.Text);
            int privateGoldRate = Int32.Parse(PrivateGoldTxT.Text);
            int startGold = Int32.Parse(StartGoldTxT.Text);
            int cGoldShow = Int32.Parse(cGoldShowTxT.Text);

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

        //textbox char kontrol

        private void CordXTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CordYTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void GoldTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PrivateGoldTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StartGoldTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MoveLenghtTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void cGoldShowTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void aCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void aTargetCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bTargetCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cTargetCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dTargetCostTxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
}
