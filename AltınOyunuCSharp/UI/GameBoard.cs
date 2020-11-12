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


            Console.WriteLine(map.GetGoldMapString());
            Console.WriteLine(map.GetPrivateGoldMapString());


           

            
            // Tüm Logların Çıktısı //
            Console.WriteLine("A Player All Log");
            Console.WriteLine("-----------------------");
            aPlayer.GetLog().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------");

            Console.WriteLine("B Player All Log");
            Console.WriteLine("-----------------------");
            bPlayer.GetLog().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------");

            Console.WriteLine("C Player All Log");
            Console.WriteLine("-----------------------");
            cPlayer.GetLog().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------");

            Console.WriteLine("D Player All Log");
            Console.WriteLine("-----------------------");
            dPlayer.GetLog().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------------");
            // Tüm Logların Çıktısı //
            Console.WriteLine("Oyun Bitti");

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
                    ButtonText += (aPlayerMatris[y, x] != 0) ? "[A]" : "";
                    ButtonText += (bPlayerMatris[y, x] != 0) ? "[B]" : "";
                    ButtonText += (cPlayerMatris[y, x] != 0) ? "[C]" : "";
                    ButtonText += (dPlayerMatris[y, x] != 0) ? "[D]" : "";

                    ButtonText += (goldMatris[y, x] != 0) ? goldMatris[y, x].ToString() : "";
                    ButtonText += (privateGoldMatris[y, x] != 0) ? "[G-" + privateGoldMatris[y, x] + "]" : "";
                    buttonMatrix[y, x].Text = ButtonText;
                    


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
                    aPlayer.GetLog().ForEach(Console.WriteLine);
                    ButtonTextEdit();
                    map.SetGameOrder();
                    break;
                case 2:
                    bPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    bPlayerMatris = bPlayer.GetPlayerMatris();
                    bPlayer.GetLog().ForEach(Console.WriteLine);
                    ButtonTextEdit();
                    map.SetGameOrder();
                    break;
                case 3:
                    
                    cPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    cPlayerMatris = cPlayer.GetPlayerMatris();
                    cPlayer.GetLog().ForEach(Console.WriteLine);
                    ButtonTextEdit();
                    map.SetGameOrder();
                    break;
                case 4:

                    dPlayer.Move(map);
                    goldMatris = map.GetGoldMap();
                    privateGoldMatris = map.GetPrivateGoldMap();
                    dPlayerMatris = dPlayer.GetPlayerMatris();
                    ButtonTextEdit();
                    dPlayer.GetLog().ForEach(Console.WriteLine);
                    map.SetGameOrder();
                    
                    break;


            }
        }
    }
}
