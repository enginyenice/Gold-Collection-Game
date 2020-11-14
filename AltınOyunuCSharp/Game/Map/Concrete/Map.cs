using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Map.Concrete
{
    public class Map : IMap
    {
        private readonly string[,] map; 
        private readonly int[,] goldMap;
        private readonly int[,] privateGoldMap;
        private readonly int mapSquare; // Oyun alanı kare sayısı

        public int[] aPlayerTarget;
        public int[] bPlayerTarget;
        public int[] cPlayerTarget;
        public int[] dPlayerTarget;
        public int[] playersRemainingSteps;
        List<int> playersIsDeath;
        int gameOrder = 1;

        public Map(int ySize,int xSize)
        {
            aPlayerTarget = new int[2];
            bPlayerTarget = new int[2];
            cPlayerTarget = new int[2];
            dPlayerTarget = new int[2];
            playersRemainingSteps = new int[4];
            playersIsDeath = new List<int>();
            playersIsDeath.Add(1);
            playersIsDeath.Add(2);
            playersIsDeath.Add(3);
            playersIsDeath.Add(4);
           
            map = new string[ySize, xSize];
            goldMap = new int[ySize, xSize];
            privateGoldMap = new int[ySize, xSize];
            for(int i = 0; i< ySize; i++)
            {
                for (int k = 0; k < xSize; k++)
                {
                    goldMap[i, k] = 0;
                    privateGoldMap[i, k] = 0;
                    SetMapPointData(i, k, String.Empty);
                }
            }
            mapSquare = ySize * xSize;
        }

        #region GET
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
        }
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
        }
        public string GetMapPoint(int CordY, int CordX)
        {
            return map[CordY, CordX];
        }
        public int GetGoldPoint(int CordY, int CordX)
        {
            return goldMap[CordY, CordX];
        }
        public int GetPrivateGoldPoint(int CordY, int CordX)
        {
            return privateGoldMap[CordY, CordX];
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
        #endregion

        #region REMOVE
        public void RemovePlayersIsDeath(int gameOrder)
        {
            this.playersIsDeath.Remove(gameOrder);
            playersIsDeath = playersIsDeath.OrderBy(a => a).ToList();
        }
        public void RemoveGoldMapPoint(int CordY, int CordX)
        {//Gold Haritası Noktadaki Değeri Sil
            this.goldMap[CordY, CordX] = 0;
        }
        public void RemovePrivateGoldPoint(int CordY, int CordX)
        {//Private Gold Haritası Noktadaki Değer
            this.privateGoldMap[CordY, CordX] = 0;
        }
        #endregion

        #region SET
        public void SetPlayerRemainingSteps(int steps,string playerName)
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
        public void SetPlayerTarget(int targetY,int targetX,string playerName)
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
        public void SetGameOrder()
        {
            if (playersIsDeath.Count != 0)
            {
                int order = playersIsDeath.IndexOf(gameOrder);
                if (order == (playersIsDeath.Count()-1)) 
                    gameOrder = playersIsDeath[0];
                else
                    gameOrder= playersIsDeath[order+1];
            }
            else
                gameOrder = -1;
            /*if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;*/
        }
        public void SetMapPointData(int CordY, int CordX, string data)
        {
            map[CordY, CordX] = data;
        }
        #endregion

        #region UPDATE
        public void AddGoldMapPoint(int CordY, int CordX, int data)
        {  //Gold Haritası Noktasına Değer Ekle
            this.goldMap[CordY, CordX] = data;
        }
        public void AddPlayer(int CordY, int CordX, string PlayerCode)
        {
            SetMapPointData(CordY, CordX, PlayerCode);
        }
        public void AddGold(int GoldRate, int PrivateGoldRate)
        {
            int goldField = (mapSquare * GoldRate) / 100;
            int privateGoldField = (goldField * PrivateGoldRate) / 100;
            goldField = goldField - privateGoldField;
            Random rastgele = new Random();

            int i = 0;
            while (i < goldField)
            {
            GoldDetected:
                int randomY = rastgele.Next(map.GetLength(0));
                int randomX = rastgele.Next(map.GetLength(1));
                if (GetMapPoint(randomY, randomX) == String.Empty)
                {
                    int gold;
                    gold = (rastgele.Next(1, 5) * 5);
                    SetMapPointData(randomY, randomX, gold.ToString());
                    this.AddGoldMapPoint(randomY, randomX, gold);
                    goldMap[randomY, randomX] = gold;
                    i++;
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
            AddPrivateGold(privateGoldField);


        }
        public void AddPrivateGold(int PrivateGoldField)
        {
            Random rastgele = new Random();

            int i = 0;
            while (i < PrivateGoldField)
            {
            PrivateGoldDetected:
                int randomY = rastgele.Next(map.GetLength(0));
                int randomX = rastgele.Next(map.GetLength(1));
                if (GetMapPoint(randomY, randomX) == String.Empty)
                {
                    int gold;
                    gold = (rastgele.Next(1, 5) * 5);
                    SetMapPointData(randomY, randomX, "G-" + gold.ToString());
                    privateGoldMap[randomY, randomX] = gold;
                    i++;
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
        #endregion

        #region GAME FUNCTION
        public bool GameOver()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
