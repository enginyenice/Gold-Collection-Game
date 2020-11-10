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
        public Map map;
        public APlayer aPlayer;
        public BPlayer bPlayer;
        public CPlayer cPlayer;
        public DPlayer dPlayer;
        
        
        public GameBoard(Map gameMap, APlayer a, BPlayer b, CPlayer c, DPlayer d)
        {
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
        }

        private void GenerateButtonMap()
        {
            int lockWidthHeight = 30;
            string[,] mapMatris = map.GetMatrisMap();
            Button[,] buttonMatrix = new Button[mapMatris.GetLength(0), mapMatris.GetLength(1)];
            for (int y = 0; y < mapMatris.GetLength(1); y++)
            {
                for (int x = 0; x < mapMatris.GetLength(1); x++)
                {
                    buttonMatrix[y, x] = new Button()
                    {
                        Width = Height = lockWidthHeight,
                        Text = mapMatris[y,x].ToString(),
                        Location = new Point(y * lockWidthHeight + 10,
                                              x * lockWidthHeight + 10),  // <-- You might want to tweak this
                        Parent = panel1,
                    };
                    /*
                    buttonMatrix[y, x].Tag = celNr++;
                    buttonMatrix[y, x].Click += MatrixButtonClick;
                    */
                }
            }
        }
    }
}
