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
        private int[,] map;
        private int mapSquare;
        public Map(int m,int n)
        {
            int[,] _map = new int[m, n];
            for(int i = 0; i< m; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    _map[i, k] = 0;
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
                if(map[randomX,randomY] == 0)
                {
                    map[randomX, randomY] = (rastgele.Next(1, 4) * 5);
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
                if (map[randomX, randomY] == 0)
                {
                    map[randomX, randomY] = 50+(rastgele.Next(1, 4) * 5);
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
        public void SetMap(int xCord, int YCord)
        {
            throw new NotImplementedException();
        }
    }
}
