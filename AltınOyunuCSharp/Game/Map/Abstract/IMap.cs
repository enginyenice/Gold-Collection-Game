using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Map.Abstract
{


    /*
     *  Harita gösterimi : 
     *                      Boş kare   : 0
     *                      -----------------------
     *                      A kullanıcı: 1
     *                      B kullanıcı: 2
     *                      C kullanıcı: 3
     *                      D kullanıcı: 4
     *                      -----------------------
     *                      Görünür altın 5 : 5
     *                      Görünür altın 10 : 10
     *                      Görünür altın 15 : 15
     *                      Görünür altın 20 : 20
     *                      ------------------------
     *                      Görünmez altın 5 : 55
     *                      Görünmez altın 10 : 60
     *                      Görünmez altın 15 : 65
     *                      Görünmez altın 20 : 70
     */

    public interface IMap
    {
        void AddGold(int rate); // Kaç adet altın eklenecek.
        void AddPrivateGold(int rate); // Kaç adet gizli altın eklenecek.
        bool GameOver(); // Oyun bitti mi.
        string GetMap(); // Haritayı döndür.
        void SetMap(int xCord, int YCord); // Haritaya veri ekle
    }
}
