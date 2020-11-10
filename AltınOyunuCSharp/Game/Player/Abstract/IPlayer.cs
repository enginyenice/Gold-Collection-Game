using AltınOyunuCSharp.Game.Map.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Abstract
{
    interface IPlayer
    {
        abstract int[] SearchForGold(IMap map); //Hedef belirleme
        void CordUpdate(int yCord, int xCord); // Son kordinatlarını güncelleme
        int GetGold(); //Kaç altını olduğunu gösterme
        void SetGold(int gold); //Altın değerini güncelleme
        bool IsDeath(); //Oyuncu yaşıyor mu?
        void SetLog(string log); //Oyuncu hareketleri LOG kayıt
        List<string> GetLog(); //Oyuncu haraketleri LOG görüntüle
        void SetTargetedGold(int cordY, int cordX); //Hedeflenen altını kayıt et.
         int[] GetTargetedGold(); //Hedeflenen altını getir.
    }
}
