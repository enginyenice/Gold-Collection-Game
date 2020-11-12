using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public class DPlayer : Player
    {
        public DPlayer(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX) : base(gold, name, cordY, cordX, cost, moveLenght, searchCost, gameY, gameX)
        {
        }

        public int[] SearchForGold(IMap map,APlayer aPlayer,BPlayer bPlayer,CPlayer cPlayer)
        {
            int[] selectedGold = new int[2];
            int[] thisCord = this.GetCord();
            int goldEarned = Int32.MinValue;
            int squareGold = int.MinValue;

            int[] aGetTarget = aPlayer.GetTargetedGold();
            int[] bGetTarget = bPlayer.GetTargetedGold();
            int[] cGetTarget = cPlayer.GetTargetedGold();

            int compareAD = Math.Abs(thisCord[0] - aGetTarget[0]) + Math.Abs(thisCord[1] - aGetTarget[1]);
            int compareBD = Math.Abs(thisCord[0] - bGetTarget[0]) + Math.Abs(thisCord[1] - bGetTarget[1]);
            int compareCD = Math.Abs(thisCord[0] - cGetTarget[0]) + Math.Abs(thisCord[1] - cGetTarget[1]);

            double x;
            x = ((double)compareAD / this.moveLenght);
            x = Math.Ceiling(x);
            compareAD = Convert.ToInt32(x);

            x = ((double)compareBD / this.moveLenght);
            x = Math.Ceiling(x);
            compareBD = Convert.ToInt32(x);

            x = ((double)compareCD / this.moveLenght);
            x = Math.Ceiling(x);
            compareCD = Convert.ToInt32(x);
            

            if(compareAD < aPlayer.GetRemainingSteps())
            {
                // A'nın hedefine git
                this.SetTargetedGold(aGetTarget[0], aGetTarget[1]);
                this.SetRemainingSteps(compareAD);
                selectedGold[0] = aGetTarget[0];
                selectedGold[1] = aGetTarget[1];
                goldEarned = (aPlayer.GetTargetGoldValue()) - (compareAD * this.cost);

                    //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);


            }
            else if(compareBD < bPlayer.GetRemainingSteps())
            {
                // B'nin hedefine git
                this.SetTargetedGold(bGetTarget[0], bGetTarget[1]);
                this.SetRemainingSteps(compareBD);
                selectedGold[0] = bGetTarget[0];
                selectedGold[1] = bGetTarget[1];
                goldEarned = (bPlayer.GetTargetGoldValue()) - (compareBD * this.cost);
            } else if(compareCD < cPlayer.GetRemainingSteps())
            {
                // C'nin hedefine git
                this.SetTargetedGold(cGetTarget[0], cGetTarget[1]);
                this.SetRemainingSteps(compareCD);
                selectedGold[0] = cGetTarget[0];
                selectedGold[1] = cGetTarget[1];
                goldEarned = (cPlayer.GetTargetGoldValue()) - (compareCD * this.cost);
            } else
            {
                List<string> goldSquareList = map.GetGoldList();
                List<string> goldSquareListTemp = new List<string>();
                goldSquareListTemp = goldSquareList;
                if (goldSquareList.Count > 3)
                {
                    goldSquareListTemp = goldSquareList;
                    goldSquareListTemp.Remove(aGetTarget[0] + "," + aGetTarget[1] + "," + aPlayer.GetTargetGoldValue());
                    goldSquareListTemp.Remove(bGetTarget[0] + "," + bGetTarget[1] + "," + bPlayer.GetTargetGoldValue());
                    goldSquareListTemp.Remove(cGetTarget[0] + "," + cGetTarget[1] + "," + cPlayer.GetTargetGoldValue());
                }




                  //  int minY = int.MaxValue, minX = int.MaxValue, remainingSteps = int.MinValue, tempMesafe = Int32.MaxValue;

                int minY = int.MaxValue, minX = int.MaxValue, remainingSteps = int.MinValue, tempMesafe = Int32.MaxValue;

                foreach (var item in goldSquareList)
                {
                    string[] goldCordData = item.Split(',');
                    int mesafe = Math.Abs(this.lastYCord - Int32.Parse(goldCordData[0])) + Math.Abs(this.lastXCord - Int32.Parse(goldCordData[1]));

                    x = ((double)mesafe / this.moveLenght);
                    x = Math.Ceiling(x);
                    int lenght = Convert.ToInt32(x);
                    int totalCost = Int32.Parse(goldCordData[2]) - ((lenght) * this.cost);
                    if (totalCost >= goldEarned)
                    {
                        if (mesafe < tempMesafe && totalCost == goldEarned)
                        {
                            tempMesafe = mesafe;
                            remainingSteps = lenght;
                            goldEarned = totalCost;
                            minY = Int32.Parse(goldCordData[0]);
                            minX = Int32.Parse(goldCordData[1]);
                            squareGold = Int32.Parse(goldCordData[2]);
                        }
                        if (totalCost > goldEarned)
                        {
                            tempMesafe = mesafe;
                            remainingSteps = lenght;
                            goldEarned = totalCost;
                            minY = Int32.Parse(goldCordData[0]);
                            minX = Int32.Parse(goldCordData[1]);
                            squareGold = Int32.Parse(goldCordData[2]);
                        }
                    }

                }
                this.SetRemainingSteps(remainingSteps);
                selectedGold[0] = minY;
                selectedGold[1] = minX;
                this.SetTargetedGold(minY, minX);
                this.SetTargetGoldValue(squareGold);
            }


            squareGold = this.GetTargetGoldValue();
            this.SetLog("Hedef: Y:" + selectedGold[0] + " X:" + selectedGold[1] + " olarak belirlendi. Toplam tahmini Kazanç: " + goldEarned + "Altın Degeri: " + squareGold);
            
            return selectedGold;
        }

        public override void SearchForGold(IMap map)
        {

            int[] selectedGold = new int[2];
            int[] thisCord = this.GetCord();
            int goldEarned = Int32.MinValue;
            int squareGold = int.MinValue;
            
            
            int[] aGetTarget = map.GetOyuncuHedef("A");
            int[] bGetTarget = map.GetOyuncuHedef("B");
            int[] cGetTarget = map.GetOyuncuHedef("C");
            int compareAD = Math.Abs(thisCord[0] - aGetTarget[0]) + Math.Abs(thisCord[1] - aGetTarget[1]);
            int compareBD = Math.Abs(thisCord[0] - bGetTarget[0]) + Math.Abs(thisCord[1] - bGetTarget[1]);
            int compareCD = Math.Abs(thisCord[0] - cGetTarget[0]) + Math.Abs(thisCord[1] - cGetTarget[1]);

            double x;
            x = ((double)compareAD / this.moveLenght);
            x = Math.Ceiling(x);
            compareAD = Convert.ToInt32(x);

            x = ((double)compareBD / this.moveLenght);
            x = Math.Ceiling(x);
            compareBD = Convert.ToInt32(x);

            x = ((double)compareCD / this.moveLenght);
            x = Math.Ceiling(x);
            compareCD = Convert.ToInt32(x);

            if (compareAD < map.GetOyuncuHedefeKalanAdim("A") && map.GetOyuncuHedefeKalanAdim("A") != -1)
            {
                // A'nın hedefine git
                this.SetTargetedGold(aGetTarget[0], aGetTarget[1]);
                this.SetRemainingSteps(compareAD);
                selectedGold[0] = aGetTarget[0];
                selectedGold[1] = aGetTarget[1];
                goldEarned = (map.GetGoldPoint(aGetTarget[0], aGetTarget[1]) - (compareAD * this.cost));
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
            }
            else if (compareBD < map.GetOyuncuHedefeKalanAdim("B") && map.GetOyuncuHedefeKalanAdim("B") != -1)
            {
                // B'nın hedefine git
                this.SetTargetedGold(bGetTarget[0], bGetTarget[1]);
                this.SetRemainingSteps(compareBD);
                selectedGold[0] = bGetTarget[0];
                selectedGold[1] = bGetTarget[1];
                goldEarned = (map.GetGoldPoint(bGetTarget[0], bGetTarget[1]) - (compareBD * this.cost));
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
            }
            else if (compareCD < map.GetOyuncuHedefeKalanAdim("C") && map.GetOyuncuHedefeKalanAdim("C") != -1)
            {
                // C'nın hedefine git
                this.SetTargetedGold(cGetTarget[0], cGetTarget[1]);
                this.SetRemainingSteps(compareCD);
                selectedGold[0] = cGetTarget[0];
                selectedGold[1] = cGetTarget[1];
                goldEarned = (map.GetGoldPoint(cGetTarget[0], cGetTarget[1]) - (compareCD * this.cost));
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
            } else
            {
                int[,] goldArray = map.GetGoldMap();
                if (map.GetGoldCount() > 3)
                {
                    if (map.GetOyuncuHedefeKalanAdim("A") != -1)
                        goldArray[aGetTarget[0], aGetTarget[1]] = 0;
                    if (map.GetOyuncuHedefeKalanAdim("B") != -1)
                        goldArray[bGetTarget[0], bGetTarget[1]] = 0;
                    if (map.GetOyuncuHedefeKalanAdim("C") != -1)
                        goldArray[cGetTarget[0], cGetTarget[1]] = 0;
                }
                int minY = int.MaxValue, minX = int.MaxValue, remainingSteps = int.MinValue, tempMesafe = Int32.MaxValue;

                for (int goldY = 0; goldY < goldArray.GetLength(0); goldY++)
                {
                    for (int goldX = 0; goldX < goldArray.GetLength(1); goldX++)
                    {
                        if (goldArray[goldY, goldX] > 0)
                        {
                            int mesafe = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
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
                map.SetOyuncuHedefeKalanAdim(remainingSteps, "D");
                selectedGold[0] = minY;
                selectedGold[1] = minX;
                this.SetTargetedGold(minY, minX);
                map.SetOyuncuHedefi(minY, minX, "D");
                this.SetTargetGoldValue(squareGold);
            }


            squareGold = this.GetTargetGoldValue();
            this.SetLog("Hedef: Y:" + selectedGold[0] + " X:" + selectedGold[1] + " olarak belirlendi. Toplam tahmini Kazanç: " + goldEarned + "Altın Degeri: " + squareGold);





        }
    }
}
