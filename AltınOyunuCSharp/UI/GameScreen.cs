using AltınOyunuCSharp.Game.Player.Concrete;
using AltınOyunuCSharp.Game.Map.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltınOyunuCSharp.UI
{
    public partial class GameScreen : Form
    {
        Bitmap bitmapBoard, bitmap;
        Graphics graph;
        int squareEdge = 75;// oyun alanı kare kenarı, default: 75 pixel


        public Form menuForm;
        public Map map;
        public APlayer aPlayer;
        public BPlayer bPlayer;
        public CPlayer cPlayer;
        public DPlayer dPlayer;
        int[,] goldMatris;
        int[,] privateGoldMatris;
        int[,] aPlayerMatris;
        int[,] bPlayerMatris;
        int[,] cPlayerMatris;
        int[,] dPlayerMatris;

        public GameScreen(Map gameMap, APlayer a,BPlayer b, CPlayer c, DPlayer d, Form menuForm)
        {
            this.menuForm = menuForm;
            map = gameMap;
            aPlayer = a;
            bPlayer = b;
            cPlayer = c;
            dPlayer = d;
            goldMatris = map.GetGoldMap();
            privateGoldMatris = map.GetPrivateGoldMap();
            aPlayerMatris = aPlayer.GetPlayerMatris();
            bPlayerMatris = bPlayer.GetPlayerMatris();
            cPlayerMatris = cPlayer.GetPlayerMatris();
            dPlayerMatris = dPlayer.GetPlayerMatris();

            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        { 
            //Oyun Formunun ekrana sığdırılması
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(0, 0);
            
            //Karelerin kenar boyutlarının, oyun alanının genişlik ve yüksekliğine göre
            //ekrana sığabilecek max boyuta getirilmesi
            if (squareEdge * map.GetMatrisMap().GetLength(0) > gamePictureBox.Height)
                squareEdge = gamePictureBox.Height / map.GetMatrisMap().GetLength(0);
            if (squareEdge * map.GetMatrisMap().GetLength(1) > gamePictureBox.Width)
                squareEdge = gamePictureBox.Width / map.GetMatrisMap().GetLength(1);

            //Picturebox'ın oyun alanı boyutlarına getirilmesi
            gamePictureBox.Height = squareEdge * map.GetMatrisMap().GetLength(0);
            gamePictureBox.Width = squareEdge * map.GetMatrisMap().GetLength(1);

            //Picturebox'ın panel içerisinde ortalanması
            int panelx = (((gamePanel.Width - 20) - gamePictureBox.Width) / 2)+10;
            int panely = (((gamePanel.Height - 20) - gamePictureBox.Height) / 2)+10;
            gamePictureBox.Location = new Point(panelx,panely);
            graphicBoardSetup();
        }

        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuForm.Show();

        }

        public void graphicBoardSetup()
        {
            bitmapBoard = new Bitmap(gamePictureBox.Width,gamePictureBox.Height);
            graph = Graphics.FromImage(bitmapBoard);
            Color penColor = Color.FromArgb(100, 100, 100);
            Pen pen = new Pen(penColor,2.0F);
            for (int i = 0; i < map.GetMatrisMap().GetLength(0); i++)
            {
                for (int j = 0; j < map.GetMatrisMap().GetLength(1); j++)
                {
                    graph.DrawRectangle(pen, squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                }
            }
            graph.DrawRectangle(pen, 1, 1, squareEdge*map.GetMatrisMap().GetLength(1)-2,squareEdge* map.GetMatrisMap().GetLength(0)-2);
            gamePictureBox.Image = bitmapBoard;
        }

    }
}
