using AltınOyunuCSharp.Game.Map.Abstract;
using System;

namespace AltınOyunuCSharp.Game.Player.Concrete.Players
{
    public class BPlayer : Player
    {
        public BPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
        }

        public override void SearchForGold(IMap map)
        {
            int nearestGoldY = int.MaxValue, nearestGoldX = int.MaxValue; // Hedeflenen en yakın altının koordinatları
            int nearestGoldProfit = int.MinValue;       // Hedeflenen altından elde edilen kar
            int remainingSteps = int.MinValue;          // Hedeflenen altına ulaşmak için gereken tur sayısı
            int nearestGoldValue = Int32.MinValue;      // Hedeflenen altının değeri
            int nearestGoldPathLength = Int32.MaxValue; // Hedeflenen altına giden yolun uzunluğu
            int[,] goldArray = map.GetGoldMap();        // Altın matrisi

            for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if (goldArray[goldY, goldX] != 0)
                    {
                        //Geçici olarak altının kaç kare uzaklıkta olduğunu tutar.
                        int tempPathLength = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                        //Altına ulaşmak için gereken tur sayısı
                        double x = ((double)tempPathLength / this.moveLenght);
                        x = Math.Ceiling(x);
                        int tempRemainingSteps = Convert.ToInt32(x);
                        //Altından elde edilecek kar
                        int tempProfit = goldArray[goldY, goldX] - (((tempRemainingSteps) * this.cost) + GetSearchCost());

                        if (tempProfit >= nearestGoldProfit)
                        {
                            if (tempPathLength < nearestGoldPathLength && tempProfit == nearestGoldProfit)
                            {
                                nearestGoldPathLength = tempPathLength;
                                remainingSteps = tempRemainingSteps;
                                nearestGoldProfit = tempProfit;
                                nearestGoldY = goldY;
                                nearestGoldX = goldX;
                                nearestGoldValue = goldArray[goldY, goldX];
                            }
                            if (tempProfit > nearestGoldProfit)
                            {
                                nearestGoldPathLength = tempPathLength;
                                remainingSteps = tempRemainingSteps;
                                nearestGoldProfit = tempProfit;
                                nearestGoldY = goldY;
                                nearestGoldX = goldX;
                                nearestGoldValue = goldArray[goldY, goldX];
                            }
                        }
                    }
                }
            }

            this.SetRemainingSteps(remainingSteps);
            this.SetTargetedGoldCord(nearestGoldY, nearestGoldX);
            this.SetTargetedGoldValue(nearestGoldValue);
            //this.SetGoldEarnedOnReachTarget(nearestGoldProfit);

            // Hedef belirleme maliyeti çıkartıldı.
            this.SetGoldEarnedOnReachTarget(nearestGoldValue - ((this.GetRemainingSteps() * this.cost) + this.GetSearchCost()));
            this.UpdatePlayerGoldValue((-1) * this.GetSearchCost());
            this.SetTotalAmountOfGoldSpent(this.GetSearchCost());

            this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
            this.SetLog("Hedef: X:" + nearestGoldY + " Y:" + nearestGoldX + " olarak belirlendi.");
            this.SetLog("Tahmini Kazanç: " + GetGoldEarnedOnReachTarget() + " Altının Degeri: " + this.GetTargetedGoldValue());

            map.SetPlayerTarget(nearestGoldY, nearestGoldX, "B");
            map.SetPlayerRemainingSteps(remainingSteps, "B");
        }
    }
}