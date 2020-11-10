using AltınOyunuCSharp.Game.Map.Concrete;
using AltınOyunuCSharp.Game.Player.Concrete;
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
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            int cordX = Int32.Parse(CordXTxT.Text);
            int cordY = Int32.Parse(CordXTxT.Text);
            int cost = Int32.Parse(CostTxT.Text);
            int moveLenght = Int32.Parse(MoveLenghtTxT.Text);
            int goldRate = Int32.Parse(GoldTxT.Text);
            int privateGoldRate = Int32.Parse(PrivateGoldTxT.Text);
            int startGold = Int32.Parse(StartGoldTxT.Text);
            int cGoldShow = Int32.Parse(cGoldShowTxT.Text);

            this.map = new Map(cordX, cordY);


            // Player Modelleri //
            this.aPlayer = new APlayer(startGold, "A", 0, 0, cost, moveLenght);
            this.bPlayer = new BPlayer(startGold, "B", 0, (cordX - 1), cost, moveLenght);
            this.cPlayer = new CPlayer(startGold, "C", (cordY - 1), 0, cost, moveLenght, cGoldShow);
            this.dPlayer = new DPlayer(startGold, "D", (cordY - 1), (cordX - 1), cost, moveLenght);


            // Map Player Yerleşimi
            this.map.AddPlayer(0, 0, "A"); //Player A
            this.map.AddPlayer(0, (cordX - 1), "B"); //Player B
            this.map.AddPlayer((cordY - 1), 0, "C"); //Player C
            this.map.AddPlayer((cordY - 1), (cordX - 1), "D"); //Player D

            //Map Altın Yerleşimi
            this.map.AddGold(goldRate, privateGoldRate);
            Console.WriteLine(this.map.GetMap());
            //Oyun Ekranının Açılması
            GameBoard gameBoard = new GameBoard(this.map, this.aPlayer, this.bPlayer, this.cPlayer, this.dPlayer);
            this.Hide();
            gameBoard.Show();
        }



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
        


    }
}
