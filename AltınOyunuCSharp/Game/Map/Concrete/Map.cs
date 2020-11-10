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
        private readonly int mapSquare; // Oyun alanı kare sayısı


        private readonly List<string> goldCords; //Altın kordinatları var
        private readonly List<string> privateGoldCords; //Gizli altın kordinatları var

        int gameOrder = 1;

        public Map(int ySize,int xSize)
        {
            goldCords = new List<string>();
            privateGoldCords = new List<string>();

            string[,] _map = new string[ySize, xSize];
            for(int i = 0; i< ySize; i++)
            {
                for (int k = 0; k < xSize; k++)
                {
                    _map[i, k] = String.Empty;
                }
            }
            mapSquare = ySize * xSize;
            map = _map;
        }

        #region GET
        public bool GameOver()
        {
            throw new NotImplementedException();
        }
        public string GetMap()
        {
            string mapText = "";
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    mapText += " | " + map[y, x];
                }
                mapText += " |\n";
            }
            return mapText;
        }
        public string GetPoint(int yCord, int xCord)
        {
            return map[yCord, xCord];
        }

        public int GetGameOrder()
        {
            return gameOrder;
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
        public List<string> GetGoldList()
        {
            return this.goldCords;
        }

        public List<string> GetPrivateGoldList()
        {
            return this.privateGoldCords;
        }

        #endregion
        #region Remove

        public void RemoveGold(string data)
        {
            try
            {
                this.goldCords.Remove(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void RemovePrivateGold(string data)
        {
            try
            {
                this.privateGoldCords.Remove(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region SET
        public void SetGameOrder()
        {
            if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;
        }

        public void AddGold(int cordY, int cordX, int gold)
        {
            this.goldCords.Add(cordY + "," + cordX + "," + gold);
        }

        public void AddPrivateGold(int cordY, int cordX, string gold)
        {
            this.privateGoldCords.Add(cordY + "," + cordX + "," + gold);
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
                    gold = (rastgele.Next(1, 4) * 5);
                    SetMap(randomY, randomX, gold.ToString());
                    this.AddGold(randomY, randomX, gold);
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
            
            
            
            //for (int i = goldField; i > 0; i--)
            //{
            //GoldDetected:
            //    int randomY = rastgele.Next(map.GetLength(0));
            //    int randomX = rastgele.Next(map.GetLength(1));
            //    if (GetPoint(randomY, randomX) == String.Empty)
            //    {
            //        int gold;
            //        gold = (rastgele.Next(1, 4) * 5);
            //        SetMap(randomY, randomX, gold.ToString());
            //        this.AddGold(randomY, randomX, gold);
            //    }
            //    else
            //    {

            //        if (IsFull() == false)
            //            goto GoldDetected;
            //        else
            //            break;

            //    }

            //}
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
                    gold = (rastgele.Next(1, 4) * 5);
                    SetMap(randomY, randomX, "G-"+gold.ToString());
                    this.AddPrivateGold(randomY, randomX, "G-"+gold);
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


            //Random rastgele = new Random();


            //for (int i = PrivateGoldField; i > 0; i--)
            //{
            //PrivateGoldDetected:
            //    int randomY = rastgele.Next(map.GetLength(0));
            //    int randomX = rastgele.Next(map.GetLength(1));
            //    if (GetPoint(randomX, randomY) == String.Empty)
            //    {
            //        int privateGold = (rastgele.Next(1, 4) * 5);
            //        SetMap(randomY, randomX, "G-" + privateGold);
            //        privateGoldCords.Add(randomY + "," + randomX + "," + privateGold);
            //        this.AddPrivateGold(randomY, randomX, "G-" + privateGold);
            //    }
            //    else
            //    {
            //        if (IsFull() == false)
            //            goto PrivateGoldDetected;
            //        else
            //            break;
            //    }

            //}
        }

        #endregion

    }
}
