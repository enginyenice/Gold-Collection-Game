using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class BPlayer : Player
    {
        public BPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght) : base(gold, name, cordY, cordX, cost, moveLenght)
        {
            
        }

        public override int[] SearchForGold(IMap map)
        {
            List<string> goldSquareList = map.GetGoldList();
            int minY = int.MaxValue, minX = int.MaxValue, goldEarned = int.MinValue, squareGold = int.MinValue;

            foreach (var item in goldSquareList)
            {
                string[] goldCordData = item.Split(',');
                int mesafe = Math.Abs(this.lastYCord - Int32.Parse(goldCordData[0])) + Math.Abs(this.lastXCord - Int32.Parse(goldCordData[1]));
                int lenght = mesafe / this.moveLenght;
                int totalCost = Int32.Parse(goldCordData[2]) - ((lenght+1) * this.cost);
                if (totalCost >goldEarned)
                {
                    goldEarned = totalCost;
                    minY = Int32.Parse(goldCordData[0]);
                    minX = Int32.Parse(goldCordData[1]);
                    squareGold = Int32.Parse(goldCordData[2]);
                }

            }


            int[] selectedGold = { minY, minX };
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi. Toplam tahmini Kazanç: "+goldEarned+"Altın Degeri: "+ squareGold);
            this.SetTargetedGold(minY, minX);
            return selectedGold;
        }
    }
}
