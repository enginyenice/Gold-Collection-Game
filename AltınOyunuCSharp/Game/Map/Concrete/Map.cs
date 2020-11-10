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
        private readonly int mapSquare; // Kare içerisindeki değer
        private readonly int moveLenght; //Maksimum Hareket
        private readonly int cost; //Maliyet

        private readonly List<string> goldCords; //Altın kordinatları var
        private readonly List<string> PrivateGoldCords; //Gizli altın kordinatları var

        int gameOrder = 1;

        public Map(int ySize,int xSize, int cost,int moveLenght)
        {
            goldCords = new List<string>();
            PrivateGoldCords = new List<string>();

            string[,] _map = new string[ySize, xSize];
            this.moveLenght = moveLenght;
            this.cost = cost;

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
        public void AddGold(int GoldRate,int PrivateGoldRate)
        {
            int goldField = (mapSquare * GoldRate) / 100;
            int privateGoldField = (goldField * PrivateGoldRate) / 100;
            goldField -= privateGoldField;

            Random rastgele = new Random();
            

            for(int i = goldField; i> 0;i--)
            {
                GoldDetected:
                int randomX = rastgele.Next(map.GetLength(0));
                int randomY = rastgele.Next(map.GetLength(1));
                if(GetPoint(randomY, randomX) == String.Empty)
                {
                    SetMap(randomX, randomY, (rastgele.Next(1, 4) * 5).ToString());
                    goldCords.Add(randomY+","+ randomX);
                } else
                {

                    if (IsFull() == false)
                        goto GoldDetected;
                    else
                        break;
                   
                }

            }
            AddPrivateGold(privateGoldField);



        }
        public void AddPrivateGold(int PrivateGoldField)
        {
            Random rastgele = new Random();


            for (int i = PrivateGoldField; i > 0; i--)
            {
            PrivateGoldDetected:
                int randomX = rastgele.Next(map.GetLength(0));
                int randomY = rastgele.Next(map.GetLength(1));
                if (GetPoint(randomX, randomY) == String.Empty)
                {
                    SetMap(randomY, randomX, "G-" + (rastgele.Next(1, 4) * 5));
                    PrivateGoldCords.Add(randomY + "," + randomX);
                }
                else
                {
                    if (IsFull() == false)
                        goto PrivateGoldDetected;
                    else
                        break;
                }

            }
        }
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
        public string GetPoint(int yCord,int xCord)
        {
            return map[xCord, yCord];
        }
        public void SetMap(int YCord, int xCord, string data)
        {
            map[YCord, xCord] = data;
        }
        public void AddPlayer( int YCord, int xCord, string PlayerCode)
        {
            SetMap(xCord, YCord, PlayerCode);
        }

        public int GetGameOrder()
        {
            return gameOrder;
        }
        public void SetGameOrder()
        {
            if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;
        }

        public string[,] GetMatrisMap()
        {
            return this.map;
        }

        public bool IsFull()
        {
            for(int y = 0; y< map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == String.Empty)
                        return false;
                }
            }
            return true;
        }
    }
}
