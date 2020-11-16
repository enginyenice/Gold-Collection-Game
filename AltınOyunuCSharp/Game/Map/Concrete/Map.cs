using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltınOyunuCSharp.Game.Map.Concrete
{
    public class Map : IMap
    {
        private readonly string[,] map; // Oyun alanındaki tüm öğeler
        private readonly string[,] cloneMap; // oyun alanının başlangıçtaki şeklini turar.
        private readonly int[,] goldMap; // Oyun alan
        private readonly int[,] privateGoldMap;
        private readonly int mapSquare; // Oyun alanı kare sayısı

        private int[] aPlayerTarget;
        private int[] bPlayerTarget;
        private int[] cPlayerTarget;
        private int[] dPlayerTarget;
        private int[] playersRemainingSteps;
        private List<int> playersIsDeath;
        private int gameOrder = 1;
        private bool gameOver;
        private String gameOverReason = "";

        public Map(int ySize, int xSize)
        {
            aPlayerTarget = new int[2];
            bPlayerTarget = new int[2];
            cPlayerTarget = new int[2];
            dPlayerTarget = new int[2];
            playersRemainingSteps = new int[4];
            playersIsDeath = new List<int> { 1, 2, 3, 4 };
            gameOver = false;

            map = new string[ySize, xSize];
            cloneMap = new string[ySize, xSize];
            goldMap = new int[ySize, xSize];
            privateGoldMap = new int[ySize, xSize];
            for (int i = 0; i < ySize; i++)
            {
                for (int k = 0; k < xSize; k++)
                {
                    goldMap[i, k] = 0;
                    privateGoldMap[i, k] = 0;
                    UpdateMapPointData(i, k, String.Empty);
                    cloneMap[i, k] = String.Empty;
                }
            }
            mapSquare = ySize * xSize;
        }

        #region GET

        public string[,] GetMap()
        {
            return this.map;
        }

        public int[,] GetGoldMap()
        {
            return this.goldMap;
        }

        public int[,] GetPrivateGoldMap()
        {
            return this.privateGoldMap;
        }

        public int[] GetPlayerTarget(string playerName)
        {
            switch (playerName)
            {
                case "A":
                    return aPlayerTarget;

                case "B":
                    return bPlayerTarget;

                case "C":
                    return cPlayerTarget;

                case "D":
                    return dPlayerTarget;

                default:
                    return aPlayerTarget;
            }
        }

        public int GetPlayerRemainingSteps(string playerName)
        {
            switch (playerName)
            {
                case "A":
                    return playersRemainingSteps[0];

                case "B":
                    return playersRemainingSteps[1];

                case "C":
                    return playersRemainingSteps[2];

                case "D":
                    return playersRemainingSteps[3];

                default:
                    return playersRemainingSteps[0];
            }
        }

        public int GetGoldCount()
        {
            int count = 0;
            for (int y = 0; y < goldMap.GetLength(0); y++)
            {
                for (int x = 0; x < goldMap.GetLength(1); x++)
                {
                    if (goldMap[y, x] != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int GetPrivateGoldCount()
        {
            int count = 0;
            for (int y = 0; y < privateGoldMap.GetLength(0); y++)
            {
                for (int x = 0; x < privateGoldMap.GetLength(1); x++)
                {
                    if (privateGoldMap[y, x] != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public string GetMapPointValue(int CordY, int CordX)
        {
            return map[CordY, CordX];
        }

        public int GetGoldPointValue(int CordY, int CordX)
        {
            return goldMap[CordY, CordX];
        }

        public int GetPrivateGoldPointValue(int CordY, int CordX)
        {
            return privateGoldMap[CordY, CordX];
        }

        public int GetGameOrder()
        {
            return gameOrder;
        }

        public bool IsFull()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == String.Empty)
                        return false;
                }
            }
            return true;
        }

        public bool GetgameOver()
        {
            return this.gameOver;
        }

        public string GetgameOverReason()
        {
            return this.gameOverReason;
        }

        public string GetGoldMapString()
        {
            string mapText = "Normal Altın\n";
            for (int y = 0; y < goldMap.GetLength(0); y++)
            {
                for (int x = 0; x < goldMap.GetLength(1); x++)
                {
                    mapText += " | " + goldMap[y, x];
                }
                mapText += " |\n";
            }
            return mapText;
        }//Console

        public string GetPrivateGoldMapString()
        {
            string mapText = "Gizli Altın\n";
            for (int y = 0; y < privateGoldMap.GetLength(0); y++)
            {
                for (int x = 0; x < privateGoldMap.GetLength(1); x++)
                {
                    mapText += " | " + privateGoldMap[y, x];
                }
                mapText += " |\n";
            }
            return mapText;
        }//Console

        public string GetMapString()//Log
        {
            string text = "";
            for (int y = -1; y < this.GetMap().GetLength(0); y++)
            {
                for (int x = -1; x < this.GetMap().GetLength(1); x++)
                {
                    if (y == -1)
                    {
                        if (x == -1)
                            text += "|   ";
                        else if (x < 10)
                            text += "|" + x + "   ";
                        else if (x > 9 && x < 100)
                            text += "|" + x + "  ";
                        else if (x > 99)
                            text += "|" + x + " ";
                    }
                    else
                    {
                        if (x == -1)
                        {
                            if (x == -1 && y < 10)
                                text += "|  " + y + "";
                            else if (x == -1 && y > 9 && y < 100)
                                text += "| " + y + "";
                            else if (x == -1 && y > 99)
                                text += "|" + y + "";
                        }
                        else
                        {
                            text += "|" + this.GetMapPointValue(y, x);
                            for (int i = 0; i < (4 - this.GetMapPointValue(y, x).Length); i++)
                            {
                                text += " ";
                            }
                        }
                    }
                }
                text += "|\r\n";
            }
            return text;
        }

        #endregion GET

        #region SET

        public void SetPlayerTarget(int targetY, int targetX, string playerName)
        {
            switch (playerName)
            {
                case "A":
                    aPlayerTarget[0] = targetY;
                    aPlayerTarget[1] = targetX;
                    break;

                case "B":
                    bPlayerTarget[0] = targetY;
                    bPlayerTarget[1] = targetX;
                    break;

                case "C":
                    cPlayerTarget[0] = targetY;
                    cPlayerTarget[1] = targetX;
                    break;

                case "D":
                    dPlayerTarget[0] = targetY;
                    dPlayerTarget[1] = targetX;
                    break;

                default:
                    break;
            }
        }

        public void SetPlayerRemainingSteps(int steps, string playerName)
        {
            switch (playerName)
            {
                case "A":
                    playersRemainingSteps[0] = steps;
                    break;

                case "B":
                    playersRemainingSteps[1] = steps;
                    break;

                case "C":
                    playersRemainingSteps[2] = steps;
                    break;

                case "D":
                    playersRemainingSteps[3] = steps;
                    break;

                default:
                    break;
            }
        }

        public void SetGameOrder()
        {
            if (GetGoldCount() > 0)
            {
                if (playersIsDeath.Count != 0)
                {
                    int order = playersIsDeath.IndexOf(gameOrder);
                    if (order == (playersIsDeath.Count() - 1))
                        gameOrder = playersIsDeath[0];
                    else
                        gameOrder = playersIsDeath[order + 1];
                }
                else
                {
                    gameOrder = -1;
                    gameOverReason = "Tüm oyuncular elendi.";
                    gameOver = true;
                }
            }
            else
            {
                gameOverReason = "Oyun alanında altın kalmadı.";
                gameOver = true;
            }
            //gameOrder = -1;
            /*if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;*/
        }

        #endregion SET

        #region REMOVE

        public void RemovePlayersIsDeath(int gameOrder)
        {
            this.playersIsDeath.Remove(gameOrder);
            playersIsDeath = playersIsDeath.OrderBy(a => a).ToList();
        }

        public void RemoveGoldPoint(int CordY, int CordX)
        {//Gold Haritası Noktadaki Değeri Sil
            this.goldMap[CordY, CordX] = 0;
        }

        public void RemovePrivateGoldPoint(int CordY, int CordX)
        {//Private Gold Haritası Noktadaki Değer
            this.privateGoldMap[CordY, CordX] = 0;
        }

        #endregion REMOVE

        #region UPDATE

        public void UpdateMapPointData(int CordY, int CordX, string data)
        {
            map[CordY, CordX] = data;
        }

        public void UpdateGoldMapPoint(int CordY, int CordX, int data)
        {  //Gold Haritası Noktasına Değer Ekle
            this.goldMap[CordY, CordX] = data;
        }

        public void UpdatePrivateGoldMapPoint(int CordY, int CordX, int data)
        {  //Gold Haritası Noktasına Değer Ekle
            this.privateGoldMap[CordY, CordX] = data;
        }

        public void AddPlayer(int CordY, int CordX, string PlayerCode)
        {
            UpdateMapPointData(CordY, CordX, PlayerCode);
            cloneMap[CordY, CordX] = PlayerCode;
        }

        public void AddAllGold(int GoldRate, int PrivateGoldRate)
        {
            int goldField = (mapSquare * GoldRate) / 100;
            int privateGoldField = (goldField * PrivateGoldRate) / 100;
            goldField = goldField - privateGoldField;
            Random rand = new Random();

            int count = 0;
            while (count < goldField)
            {
            GoldDetected:
                int randomY = rand.Next(map.GetLength(0));
                int randomX = rand.Next(map.GetLength(1));
                if (GetMapPointValue(randomY, randomX) == String.Empty)
                {
                    int gold = (rand.Next(1, 5) * 5);
                    UpdateMapPointData(randomY, randomX, gold.ToString());
                    cloneMap[randomY, randomX] = gold.ToString();
                    UpdateGoldMapPoint(randomY, randomX, gold);
                    count++;
                }
                else
                {
                    if (IsFull() == false)
                    {
                        goto GoldDetected;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            count = 0;
            while (count < privateGoldField)
            {
            PrivateGoldDetected:
                int randomY = rand.Next(map.GetLength(0));
                int randomX = rand.Next(map.GetLength(1));
                if (GetMapPointValue(randomY, randomX) == String.Empty)
                {
                    int gold = (rand.Next(1, 5) * 5);
                    UpdateMapPointData(randomY, randomX, "G-" + gold.ToString());
                    cloneMap[randomY, randomX] = "G-" + gold.ToString();
                    UpdatePrivateGoldMapPoint(randomY, randomX, gold);
                    count++;
                }
                else
                {
                    if (IsFull() == false)
                    {
                        goto PrivateGoldDetected;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        #endregion UPDATE
    }
}