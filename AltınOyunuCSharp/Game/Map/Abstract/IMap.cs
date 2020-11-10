using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Map.Abstract
{


    /*
     *  Harita gösterimi : 
     *                      Boş kare   : 
     *                      -----------------------
     *                      A kullanıcı: A
     *                      B kullanıcı: B
     *                      C kullanıcı: C
     *                      D kullanıcı: D
     *                      -----------------------
     *                      Görünür altın 5 : 5
     *                      Görünür altın 10 : 10
     *                      Görünür altın 15 : 15
     *                      Görünür altın 20 : 20
     *                      ------------------------
     *                      Görünmez altın 5 : G-5
     *                      Görünmez altın 10 : G-10
     *                      Görünmez altın 15 : G-15
     *                      Görünmez altın 20 : G-20
     */

    public interface IMap
    {
        public void AddGold(int GoldRate, int PrivateGoldRate); // Kaç adet altın eklenecek. Yüzde kaçı gizli
        void AddPrivateGold(int PrivateGoldField); // Gizli altın ekle
        bool GameOver(); // Oyun bitti mi.
        string GetMap(); // Haritayı String döndür.
        string[,] GetMatrisMap(); // Haritayı Matris döndür.
        void SetMap(int yCord, int xCord,string data); // Haritaya veri ekle
        string GetPoint(int yCord, int xCord); // Karenin içindeki değeri getirir
        void AddPlayer(int yCord, int xCord,string PlayerCode); // Oyuncuyu haritaya ekle
        bool IsFull(); // Harita tamamen dolu mu?
    }
}
