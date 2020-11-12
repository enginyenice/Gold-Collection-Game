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
        public BPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
        }

        public override void SearchForGold(IMap map)
        {
            int minY = int.MaxValue, minX = int.MaxValue, goldEarned = int.MinValue, remainingSteps = int.MinValue, squareGold = Int32.MinValue, tempMesafe = Int32.MaxValue;




            int[,] goldArray = map.GetGoldMap();
            for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if (goldArray[goldY, goldX] != 0)
                    {
                        int mesafe = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                        double x;
                        x = ((double)mesafe / this.moveLenght);
                        x = Math.Ceiling(x);
                        int lenght = Convert.ToInt32(x);
                        int totalCost = goldArray[goldY, goldX] - (((lenght) * this.cost) + GetSearchCost());
                        if (totalCost >= goldEarned)
                        {
                            if (mesafe < tempMesafe && totalCost == goldEarned)
                            {
                                tempMesafe = mesafe;
                                remainingSteps = lenght;
                                goldEarned = totalCost;
                                minY = goldY;
                                minX = goldX;
                                squareGold = goldArray[goldY, goldX];
                            }
                            if (totalCost > goldEarned)
                            {
                                tempMesafe = mesafe;
                                remainingSteps = lenght;
                                goldEarned = totalCost;
                                minY = goldY;
                                minX = goldX;
                                squareGold = goldArray[goldY, goldX];
                            }
                        }
                    }
                }

            }
                this.SetRemainingSteps(remainingSteps);
            int[] selectedGold = { minY, minX };

            map.SetOyuncuHedefeKalanAdim(remainingSteps, "B");
            map.SetOyuncuHedefi(minY, minX, "B");
                this.SetTargetedGold(minY, minX);
            this.SetTargetGoldValue(squareGold);
            this.SetHedefeVardigindaAlacagiToplamPuan(goldEarned);
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi. Toplam tahmini Kazanç: " + GetHedefeVardigindaAlacagiToplamPuan() + "Altın Degeri: " + GetTargetGoldValue());
        }
    }
}
