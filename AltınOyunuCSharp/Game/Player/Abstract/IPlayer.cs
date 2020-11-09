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
        int getGold(); //Kaç altını olduğunu gösterme
        void setGold(); //Altın değerini güncelleme
        bool isDeath(); //Oyuncu yaşıyor mu?
        void setLog(string log); //Oyuncu hareketleri LOG kayıt
        List<string> getLog(); //Oyuncu haraketleri LOG görüntüle
    }
}
