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

        public CPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght,int showGold, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
            this.showGold = showGold;
        }

        public override void SearchForGold(IMap map)
        {

            PrivateGoldShow(map);
            List<string> goldSquareList = map.GetGoldList();

            int minY = int.MaxValue, minX = int.MaxValue, goldEarned = int.MinValue, remainingSteps = int.MinValue, squareGold = Int32.MinValue, tempMesafe = Int32.MaxValue;
            int[,] goldArray = map.GetGoldMap();
            for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
            {
                for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                {
                    if (goldArray[goldY, goldX] > 0)
                    {
                        int mesafe = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                        double x;
                        x = ((double)mesafe / this.moveLenght);
                        x = Math.Ceiling(x);
                        int lenght = Convert.ToInt32(x);
                        int totalCost = goldArray[goldY, goldX] - ((lenght) * this.cost);
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
            map.SetOyuncuHedefeKalanAdim(remainingSteps, "C");
            int[] selectedGold = { minY, minX };
            this.SetLog("Hedef: Y:" + minY + " X:" + minX + " olarak belirlendi. Toplam tahmini Kazanç: " + goldEarned + "Altın Degeri: " + squareGold);
            map.SetOyuncuHedefi(minY, minX, "C");
            this.SetTargetedGold(minY, minX);
            this.SetTargetGoldValue(squareGold);
        }
        public void PrivateGoldShow(IMap map)
        {

            int control = 0;



            int privateGoldCount = 0;
            for(int y = 0; y < map.GetPrivateGoldMap().GetLength(0);y++)
            {
                for (int x = 0; x < map.GetPrivateGoldMap().GetLength(1); x++)
                {
                    if(map.GetPrivateGoldMap()[y,x] != 0)
                    {
                        privateGoldCount++;
                    }
                }
            }


            while (control < this.showGold)
            {

                int totalMin = int.MaxValue, minY = Int32.MaxValue, minX = Int32.MaxValue, gold = -1;
                if (privateGoldCount > 0)
                {
                    int[,] goldArray = map.GetPrivateGoldMap();
                    for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
                    {
                        for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                        {
                           if(goldArray[goldY,goldX] > 0)
                            {
                                int min = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                                if (min < totalMin)
                                {
                                    totalMin = min;
                                    minY = goldY;
                                    minX = goldX;
                                    gold = goldArray[goldY, goldX];
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }

                map.AddGold(minY, minX, gold);
                map.RemovePrivateGold(minY + "," + minX + ",G-" + gold);
                this.SetLog("C Tarafından Y: " + minY + " X:" + minX + " kordinatındaki " + gold + " puanlık altın açıldı");
                control++;
                privateGoldCount--;
            }





              
            }
        }
    }


  