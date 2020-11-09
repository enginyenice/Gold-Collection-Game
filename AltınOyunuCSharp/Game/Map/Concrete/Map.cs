using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Map.Concrete
{
    class Map : IMap
    {
        private string[,] map;
        
        private int mapSquare;


        int gameOrder = 1;
        public int getGameOrder()
        {
            return gameOrder;
        }
        public void setGameOrder()
        {
            if (gameOrder > 3)
                gameOrder = 1;
            else
                gameOrder++;
        }
        
        public Map(int m,int n)
        {
            string[,] _map = new string[m, n];
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
        public void AddGold(int rate)
        {
            int goldField = (mapSquare * rate) / 100;
            Random rastgele = new Random();
            

            for(int i = goldField; i> 0;i--)
            {
                GoldDetected:
                int randomX = rastgele.Next(map.GetLength(0));
                int randomY = rastgele.Next(map.GetLength(1));
                if(getPoint(randomX,randomY) == String.Empty)
                {
                    SetMap(randomX, randomY, (rastgele.Next(1, 4) * 5).ToString());
                    goldField = i;
                } else
                {
                    goto GoldDetected;
                }

            }



        }
        public void AddPrivateGold(int rate)
        {
            int goldField = (mapSquare * rate) / 100;
            Random rastgele = new Random();


            for (int i = goldField; i > 0; i--)
            {
            PrivateGoldDetected:
                int randomX = rastgele.Next(map.GetLength(0));
                int randomY = rastgele.Next(map.GetLength(1));
                if (getPoint(randomX, randomY) == String.Empty)
                {
                    SetMap(randomX, randomY, "G-" + (rastgele.Next(1, 4) * 5));
                    goldField = i;
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
        public string getPoint(int xCord,int yCord)
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
    }
}
