using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class CPlayer : Player
    {
        int showGold; //Oyuncunun hamle başı kaç adet gizli altın açacağı
        public CPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int showGold) : base(gold, name, cordY, cordX, cost, moveLenght)
        {
            this.showGold = showGold;
        }

        public override int[] SearchForGold(IMap map)
        {

            PrivateGoldShow(map);
            List<string> goldSquareList = map.GetGoldList();
            int minY = int.MaxValue, minX = int.MaxValue, goldEarned = int.MinValue;

            foreach (var item in goldSquareList)
            {
                string[] goldCordData = item.Split(',');
                int mesafe = Math.Abs(this.lastYCord - Int32.Parse(goldCordData[0])) + Math.Abs(this.lastXCord - Int32.Parse(goldCordData[1]));
                int lenght = mesafe / this.moveLenght;
                int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
                if (totalCost > goldEarned)
                {
                    goldEarned = totalCost;
                    minY = Int32.Parse(goldCordData[0]);
                    minX = Int32.Parse(goldCordData[1]);
                }

            }

            int[] selectedGold = { minY, minX };
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi. Toplam tahmini Kazanç: " + goldEarned);
            this.SetTargetedGold(minY, minX);
            return selectedGold;
        }
        public void PrivateGoldShow(IMap map)
        {

            int control = 0;


            while (control < this.showGold)
            {
                int totalMin = int.MaxValue, minY = Int32.MaxValue, minX = Int32.MaxValue, gold = -1;
                List<string> privateGoldSquareList = map.GetPrivateGoldList();
                if (privateGoldSquareList.Count > 0)
                {
                    foreach (var item in privateGoldSquareList)
                    {
                        string[] goldCordData = item.Split(',');
                        int min = Math.Abs(this.lastYCord - Int32.Parse(goldCordData[0])) + Math.Abs(this.lastXCord - Int32.Parse(goldCordData[1]));
                        if (min < totalMin)
                        {
                            totalMin = min;
                            minY = Int32.Parse(goldCordData[0]);
                            minX = Int32.Parse(goldCordData[1]);
                            gold = Int32.Parse(goldCordData[2].Replace("G-", String.Empty));
                        }
                    }
                }
                else
                {
                    break;
                }
                map.AddGold(minY, minX, gold);
                map.RemovePrivateGold(minY+","+minX+",G-"+gold);
                this.SetLog("C Tarafından Y: " + minY + " X:" + minX + " kordinatındaki " + gold + " puanlık altın açıldı");
                control++;
            }
        }
    }
}
