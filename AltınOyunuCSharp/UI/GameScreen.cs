using AltınOyunuCSharp.Game.Map.Concrete;
using AltınOyunuCSharp.Game.Player.Concrete;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AltınOyunuCSharp.UI
{
    public partial class GameScreen : Form
    {
        private Bitmap bitmapBoard, bitmap;
        private Graphics graphBoard, graph;
        private Image[] goldImages = new Image[8];
        private int squareEdge = 75;// oyun alanı kare kenarı, default: 75 pixel
        private Image[] aPlayerImages = new Image[4];
        private Image[] bPlayerImages = new Image[4];
        private Image[] cPlayerImages = new Image[4];
        private Image[] dPlayerImages = new Image[4];

        public Form menuForm;
        public Map map;
        public APlayer aPlayer;
        public BPlayer bPlayer;
        public CPlayer cPlayer;
        public DPlayer dPlayer;
        private int[,] goldMatris;
        private int[,] privateGoldMatris;
        private int[,] aPlayerMatris;
        private int[,] bPlayerMatris;
        private int[,] cPlayerMatris;
        private int[,] dPlayerMatris;
        private bool hiddenActive = false;

        public GameScreen(Map gameMap, APlayer a, BPlayer b, CPlayer c, DPlayer d, Form menuForm)
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

            goldImages[0] = global::AltınOyunuCSharp.Properties.Resources.coin5;
            goldImages[1] = global::AltınOyunuCSharp.Properties.Resources.coin10;
            goldImages[2] = global::AltınOyunuCSharp.Properties.Resources.coin15;
            goldImages[3] = global::AltınOyunuCSharp.Properties.Resources.coin20;
            goldImages[4] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin5;
            goldImages[5] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin10;
            goldImages[6] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin15;
            goldImages[7] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin20;
            aPlayerImages[0] = global::AltınOyunuCSharp.Properties.Resources.playerA_front;
            aPlayerImages[1] = global::AltınOyunuCSharp.Properties.Resources.playerA_back;
            aPlayerImages[2] = global::AltınOyunuCSharp.Properties.Resources.playerA_left;
            aPlayerImages[3] = global::AltınOyunuCSharp.Properties.Resources.playerA_right;
            bPlayerImages[0] = global::AltınOyunuCSharp.Properties.Resources.playerB_front;
            bPlayerImages[1] = global::AltınOyunuCSharp.Properties.Resources.playerB_back;
            bPlayerImages[2] = global::AltınOyunuCSharp.Properties.Resources.playerB_left;
            bPlayerImages[3] = global::AltınOyunuCSharp.Properties.Resources.playerB_right;
            cPlayerImages[0] = global::AltınOyunuCSharp.Properties.Resources.playerC_front;
            cPlayerImages[1] = global::AltınOyunuCSharp.Properties.Resources.playerC_back;
            cPlayerImages[2] = global::AltınOyunuCSharp.Properties.Resources.playerC_left;
            cPlayerImages[3] = global::AltınOyunuCSharp.Properties.Resources.playerC_right;
            dPlayerImages[0] = global::AltınOyunuCSharp.Properties.Resources.playerD_front;
            dPlayerImages[1] = global::AltınOyunuCSharp.Properties.Resources.playerD_back;
            dPlayerImages[2] = global::AltınOyunuCSharp.Properties.Resources.playerD_left;
            dPlayerImages[3] = global::AltınOyunuCSharp.Properties.Resources.playerD_right;
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Oyun Formunun ekrana sığdırılması
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(0, 0);
            aPlayerKasa.Text = aPlayer.GetPlayerGold().ToString();
            bPlayerKasa.Text = bPlayer.GetPlayerGold().ToString();
            cPlayerKasa.Text = cPlayer.GetPlayerGold().ToString();
            dPlayerKasa.Text = dPlayer.GetPlayerGold().ToString();
            numericUpDown1.Value = tm.Interval;
            graphicBoardSetup();
        }

        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuForm.Show();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            switch (map.GetGameOrder())
            {
                case 1:
                    if (aPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        aPlayer.SetPlayerMapValue(aPlayer.GetLastCord()[0], aPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    aPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    aPlayerMatris = aPlayer.GetPlayerMatris();
                    aPlayerKasa.Text = aPlayer.GetPlayerGold().ToString();
                    if (aPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        aPlayer.SetPlayerMapValue(aPlayer.GetLastCord()[0], aPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    graphicDraw();
                    Console.WriteLine();
                    foreach (var item in aPlayer.GetLog())
                    {
                        Console.WriteLine(item);
                    }
                    map.SetGameOrder();
                    break;

                case 2:
                    if (bPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        bPlayer.SetPlayerMapValue(bPlayer.GetLastCord()[0], bPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    bPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    bPlayerMatris = bPlayer.GetPlayerMatris();
                    bPlayerKasa.Text = bPlayer.GetPlayerGold().ToString();
                    if (bPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        bPlayer.SetPlayerMapValue(bPlayer.GetLastCord()[0], bPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    graphicDraw();
                    Console.WriteLine();
                    foreach (var item in bPlayer.GetLog())
                    {
                        Console.WriteLine(item);
                    }
                    map.SetGameOrder();
                    break;

                case 3:
                    if (cPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        cPlayer.SetPlayerMapValue(cPlayer.GetLastCord()[0], cPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    cPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    cPlayerMatris = cPlayer.GetPlayerMatris();
                    cPlayerKasa.Text = cPlayer.GetPlayerGold().ToString();
                    if (cPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        cPlayer.SetPlayerMapValue(cPlayer.GetLastCord()[0], cPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    graphicDraw();
                    Console.WriteLine();
                    foreach (var item in cPlayer.GetLog())
                    {
                        Console.WriteLine(item);
                    }
                    map.SetGameOrder();
                    break;

                case 4:
                    if (dPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        dPlayer.SetPlayerMapValue(dPlayer.GetLastCord()[0], dPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    dPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    dPlayerMatris = dPlayer.GetPlayerMatris();
                    dPlayerKasa.Text = dPlayer.GetPlayerGold().ToString();
                    if (dPlayer.IsDeath() == true)
                    {
                        map.RemovePlayersIsDeath(map.GetGameOrder());
                        map.SetGameOrder();
                        dPlayer.SetPlayerMapValue(dPlayer.GetLastCord()[0], dPlayer.GetLastCord()[1], 0);
                        graphicDraw();
                        break;
                    }
                    graphicDraw();
                    Console.WriteLine();
                    foreach (var item in dPlayer.GetLog())
                    {
                        Console.WriteLine(item);
                    }
                    map.SetGameOrder();
                    break;

                default:
                    break;
            }

            if (map.GetgameOver() == true)
            {
                tm.Enabled = false;
                MessageBox.Show(map.GetgameOverReason() + " Oyun bitti.");
                aPlayer.SetLog("Oyun Bitti");
                bPlayer.SetLog("Oyun Bitti");
                cPlayer.SetLog("Oyun Bitti");
                dPlayer.SetLog("Oyun Bitti");
                ScoreBoard scoreBoard = new ScoreBoard(aPlayer, bPlayer, cPlayer, dPlayer);
                scoreBoard.ShowDialog();
            }
        }

        public void graphicBoardSetup()
        {
            int mapy = map.GetMap().GetLength(0);
            int mapx = map.GetMap().GetLength(1);
            //Karelerin kenar boyutlarının, oyun alanının genişlik ve yüksekliğine göre
            //ekrana sığabilecek max boyuta getirilmesi
            if (squareEdge * mapy > gamePictureBox.Height)
                squareEdge = gamePictureBox.Height / mapy;
            if (squareEdge * mapx > gamePictureBox.Width)
                squareEdge = gamePictureBox.Width / mapx;

            //Picturebox'ın oyun alanı boyutlarına getirilmesi
            gamePictureBox.Height = squareEdge * mapx;
            gamePictureBox.Width = squareEdge * mapx;

            //Picturebox'ın panel içerisinde ortalanması
            int panelx = (((gamePanel.Width - 20) - gamePictureBox.Width) / 2) + 10;
            int panely = (((gamePanel.Height - 20) - gamePictureBox.Height) / 2) + 10;
            gamePictureBox.Location = new Point(panelx, panely);

            //Oyun alanının oluşturulması ve çizdirilmesi
            bitmapBoard = new Bitmap(gamePictureBox.Width, gamePictureBox.Height);
            graphBoard = Graphics.FromImage(bitmapBoard);
            Color penColor = Color.FromArgb(100, 100, 100);
            Pen pen = new Pen(penColor, 2.0F);
            for (int i = 0; i < mapy; i++)
            {
                for (int j = 0; j < mapx; j++)
                {
                    graphBoard.DrawRectangle(pen, squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                }
            }
            graphBoard.DrawRectangle(pen, 1, 1, (squareEdge * mapx) - 2, (squareEdge * mapy) - 2);
            graphBoard.Dispose();

            // altın, player
            bitmap = new Bitmap(bitmapBoard);
            graph = Graphics.FromImage(bitmap);
            for (int i = 0; i < map.GetMap().GetLength(0); i++)
            {
                for (int j = 0; j < map.GetMap().GetLength(1); j++)
                {
                    if (goldMatris[i, j] != 0)
                        graph.DrawImage(goldImages[(goldMatris[i, j] / 5) - 1], squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                    else if (privateGoldMatris[i, j] != 0 && hiddenActive == true)
                        graph.DrawImage(goldImages[(privateGoldMatris[i, j] / 5) + 3], squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                }
            }
            graph.DrawImage(aPlayerImages[0], 0, 0, squareEdge, squareEdge);
            graph.DrawImage(bPlayerImages[0], squareEdge * (mapx - 1), 0, squareEdge, squareEdge);
            graph.DrawImage(cPlayerImages[0], 0, squareEdge * (mapy - 1), squareEdge, squareEdge);
            graph.DrawImage(dPlayerImages[0], squareEdge * (mapx - 1), squareEdge * (mapy - 1), squareEdge, squareEdge);
            gamePictureBox.Image = bitmap;
        }

        public void graphicDraw()
        {
            graph = Graphics.FromImage(bitmap);
            graph.Clear(Color.Transparent);
            graph.DrawImage(bitmapBoard, 0, 0);
            for (int i = 0; i < map.GetMap().GetLength(0); i++)
            {
                for (int j = 0; j < map.GetMap().GetLength(1); j++)
                {
                    if (goldMatris[i, j] != 0)
                        graph.DrawImage(goldImages[(goldMatris[i, j] / 5) - 1], squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                    else if (privateGoldMatris[i, j] != 0 && hiddenActive == true)
                        graph.DrawImage(goldImages[(privateGoldMatris[i, j] / 5) + 3], squareEdge * j, squareEdge * i, squareEdge, squareEdge);

                    if (aPlayerMatris[i, j] != 0)
                        graph.DrawImage(aPlayerImages[0], j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                    else if (bPlayerMatris[i, j] != 0)
                        graph.DrawImage(bPlayerImages[0], j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                    else if (cPlayerMatris[i, j] != 0)
                        graph.DrawImage(cPlayerImages[0], j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                    else if (dPlayerMatris[i, j] != 0)
                        graph.DrawImage(dPlayerImages[0], j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                }
            }
            gamePictureBox.Image = bitmap;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tm.Interval = Convert.ToInt32(numericUpDown1.Value);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (StartBtn.Text == "Oyunu başlat")
            {
                StartBtn.Text = "Oyunu durdur";
                tm.Enabled = true;
            }
            else
            {
                StartBtn.Text = "Oyunu başlat";
                tm.Enabled = false;
            }
        }

        private void HiddenGoldBtn_Click(object sender, EventArgs e)
        {
            if (hiddenActive == true)
            {
                hiddenActive = false;
                HiddenGoldBtn.Text = "Gizli altınları göster";
            }
            else
            {
                hiddenActive = true;
                HiddenGoldBtn.Text = "Gizli altınları gizle";
            }
            graphicDraw();
        }
    }
}