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
        private string[,] map;
        private int mapSquare; // Kare içerisindeki değer
        private int moveLenght; //Maksimum Hareket
        private int cost; //Maliyet

        private List<string> goldCords; //Altın kordinatları var
        private List<string> PrivateGoldCords; //Gizli altın kordinatları var

        int gameOrder = 1;

        public Map(int m,int n, int cost,int moveLenght)
        {
            goldCords = new List<string>();
            PrivateGoldCords = new List<string>();

            string[,] _map = new string[m, n];
            this.moveLenght = moveLenght;
            this.cost = cost;

            for(int i = 0; i< m; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    _map[i, k] = String.Empty;
                }
            }
            mapSquare = m * n;
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
                if(GetPoint(randomX,randomY) == String.Empty)
                {
                    SetMap(randomX, randomY, (rastgele.Next(1, 4) * 5).ToString());
                    goldCords.Add(randomX + "," + randomY);
                    goldField = i;
                } else
                {
                    goto GoldDetected;
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
                    SetMap(randomX, randomY, "G-" + (rastgele.Next(1, 4) * 5));
                    PrivateGoldCords.Add(randomX + "," + randomY);
                    PrivateGoldField = i;
                }
                else
                {
                    goto PrivateGoldDetected;
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
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int k = 0; k < map.GetLength(1); k++)
                {
                    mapText += " | " + map[i, k];
                }
                mapText += " |\n";
            }
            return mapText;
        }
        public string GetPoint(int xCord,int yCord)
        {
            return map[xCord, yCord];
        }
        public void SetMap(int xCord, int YCord, string data)
        {
            map[xCord, YCord] = data;
        }
        public void AddPlayer(int xCord, int YCord, string PlayerCode)
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
    }
}
