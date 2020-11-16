using AltınOyunuCSharp.Game.Map.Abstract;
using System;

/* TODO:
 * []Hedefleme düştü ama hamle düşmedi. !!
   [x]B Hamle yaptığında hedeflenen altına ulaşamadığında altını sildi.
*/

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
            int nearestGoldY = int.MaxValue, nearestGoldX = int.MaxValue; // Hedeflenen en yakın altının koordinatları
            int nearestGoldDistance = int.MaxValue;  // Hedeflenen en yakın altının uzaklığı
            int nearestGoldValue = Int32.MinValue;  // Hedeflenen en yakın altının değeri
            int[,] goldArray = map.GetGoldMap();   // Altın matrisi

            for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if (goldArray[goldY, goldX] != 0)
                    {
                        int temp = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                        if (temp < nearestGoldDistance)
                        {
                            nearestGoldDistance = temp;
                            nearestGoldY = goldY;
                            nearestGoldX = goldX;
                            nearestGoldValue = goldArray[goldY, goldX];
                        }
                    }
                }
            }

            double x; //Oyuncunun altına ulaşmak için gitmesi gereken tur sayısı
            x = ((double)nearestGoldDistance / this.moveLenght);
            x = Math.Ceiling(x);

            this.SetRemainingSteps(Convert.ToInt32(x));
            this.SetTargetedGoldCord(nearestGoldY, nearestGoldX);
            this.SetTargetedGoldValue(nearestGoldValue);

            // Hedef belirleme maliyeti çıkartıldı.
            this.SetGoldEarnedOnReachTarget(nearestGoldValue - ((this.GetRemainingSteps() * this.cost) + this.GetSearchCost()));
            this.UpdatePlayerGoldValue((-1) * this.GetSearchCost());
            this.SetTotalAmountOfGoldSpent(this.GetSearchCost());

            this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
            this.SetLog("Hedef: X:" + nearestGoldY + " Y:" + nearestGoldX + " olarak belirlendi.");
            this.SetLog("Tahmini Kazanç: " + GetGoldEarnedOnReachTarget() + " Altının Degeri: " + this.GetTargetedGoldValue());

            map.SetPlayerTarget(nearestGoldY, nearestGoldX, "A");
            map.SetPlayerRemainingSteps(Convert.ToInt32(x), "A");
        }
    }
}