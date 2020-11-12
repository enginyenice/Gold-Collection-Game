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
    public partial class GameBoard : Form
    {  
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
        
        Button[,] buttonMatrix;
        public GameBoard(Map gameMap, APlayer a, BPlayer b, CPlayer c, DPlayer d,Form menuForm)
        {
            this.menuForm = menuForm;
            map = gameMap;
            aPlayer = a;
            bPlayer = b;
            cPlayer = c;
            dPlayer = d;
            
            InitializeComponent();
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            goldMatris = map.GetGoldMap();
            privateGoldMatris = map.GetPrivateGoldMap();
            aPlayerMatris = aPlayer.GetPlayerMatris();
            bPlayerMatris = bPlayer.GetPlayerMatris();
            cPlayerMatris = cPlayer.GetPlayerMatris();
            dPlayerMatris = dPlayer.GetPlayerMatris();
            buttonMatrix = new Button[goldMatris.GetLength(0), goldMatris.GetLength(1)];
            GenerateButtonMap();
            ButtonTextEdit();

            label1.Text = "A'nın Altını: " + aPlayer.GetPlayerGoldValue();
            label2.Text = "B'nın Altını: " + bPlayer.GetPlayerGoldValue();
            label3.Text = "C'nın Altını: " + cPlayer.GetPlayerGoldValue();
            label4.Text = "D'nın Altını: " + dPlayer.GetPlayerGoldValue();

        }


        private void GenerateButtonMap()
        {
            int lockWidthHeight = 100;

            for (int y = 0; y < buttonMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < buttonMatrix.GetLength(1); x++)
                {
                    buttonMatrix[y, x] = new Button()
                    {
                        Width = lockWidthHeight,
                        Height = lockWidthHeight,
                        Text = "",
                        
                        Location = new Point(x * lockWidthHeight + 10, y * lockWidthHeight + 10),  // x,y şeklinde 
                        Parent = panel1,
                    };
                    /*
                    buttonMatrix[y, x].Tag = celNr++;
                    buttonMatrix[y, x].Click += MatrixButtonClick;
                    */
                }
            }
        }

        private void GameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuForm.Show();
        }

        public void ButtonTextEdit()
        {
            for(int y = 0; y < goldMatris.GetLength(0); y++)
            {
                for (int x = 0; x < goldMatris.GetLength(1); x++)
                {
                    string ButtonText = "";
                    ButtonText += "["+y+","+x+"]->";
                    ButtonText += (aPlayerMatris[y, x] != 0) ? "[A]" : "";
                    ButtonText += (bPlayerMatris[y, x] != 0) ? "[B]" : "";
                    ButtonText += (cPlayerMatris[y, x] != 0) ? "[C]" : "";
                    ButtonText += (dPlayerMatris[y, x] != 0) ? "[D]" : "";

                    ButtonText += (goldMatris[y, x] != 0) ? goldMatris[y, x].ToString() : "";
                    ButtonText += (privateGoldMatris[y, x] != 0) ? "[G-" + privateGoldMatris[y, x] + "]" : "";
                    buttonMatrix[y, x].Text = ButtonText;
                    
                    if(goldMatris[y,x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Green;
                    } else if (privateGoldMatris[y, x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Pink;
                    }
                    else if (aPlayerMatris[y, x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Orange;
                    }
                    else if (bPlayerMatris[y, x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Purple;
                    }
                    else if (cPlayerMatris[y, x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Aqua;
                    }
                    else if (dPlayerMatris[y, x] != 0)
                    {
                        buttonMatrix[y, x].BackColor = Color.Yellow;
                    }
                    else
                    {
                        buttonMatrix[y, x].BackColor = Color.White;
                    }



                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (map.GetGameOrder())
            {
                case 1:
                    aPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    aPlayerMatris = aPlayer.GetPlayerMatris();

                    label1.Text = "A'nın Altını: " + aPlayer.GetPlayerGoldValue();
                    listBox1.Items.Clear();
                    foreach (var item in aPlayer.GetLog())
                    {
                        listBox1.Items.Add(item);
                    }








                    ButtonTextEdit();
                    map.SetGameOrder();
                    break;
                case 2:
                    bPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    bPlayerMatris = bPlayer.GetPlayerMatris();
                   // bPlayer.GetLog().ForEach(Console.WriteLine);
                    ButtonTextEdit();
                    label2.Text = "B'nın Altını: " + bPlayer.GetPlayerGoldValue();
                    listBox2.Items.Clear();
                    foreach (var item in bPlayer.GetLog())
                    {
                        listBox2.Items.Add(item);
                    }


                    map.SetGameOrder();
                    break;
                case 3:
                    
                    cPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    cPlayerMatris = cPlayer.GetPlayerMatris();
                    ButtonTextEdit();
                    label3.Text = "C'nın Altını: " + cPlayer.GetPlayerGoldValue();
                    listBox3.Items.Clear();
                    foreach (var item in cPlayer.GetLog())
                    {
                        listBox3.Items.Add(item);
                    }


                    map.SetGameOrder();
                    break;
                case 4:

                    dPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    dPlayerMatris = dPlayer.GetPlayerMatris();
                    ButtonTextEdit();
                    label4.Text = "D'nın Altını: " + dPlayer.GetPlayerGoldValue();
                    listBox4.Items.Clear();
                    foreach (var item in dPlayer.GetLog())
                    {
                        listBox4.Items.Add(item);
                    }


                    map.SetGameOrder();
                    
                    break;


            }
        }
    }
}
