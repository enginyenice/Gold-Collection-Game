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
                
                goldEarned = (map.GetGoldPoint(aGetTarget[0], aGetTarget[1]) - ((compareAD * this.cost)+ GetSearchCost()));
                this.SetHedefeVardigindaAlacagiToplamPuan(goldEarned);
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
                map.SetOyuncuHedefi(aGetTarget[0], aGetTarget[1], "D");
                this.SetTargetGoldValue(map.GetGoldPoint(aGetTarget[0], aGetTarget[1]));
                map.SetOyuncuHedefeKalanAdim(compareAD, "D");

            }
            else if (compareBD < map.GetOyuncuHedefeKalanAdim("B") && map.GetOyuncuHedefeKalanAdim("B") != -1)
            {
                // B'nın hedefine git
                this.SetTargetedGold(bGetTarget[0], bGetTarget[1]);
                this.SetRemainingSteps(compareBD);
                selectedGold[0] = bGetTarget[0];
                selectedGold[1] = bGetTarget[1];
                goldEarned = (map.GetGoldPoint(bGetTarget[0], bGetTarget[1]) - ((compareBD * this.cost) + GetSearchCost()));
                this.SetHedefeVardigindaAlacagiToplamPuan(goldEarned);
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
                map.SetOyuncuHedefi(bGetTarget[0], bGetTarget[1], "D");
                this.SetTargetGoldValue(map.GetGoldPoint(bGetTarget[0], bGetTarget[1]));
                map.SetOyuncuHedefeKalanAdim(compareBD, "D");
            }
            else if (compareCD < map.GetOyuncuHedefeKalanAdim("C") && map.GetOyuncuHedefeKalanAdim("C") != -1)
            {
                // C'nın hedefine git
                this.SetTargetedGold(cGetTarget[0], cGetTarget[1]);
                this.SetRemainingSteps(compareCD);
                selectedGold[0] = cGetTarget[0];
                selectedGold[1] = cGetTarget[1];
                goldEarned = (map.GetGoldPoint(cGetTarget[0], cGetTarget[1]) - ((compareCD * this.cost) + GetSearchCost()));
                this.SetHedefeVardigindaAlacagiToplamPuan(goldEarned);
                //int totalCost = Int32.Parse(goldCordData[2]) - ((lenght + 1) * this.cost);
                map.SetOyuncuHedefi(cGetTarget[0], cGetTarget[1], "D");
                this.SetTargetGoldValue(map.GetGoldPoint(cGetTarget[0], cGetTarget[1]));
                map.SetOyuncuHedefeKalanAdim(compareCD, "D");
            } 
            else{
                int[,] goldArray = map.GetGoldMap();
                int[,] tempGoldArray;
                tempGoldArray = (int[,])goldArray.Clone();
                if (map.GetGoldCount() > 3)
                {
                    if (map.GetOyuncuHedefeKalanAdim("A") != -1)
                        tempGoldArray[aGetTarget[0], aGetTarget[1]] = 0;

                    if (map.GetOyuncuHedefeKalanAdim("B") != -1)
                        tempGoldArray[bGetTarget[0], bGetTarget[1]] = 0;

                    if (map.GetOyuncuHedefeKalanAdim("C") != -1)
                        tempGoldArray[cGetTarget[0], cGetTarget[1]] = 0;

                }
                int minY = int.MaxValue, minX = int.MaxValue, remainingSteps = int.MinValue, tempMesafe = Int32.MaxValue;

                for (int goldY = 0; goldY < tempGoldArray.GetLength(0); goldY++)
                {
                    for (int goldX = 0; goldX < tempGoldArray.GetLength(1); goldX++)
                    {
                        if (tempGoldArray[goldY, goldX] > 0)
                        {
                            int mesafe = Math.Abs(this.lastYCord - goldY) + Math.Abs(this.lastXCord - goldX);
                            x = ((double)mesafe / this.moveLenght);
                            x = Math.Ceiling(x);
                            int lenght = Convert.ToInt32(x);
                            int totalCost = tempGoldArray[goldY, goldX] - (((lenght) * this.cost) + GetSearchCost());
                            if (totalCost >= goldEarned)
                            {
                                if (mesafe < tempMesafe && totalCost == goldEarned)
                                {
                                    tempMesafe = mesafe;
                                    remainingSteps = lenght;
                                    goldEarned = totalCost;
                                    minY = goldY;
                                    minX = goldX;
                                    squareGold = tempGoldArray[goldY, goldX];
                                }
                                if (totalCost > goldEarned)
                                {
                                    tempMesafe = mesafe;
                                    remainingSteps = lenght;
                                    goldEarned = totalCost;
                                    minY = goldY;
                                    minX = goldX;
                                    squareGold = tempGoldArray[goldY, goldX];
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

                this.SetHedefeVardigindaAlacagiToplamPuan(goldEarned);
                

            }



            squareGold = this.GetTargetGoldValue();
            this.SetLog("Hedef: Y:" + selectedGold[0] + " X:" + selectedGold[1] + " olarak belirlendi. Toplam tahmini Kazanç: " + GetHedefeVardigindaAlacagiToplamPuan() + "Altın Degeri: " + squareGold);





        }
    }
}
