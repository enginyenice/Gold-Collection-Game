using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Abstract
{
    interface IPlayer
    {
        int[,] SearchForGold(); //Hedef belirleme
        int GetGold(); //Kaç altını olduğunu gösterme
        void SetGold(int gold); //Altın değerini güncelleme
        bool IsDeath(); //Oyuncu yaşıyor mu?
        void SetLog(string log); //Oyuncu hareketleri LOG kayıt
        List<string> GetLog(); //Oyuncu haraketleri LOG görüntüle
    }
}
