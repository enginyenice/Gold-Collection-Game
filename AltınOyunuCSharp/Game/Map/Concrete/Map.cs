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


        public int[] aOyuncuHedefi;
        public int[] bOyuncuHedefi;
        public int[] cOyuncuHedefi;
        public int[] dOyuncuHedefi;
        public int[] oyuncuHedefeKalanAdim;
        



        int gameOrder = 1;

        public Map(int ySize,int xSize)
        {
            aOyuncuHedefi = new int[2];
            bOyuncuHedefi = new int[2];
            cOyuncuHedefi = new int[2];
            dOyuncuHedefi = new int[2];
            oyuncuHedefeKalanAdim = new int[4];


            map = new string[ySize, xSize];
            goldMap = new int[ySize, xSize];
            privateGoldMap = new int[ySize, xSize];
            for(int i = 0; i< ySize; i++)
            {
                for (int k = 0; k < xSize; k++)
                {
                    goldMap[i, k] = 0;
                    privateGoldMap[i, k] = 0;
                    SetMap(i, k, String.Empty);
                }
            }
            mapSquare = ySize * xSize;
        }

        #region GET

        public int GetOyuncuHedefeKalanAdim(string oyuncuAdi)
        {
            switch (oyuncuAdi)
            {
                case "A":
                    return oyuncuHedefeKalanAdim[0];
                case "B":
                    return oyuncuHedefeKalanAdim[1];
                case "C":
                    return oyuncuHedefeKalanAdim[2];
                case "D":
                    return oyuncuHedefeKalanAdim[3];
                default:
                    return oyuncuHedefeKalanAdim[0];
            }
        }

        public int[] GetOyuncuHedef(string oyuncuAdi)
        {
            switch (oyuncuAdi)
            {
                case "A":
                    return aOyuncuHedefi;
                case "B":
                    return bOyuncuHedefi;
                case "C":
                    return cOyuncuHedefi;
                case "D":
                    return dOyuncuHedefi;
                default:
                    return aOyuncuHedefi;
            }
        }
        public int[,] GetGoldMap()
        {
            return this.goldMap;
        }        
        public int[,] GetPrivateGoldMap()
        {
            return this.privateGoldMap;
        }


        public bool GameOver()
        {
            throw new NotImplementedException();
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
        public string GetPoint(int yCord, int xCord)
        {
            return map[yCord, xCord];
        }
        public int GetGoldPoint(int yCord, int xCord)
        {
            return goldMap[yCord, xCord];
        }

        public int GetPrivateGoldPoint(int yCord, int xCord)
        {
            return privateGoldMap[yCord, xCord];
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

        public int GetGameOrder()
        {
            return gameOrder;
        }


        public void RemovePrivateGoldPoint(int yCord, int xCord)
        {  //Private Gold Haritası Noktadaki Değer
            this.privateGoldMap[yCord, xCord] = 0;

        }
        public void AddGoldMapPoint(int yCord, int xCord, int data)
        {  //Gold Haritası Noktasına Değer Ekle
            this.goldMap[yCord, xCord] = data;
        }
        public void RemoveGoldMapPoint(int yCord, int xCord)
        {  //Gold Haritası Noktadaki Değeri Sil
            this.goldMap[yCord, xCord] = 0;

        }
        public string[,] GetMatrisMap()
        {
            return this.map;
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
        #region Remove



        public void RemovePrivateGold(string data)
        {
            try
            {
                string[] parseData = data.Split(',');
                this.privateGoldMap[Int32.Parse(parseData[0]), Int32.Parse(parseData[1])] = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region SET

        public void SetOyuncuHedefeKalanAdim(int adim,string oyuncuAdi)
        {
            switch (oyuncuAdi)
            {
                case "A":
                    oyuncuHedefeKalanAdim[0] = adim;
                    break;
                case "B":
                    oyuncuHedefeKalanAdim[1] = adim;
                    break;
                case "C":
                    oyuncuHedefeKalanAdim[2] = adim;
                    break;
                case "D":
                    oyuncuHedefeKalanAdim[3] = adim;
                    break;

                default:
                    break;
            }
        }

        public void SetOyuncuHedefi(int y,int x,string oyuncuAdi)
        {
            switch (oyuncuAdi)
            {
                case "A":
                    aOyuncuHedefi[0] = y;
                    aOyuncuHedefi[1] = x;
                    break;
                case "B":
                    bOyuncuHedefi[0] = y;
                    bOyuncuHedefi[1] = x;
                    break;
                case "C":
                    cOyuncuHedefi[0] = y;
                    cOyuncuHedefi[1] = x;
                    break;
                case "D":
                    dOyuncuHedefi[0] = y;
                    dOyuncuHedefi[1] = x;
                    break;

                default:
                    break;
            }

        }

        public void SetGameOrder()
        {
            if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;
        }

        public void AddGold(int cordY, int cordX, int gold)
        {
            this.goldMap[cordY, cordX] = gold;
        }

        public void AddPrivateGold(int cordY, int cordX, string gold)
        {
            //this.privateGoldCords.Add(cordY + "," + cordX + "," + gold);
        }
        public void SetMap(int YCord, int xCord, string data)
        {
            map[YCord, xCord] = data;
        }
        public void AddPlayer(int YCord, int xCord, string PlayerCode)
        {
            SetMap(YCord, xCord, PlayerCode);
        }
       
        
        
        public void AddGold(int GoldRate, int PrivateGoldRate)
        {
            int goldField = (mapSquare * GoldRate) / 100;
            int privateGoldField = (goldField * PrivateGoldRate) / 100;
            goldField = goldField - privateGoldField;
            Random rastgele = new Random();


            int i = 0;
            while(i < goldField)
            {
            GoldDetected:
                int randomY = rastgele.Next(map.GetLength(0));
                int randomX = rastgele.Next(map.GetLength(1));
                if (GetPoint(randomY, randomX) == String.Empty)
                {
                    int gold;
                    gold = (rastgele.Next(1, 5) * 5);
                    SetMap(randomY, randomX, gold.ToString());
                    this.AddGold(randomY, randomX, gold);
                    goldMap[randomY, randomX] = gold;
                    i++;
                }
                else
                {
                    if (IsFull() == false)
                    {
                        goto GoldDetected; 
                    }
                    else { 
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
                if (GetPoint(randomY, randomX) == String.Empty)
                {
                    int gold;
                    gold = (rastgele.Next(1, 5) * 5);
                    SetMap(randomY, randomX, "G-"+gold.ToString());
                    this.AddPrivateGold(randomY, randomX, "G-"+gold);
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

    }
}
