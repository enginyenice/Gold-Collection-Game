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
            Map map = new Map(4,4);
            
            map.AddGold(50);
            map.AddPrivateGold(50);
            Console.WriteLine(map.GetMap());
            
        }
    }
}
