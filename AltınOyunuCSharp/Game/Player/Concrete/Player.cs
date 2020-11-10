using AltınOyunuCSharp.Game.Map.Abstract;
using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public abstract class Player : IPlayer
    {
        public int gold; // Oyuncunun sahip olduğu altın.
        public List<string> log; // Log kayıtları
        public int lastYCord,lastXCord; // O an bulunduğu kordinat
        public int[] targetedGold; // 0-> Y | 1->X
        public int targetGoldValue;
        public int remainingSteps; // Hedefe kalan adım sayısı
        public int cost; //Maliyet
        public int moveLenght; //Hareket uzunluğu


        public Player(int gold,string name,int cordY,int cordX,int cost,int moveLenght)
        {
            this.targetedGold = new int[2];
            this.SetTargetedGold(-1, -1);
            this.cost = cost;
            this.moveLenght = moveLenght;
            SetGold(gold);
            log = new List<string>();
            SetLog(name +" oyuncusu Y:"+(cordY)+", X:"+(cordX)+ " kordinatından "+ gold +" altın ile oyuna katıldı.");
            CordUpdate(cordY, cordX);
        }

        public void SetRemainingSteps(int remainingSteps)
        {
            this.remainingSteps = remainingSteps;
        }
        public void SetTargetedGold(int cordY,int cordX)
        {
            this.targetedGold[0] = cordY;
            this.targetedGold[1] = cordX;
        }

        public void CordUpdate(int yCord,int xCord)
        {
            this.lastYCord = yCord;
            this.lastXCord = xCord;
        }
        public int[] GetCord()
        {
            int[] cord = { this.lastYCord, this.lastXCord };
            return cord;
        }
        public int GetRemainingSteps()
        {
            return this.remainingSteps;
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

        public abstract int[] SearchForGold(IMap map);

        public void SetGold(int gold)
        {
            this.gold = gold;
        }

        public void SetLog(string log)
        {
            this.log.Add(log);
        }

        public int[] GetTargetedGold()
        {
            return this.targetedGold;
        }

        public int GetTargetGoldValue()
        {
            return this.targetGoldValue;
        }

        public void SetTargetGoldValue(int goldValue)
        {
            this.targetGoldValue = goldValue;
        }
    }
}
