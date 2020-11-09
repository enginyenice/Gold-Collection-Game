using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class Player : IPlayer
    {
        int gold;
        List<string> log;

        public Player(int gold,string name,int cordX,int cordY)
        {
            SetGold(gold);
            log = new List<string>();
            SetLog(name +" oyuncusu "+(cordX+1)+","+(cordY+1)+ " kordinatından "+ gold +" altın ile oyuna katıldı.");
            Console.WriteLine(name +" oyuncusu "+ (cordX+1) + "," + (cordY+1) + " kordinatından " + gold + " altın ile oyuna katıldı.");


        }
        public int GetGold()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLog()
        {
            return this.log;
        }

        public bool IsDeath()
        {
            if (GetGold() <= 0)
                return true;
            else
                return false;

        }

        public int[,] SearchForGold()
        {
            throw new NotImplementedException();
        }

        public void SetGold(int gold)
        {
            this.gold = gold;
        }

        public void SetLog(string log)
        {
            this.log.Add(log);
        }
    }
}
