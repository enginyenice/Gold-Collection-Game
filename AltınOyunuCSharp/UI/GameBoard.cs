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
            GenerateButtonMap();

            aPlayer.SearchForGold(map);
            bPlayer.SearchForGold(map);
            cPlayer.SearchForGold(map);
            dPlayer.SearchForGold(map,aPlayer,bPlayer,cPlayer);
            //
            Console.WriteLine("Player hedef belirleme maliyeti");
            Console.Write(" A: " + aPlayer.GetSearchCost());
            Console.Write(" B: " + bPlayer.GetSearchCost());
            Console.Write(" C: " + cPlayer.GetSearchCost());
            Console.Write(" D: " + dPlayer.GetSearchCost()+"\n");

            Console.WriteLine("xxxxxxxxxxxxx");
            map.GetGoldList().ForEach(Console.WriteLine);

            
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
            
        }

        private void GenerateButtonMap()
        {
            int lockWidthHeight = 60;
            string[,] mapMatris = map.GetMatrisMap();
            Button[,] buttonMatrix = new Button[mapMatris.GetLength(0), mapMatris.GetLength(1)];
            for (int y = 0; y < mapMatris.GetLength(0); y++)
            {
                for (int x = 0; x < mapMatris.GetLength(1); x++)
                {
                    buttonMatrix[y, x] = new Button()
                    {
                        Width = lockWidthHeight,
                        Height = lockWidthHeight,
                        Text = mapMatris[y, x].ToString()+"["+y+","+x+"]",
                        Enabled = false,
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
    }
}
