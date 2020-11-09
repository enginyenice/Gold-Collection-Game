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

namespace AltınOyunuCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int m = 4;
            int n = 4;
            Map map = new Map(m,n);

            map.AddPlayer(0, 0, "A"); //Player A
            map.AddPlayer(0, (n-1), "B"); //Player B
            map.AddPlayer((m-1), 0, "C"); //Player C
            map.AddPlayer((m-1), (n-1), "D"); //Player D



            map.AddGold(20);
            map.AddPrivateGold(20);
            Console.WriteLine(map.GetMap());
            
        }
    }
}
