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
        abstract void SearchForGold(IMap map); //Hedef belirleme
        bool IsDeath(); //Oyuncu yaşıyor mu?
        void CordUpdate(int yCord, int xCord); // Son kordinatlarını güncelleme
        
        void SetGold(int gold); //Altın değerini güncelleme
        void SetLog(string log); //Oyuncu hareketleri LOG kayıt
        void SetTargetedGold(int cordY, int cordX); //Hedeflenen altını kayıt et.
        void SetRemainingSteps(int remainingSteps); //Hedefe kalan adımı ekleme.


        int GetRemainingSteps();  // Hedefe kaç adım kaldı.
        int GetGold(); //Kaç altını olduğunu gösterme
        List<string> GetLog(); //Oyuncu haraketleri LOG görüntüle
        int[] GetTargetedGold(); //Hedeflenen altını getir.
        int GetTargetGoldValue(); //Hedeflenen kare kaç altın değerinde
        void SetTargetGoldValue(int goldValue); //Hedeflenen karenin altın değeri.
        int[] GetCord(); // Bulunduğu kordinatı getir. | 0 -> Y  | 1 -> X |
    }
}
