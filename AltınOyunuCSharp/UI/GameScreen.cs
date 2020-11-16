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
        private Image[] goldImages;
        private Image[] hiddenGoldImages;
        private Image aPlayerImage;
        private Image bPlayerImage;
        private Image cPlayerImage;
        private Image dPlayerImage;
        private int squareEdge = 75; // Oyun alanı kare kenar uzunluğu, default: 75 pixel

        public Form menuForm;
        public Map map;
        public APlayer aPlayer;
        public BPlayer bPlayer;
        public CPlayer cPlayer;
        public DPlayer dPlayer;
        private bool hiddenActive = false;

        public GameScreen(Map gameMap, APlayer a, BPlayer b, CPlayer c, DPlayer d, Form menuForm)
        {
            this.menuForm = menuForm;
            map = gameMap;
            aPlayer = a;
            bPlayer = b;
            cPlayer = c;
            dPlayer = d;
            goldImages = new Image[4];
            hiddenGoldImages = new Image[4];

            goldImages[0] = global::AltınOyunuCSharp.Properties.Resources.coin5;
            goldImages[1] = global::AltınOyunuCSharp.Properties.Resources.coin10;
            goldImages[2] = global::AltınOyunuCSharp.Properties.Resources.coin15;
            goldImages[3] = global::AltınOyunuCSharp.Properties.Resources.coin20;
            hiddenGoldImages[0] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin5;
            hiddenGoldImages[1] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin10;
            hiddenGoldImages[2] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin15;
            hiddenGoldImages[3] = global::AltınOyunuCSharp.Properties.Resources.hiddenCoin20;
            aPlayerImage = global::AltınOyunuCSharp.Properties.Resources.playerA_front;
            bPlayerImage = global::AltınOyunuCSharp.Properties.Resources.playerB_front;
            cPlayerImage = global::AltınOyunuCSharp.Properties.Resources.playerC_front;
            dPlayerImage = global::AltınOyunuCSharp.Properties.Resources.playerD_front;           
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
                tm.Stop();
                MessageBox.Show(map.GetgameOverReason() + " Oyun bitti.");
                aPlayer.SetLog(map.GetgameOverReason());
                bPlayer.SetLog(map.GetgameOverReason());
                cPlayer.SetLog(map.GetgameOverReason());
                dPlayer.SetLog(map.GetgameOverReason());
                aPlayer.SetLog("Oyun Bitti");
                bPlayer.SetLog("Oyun Bitti");
                cPlayer.SetLog("Oyun Bitti");
                dPlayer.SetLog("Oyun Bitti");
                ScoreBoard scoreBoard = new ScoreBoard(aPlayer, bPlayer, cPlayer, dPlayer);
                scoreBoard.Show();
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
            for (int i = 0; i < mapy; i++)
            {
                for (int j = 0; j < mapx; j++)
                {
                    if (map.GetGoldPointValue(i, j) != 0)
                        graph.DrawImage(goldImages[(map.GetGoldPointValue(i,j) / 5) - 1], squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                }
            }
            graph.DrawImage(aPlayerImage, 0, 0, squareEdge, squareEdge);
            graph.DrawImage(bPlayerImage, squareEdge * (mapx - 1), 0, squareEdge, squareEdge);
            graph.DrawImage(cPlayerImage, 0, squareEdge * (mapy - 1), squareEdge, squareEdge);
            graph.DrawImage(dPlayerImage, squareEdge * (mapx - 1), squareEdge * (mapy - 1), squareEdge, squareEdge);
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
                    // Altın resimleri
                    if (map.GetGoldPointValue(i, j) != 0)
                        graph.DrawImage(goldImages[(map.GetGoldPointValue(i, j) / 5) - 1], squareEdge * j, squareEdge * i, squareEdge, squareEdge);
                    // Gizli altın resimleri (eğer gizli altınlar gösterilmek istenmiş ise)
                    else if (map.GetPrivateGoldPointValue(i, j) != 0 && hiddenActive == true)
                        graph.DrawImage(hiddenGoldImages[(map.GetPrivateGoldPointValue(i, j) / 5) - 1], squareEdge * j, squareEdge * i, squareEdge, squareEdge);

                    // Oyuncu resimleri
                    if (aPlayer.GetPlayerMatris()[i,j] != 0)
                        graph.DrawImage(aPlayerImage, j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                    
                    else if (bPlayer.GetPlayerMatris()[i, j] != 0)
                        graph.DrawImage(bPlayerImage, j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                   
                    else if (cPlayer.GetPlayerMatris()[i, j] != 0)
                        graph.DrawImage(cPlayerImage, j * squareEdge, i * squareEdge, squareEdge, squareEdge);
                    
                    else if (dPlayer.GetPlayerMatris()[i, j] != 0)
                        graph.DrawImage(dPlayerImage, j * squareEdge, i * squareEdge, squareEdge, squareEdge);
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
                tm.Start();
            }
            else
            {
                StartBtn.Text = "Oyunu başlat";
                tm.Stop();
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