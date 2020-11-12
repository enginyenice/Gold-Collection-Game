using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class APlayer : Player
    {
        public APlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
        }

        public override void SearchForGold(IMap map)
        {

            //TODO: Hedef alındı mı?

            int minY = int.MaxValue, minX = int.MaxValue,totalMin = int.MaxValue;

            int goldValue = Int32.MinValue;




            int[,] goldArray = map.GetGoldMap();

            for(int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if(goldArray[goldY,goldX] != 0)
                    {
                        int min = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord -  goldX);
                        if (min < totalMin)
                        {
                            totalMin = min;
                            minY = goldY;
                            minX = goldX;
                            goldValue = goldArray[goldY, goldX];

                        }
                    }

                }
            }

            double x;
            x = ((double)totalMin / this.moveLenght);
            x = Math.Ceiling(x);
            this.SetRemainingSteps(Convert.ToInt32(x));
            
            int[] selectedGold= { minY, minX };
            this.SetTargetedGold(minY, minX);
            this.SetTargetGoldValue(goldValue);
            this.SetHedefeVardigindaAlacagiToplamPuan(goldValue - ((GetRemainingSteps() * this.cost) + this.GetSearchCost()));
            
            
            map.SetOyuncuHedefi(minY, minX, "A");
            map.SetOyuncuHedefeKalanAdim(Convert.ToInt32(x), "A");
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi. Toplam tahmini Kazanç: " + GetHedefeVardigindaAlacagiToplamPuan() + " Altın Degeri: " + this.GetTargetGoldValue());
            
        }
    }
}
