using AltınOyunuCSharp.Game.Map.Abstract;
using System;

namespace AltınOyunuCSharp.Game.Player.Concrete.Players
{
    public class DPlayer : Player
    {
        public DPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
        }

        // D'nin diğer oyuncuların hedeflerine ulaşması için gereken tur sayısı
        public int GetStepsOfOtherPlayersTarget(int[] dPlayerCord, int[] otherPlayerCord)
        {
            int steps = Math.Abs(dPlayerCord[0] - otherPlayerCord[0]) + Math.Abs(dPlayerCord[1] - otherPlayerCord[1]);
            return Convert.ToInt32(Math.Ceiling((double)steps / this.moveLenght));
        }

        public override void SearchForGold(IMap map)
        {
            int nearestGoldY = int.MaxValue, nearestGoldX = int.MaxValue; // Hedeflenen en yakın altının koordinatları.
            int nearestGoldProfit = int.MinValue;       // Hedeflenen altından elde edilen kar.
            int remainingSteps = int.MinValue;          // Hedeflenen altına ulaşmak için gereken tur sayısı.
            int nearestGoldValue = Int32.MinValue;      // Hedeflenen altının değeri.
            int nearestGoldPathLength = Int32.MaxValue; // Hedeflenen altına giden yolun uzunluğu.
            String whoseTarget = String.Empty;          // D hangi oyuncunun hedefini seçti.
            int[] thisCord = this.GetLastCord();        // D oyuncusunun son konumu.

            //Oyuncuların hedeflerinin koordinatları
            int[] aPlayerTarget = map.GetPlayerTarget("A");
            int[] bPlayerTarget = map.GetPlayerTarget("B");
            int[] cPlayerTarget = map.GetPlayerTarget("C");

            //D'nin diğer oyuncuların hedeflerine ulaşması için gereken tur sayısı
            int remainingSteps_ATarget = GetStepsOfOtherPlayersTarget(thisCord, aPlayerTarget);
            int remainingSteps_BTarget = GetStepsOfOtherPlayersTarget(thisCord, bPlayerTarget);
            int remainingSteps_CTarget = GetStepsOfOtherPlayersTarget(thisCord, cPlayerTarget);

            if (remainingSteps_ATarget < map.GetPlayerRemainingSteps("A") && map.GetPlayerRemainingSteps("A") != -1)
            {// A'nın hedefini hedef belirleme.
                whoseTarget = "A";
                nearestGoldY = aPlayerTarget[0];
                nearestGoldX = aPlayerTarget[1];
                nearestGoldValue = map.GetGoldPointValue(aPlayerTarget[0], aPlayerTarget[1]);
                remainingSteps = remainingSteps_ATarget;
            }
            else if (remainingSteps_BTarget < map.GetPlayerRemainingSteps("B") && map.GetPlayerRemainingSteps("B") != -1)
            {// B'nın hedefini hedef belirleme.
                whoseTarget = "B";
                nearestGoldY = bPlayerTarget[0];
                nearestGoldX = bPlayerTarget[1];
                nearestGoldValue = map.GetGoldPointValue(bPlayerTarget[0], bPlayerTarget[1]);
                remainingSteps = remainingSteps_BTarget;
            }
            else if (remainingSteps_CTarget < map.GetPlayerRemainingSteps("C") && map.GetPlayerRemainingSteps("C") != -1)
            {// C'nın hedefini hedef belirleme.
                whoseTarget = "C";
                nearestGoldY = cPlayerTarget[0];
                nearestGoldX = cPlayerTarget[1];
                nearestGoldValue = map.GetGoldPointValue(cPlayerTarget[0], cPlayerTarget[1]);
                remainingSteps = remainingSteps_CTarget;
            }
            else
            {// D diğer oyuncuların hedefine ulaşamadığında kendine hedef belirleme
                int[,] goldArray = map.GetGoldMap();
                int[,] tempGoldArray;
                tempGoldArray = (int[,])goldArray.Clone();
                // Diğer oyuncuların hedeflerini matristen çıkar
                if (map.GetPlayerRemainingSteps("A") != -1)
                    tempGoldArray[aPlayerTarget[0], aPlayerTarget[1]] = 0;

                if (map.GetPlayerRemainingSteps("B") != -1)
                    tempGoldArray[bPlayerTarget[0], bPlayerTarget[1]] = 0;

                if (map.GetPlayerRemainingSteps("C") != -1)
                    tempGoldArray[cPlayerTarget[0], cPlayerTarget[1]] = 0;

                // eğer diğer oyuncuların hedefleri çıkarıldığında hedeflenecek başka altın
                //kalmıyor ise o altınları hedeflenebilir yap.
                int goldCount = 0;
                for (int i = 0; i < tempGoldArray.GetLength(0); i++)
                {
                    for (int j = 0; j < tempGoldArray.GetLength(0); j++)
                    {
                        if (tempGoldArray[i, j] != 0)
                            goldCount++;
                    }
                }
                if (goldCount == 0)
                {
                    tempGoldArray[aPlayerTarget[0], aPlayerTarget[1]] = map.GetGoldPointValue(aPlayerTarget[0], aPlayerTarget[1]);
                    tempGoldArray[bPlayerTarget[0], bPlayerTarget[1]] = map.GetGoldPointValue(bPlayerTarget[0], bPlayerTarget[1]);
                    tempGoldArray[cPlayerTarget[0], cPlayerTarget[1]] = map.GetGoldPointValue(cPlayerTarget[0], cPlayerTarget[1]);
                }
                for (int goldY = 0; goldY < tempGoldArray.GetLength(0); goldY++)
                {
                    for (int goldX = 0; goldX < tempGoldArray.GetLength(1); goldX++)
                    {
                        if (tempGoldArray[goldY, goldX] != 0)
                        {
                            //Geçici olarak altının kaç kare uzaklıkta olduğunu tutar.
                            int tempPathLength = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                            //Altına ulaşmak için gereken tur sayısı
                            double x = ((double)tempPathLength / this.moveLenght);
                            x = Math.Ceiling(x);
                            int tempRemainingSteps = Convert.ToInt32(x);
                            //Altından elde edilecek kar
                            int tempProfit = tempGoldArray[goldY, goldX] - (((tempRemainingSteps) * this.cost) + GetSearchCost());

                            if (tempProfit >= nearestGoldProfit)
                            {
                                if (tempPathLength < nearestGoldPathLength && tempProfit == nearestGoldProfit)
                                {
                                    nearestGoldPathLength = tempPathLength;
                                    remainingSteps = tempRemainingSteps;
                                    nearestGoldProfit = tempProfit;
                                    nearestGoldY = goldY;
                                    nearestGoldX = goldX;
                                    nearestGoldValue = tempGoldArray[goldY, goldX];
                                }
                                if (tempProfit > nearestGoldProfit)
                                {
                                    nearestGoldPathLength = tempPathLength;
                                    remainingSteps = tempRemainingSteps;
                                    nearestGoldProfit = tempProfit;
                                    nearestGoldY = goldY;
                                    nearestGoldX = goldX;
                                    nearestGoldValue = tempGoldArray[goldY, goldX];
                                }
                            }
                        }
                    }
                }
            }

            this.SetRemainingSteps(remainingSteps);
            this.SetTargetedGoldCord(nearestGoldY, nearestGoldX);
            this.SetTargetedGoldValue(nearestGoldValue);

            // Hedef belirleme maliyeti çıkartıldı.
            this.SetGoldEarnedOnReachTarget(nearestGoldValue - ((this.GetRemainingSteps() * this.cost) + this.GetSearchCost()));
            this.UpdatePlayerGoldValue((-1) * this.GetSearchCost());
            this.SetTotalAmountOfGoldSpent(this.GetSearchCost());

            if (whoseTarget != String.Empty)
            {
                this.SetLog(whoseTarget + " oyuncusunun hedefine ondan önce ulaşılabilir.");
                this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
                this.SetLog("Hedef " + whoseTarget + " Oyuncusunun hedefi olan: ");
                //this.SetLog("Y:" + nearestGoldY + " X:" + nearestGoldX + " olarak belirlendi.");
                this.SetLog("X:" + nearestGoldX + " Y:" + nearestGoldY + " olarak belirlendi.");
                this.SetLog("Tahmini Kazanç: " + GetGoldEarnedOnReachTarget() + " Altının Degeri: " + this.GetTargetedGoldValue());
            }
            else
            {
                this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
                //this.SetLog("Hedef: Y:" + nearestGoldY + " X:" + nearestGoldX + " olarak belirlendi.");
                this.SetLog("Hedef: X:" + nearestGoldX + " Y:" + nearestGoldY + " olarak belirlendi.");
                this.SetLog("Tahmini Kazanç: " + GetGoldEarnedOnReachTarget() + " Altının Degeri: " + this.GetTargetedGoldValue());
            }

            map.SetPlayerTarget(nearestGoldY, nearestGoldX, "D");
            map.SetPlayerRemainingSteps(remainingSteps, "D");
        }
    }
}