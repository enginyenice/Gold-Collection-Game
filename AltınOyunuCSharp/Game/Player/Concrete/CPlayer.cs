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
        int howManyGoldToShow; //Oyuncunun hamle başı kaç adet gizli altın açacağı

        public CPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght,int showGold, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
            this.howManyGoldToShow = showGold;
        }

        public override void SearchForGold(IMap map)
        {
            PrivateGoldShow(map); // Hedef belirlemeden önce belirlenen sayıda gizli altın açar.
            
            int nearestGoldY = int.MaxValue, nearestGoldX = int.MaxValue;// Hedeflenen en yakın altının koordinatları
            int nearestGoldProfit = int.MinValue;         // Hedeflenen altından elde edilen kar
            int remainingSteps = int.MinValue;            // Hedeflenen altına ulaşmak için gereken tur sayısı
            int nearestGoldValue = Int32.MinValue;        // Hedeflenen altının değeri
            int nearestGoldPathLength = Int32.MaxValue;   // Hedeflenen altına giden yolun uzunluğu
            int[,] goldArray = map.GetGoldMap();          // Altın matrisi 

            for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if (goldArray[goldY, goldX] > 0)
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
            this.SetGoldEarnedOnReachTarget(nearestGoldProfit);
            this.SetLog("Hedef: Y:" + nearestGoldY + " X:" + nearestGoldX + " olarak belirlendi. Toplam tahmini Kazanç: " + this.GetGoldEarnedOnReachTarget() + " Altın Degeri: " + nearestGoldValue);

            map.SetPlayerTarget(nearestGoldY, nearestGoldX, "C");
            map.SetPlayerRemainingSteps(remainingSteps, "C");
        }
        public void PrivateGoldShow(IMap map)
        {
            int control = 0;

            while (control < this.howManyGoldToShow)
            {
                int nearestPrivateGoldY = Int32.MaxValue, nearestPrivateGoldX = Int32.MaxValue;
                int nearestPrivateGoldPathLength = int.MaxValue;
                int nearestPrivateGoldValue = -1;

                if (map.GetPrivateGoldCount() > 0)
                {                
                    int[,] goldArray = map.GetPrivateGoldMap();

                    for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
                    {
                        for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                        {
                           if(goldArray[goldY,goldX] > 0)
                            {
                                int tempPathLength = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                                if (tempPathLength < nearestPrivateGoldPathLength)
                                {
                                    nearestPrivateGoldPathLength = tempPathLength;
                                    nearestPrivateGoldY = goldY;
                                    nearestPrivateGoldX = goldX;
                                    nearestPrivateGoldValue = goldArray[goldY, goldX];
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }

                map.UpdateGoldMapPoint(nearestPrivateGoldY, nearestPrivateGoldX, nearestPrivateGoldValue);
                map.RemovePrivateGoldPoint(nearestPrivateGoldY, nearestPrivateGoldX);
                this.SetLog("C Tarafından Y: " + nearestPrivateGoldY + " X:" + nearestPrivateGoldX + " kordinatındaki " + nearestPrivateGoldValue + " puanlık "+(control+1)+". altın açıldı");
                control++;
            }
 
        }
    }
}


  