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

        int[,] GetGoldMap(); //Gold haritasını geri döndürür.
        int[,] GetPrivateGoldMap(); //Gizli Gold haritasını geri döndürür.
        int[] GetPlayerTarget(string oyuncuAdi); //Oyuncu hedefini getir
        void SetPlayerTarget(int y, int x, string oyuncuAdi); //Oyuncuya hedef ver.
        void SetPlayerRemainingSteps(int adim, string oyuncuAdi); // Oyuncunun hedefe kaç adımı var.
        int GetPlayerRemainingSteps(string oyuncuAdi); //Oyuncunun hedefe kalan adim sayisini verir.
        int GetGoldCount(); // Gold Map altın sayısı
        int GetPrivateGoldCount();// Gizli gold map altın sayısı
        int GetGoldPoint(int yCord, int xCord); //Gold Haritası Noktadaki Değer
        int GetPrivateGoldPoint(int yCord, int xCord);  //Private Gold Haritası Noktadaki Değer
        void RemovePrivateGoldPoint(int yCord, int xCord);  //Private Gold Haritası Noktadaki Değer
        void AddGoldMapPoint(int yCord, int xCord,int data);  //Gold Haritası Noktasına Değer Ekle
        void RemoveGoldMapPoint(int yCord, int xCord);  //Gold Haritası Noktadaki Değeri Sil
        void AddGold(int GoldRate, int PrivateGoldRate); // Kaç adet altın eklenecek. Yüzde kaçı gizli
        void AddPrivateGold(int PrivateGoldField); // Gizli altın ekle
        bool GameOver(); // Oyun bitti mi.
        //string GetMap(); // Haritayı String döndür.
        string[,] GetMap(); // Haritayı Matris döndür.
        void SetMapPointData(int yCord, int xCord,string data); // Haritaya veri ekle
        string GetMapPoint(int yCord, int xCord); // Karenin içindeki değeri getirir
        void AddPlayer(int yCord, int xCord,string PlayerCode); // Oyuncuyu haritaya ekle
        bool IsFull(); // Harita tamamen dolu mu?
       // List<string> GetGoldList(); //Altınların matrisini verir
       // List<string> GetPrivateGoldList(); // Gizli altınların matrisini verir
       // void RemoveGold(string data);

    }
}
