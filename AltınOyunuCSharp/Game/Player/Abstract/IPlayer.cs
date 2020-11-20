using AltınOyunuCSharp.Game.Map.Abstract;
using System.Collections.Generic;

namespace AltınOyunuCSharp.Game.Player.Abstract
{
    internal interface IPlayer
    {
        #region GET

        int GetTotalNumberOfSteps();// Oyuncunun oyun boyunca toplam hamle sayısı
        

        int GetTotalAmountOfGoldSpent();// Oyuncunun oyun boyunca harcadığı toplam altın


        int GetTotalAmountOfGoldEarned();// Oyuncunun oyun boyunca kazandığı toplam altın
        

        int[,] GetPlayerMatris();// Oyuncu matrisini (int) döndürür.

        string GetPlayerMapString();//Oyuncu matrisini(string) Consol için text olarak döndürür.

        int GetPlayerGold();//Oyuncunun kasasında bulunan altını döndürür.

        int GetGoldEarnedOnReachTarget();//Hedeflenen altına ulaşıldığında elde edeceği kar değerini döndürür.

        int[] GetLastCord();//Oyuncunun oyun alanında bulunduğu son konumu döndürür.

        int GetSearchCost();//Hedef belirleme maliyetini döndürür.

        int GetRemainingSteps();//Oyuncunun hedefine kalan hamle sayısını döndürür.

        List<string> GetLog();//Oyuncunun oyun sırasında yaptığı tüm işlemlerin kaydını döndürür.

        int[] GetTargetedGoldCord();//Hedeflenen altının bulunduğu koordinatı döndürür.

        int GetTargetedGoldValue();//Hedeflenen altının değerini döndürür.

        #endregion GET

        #region SET
        void SetTotalNumberOfSteps(int value);// Oyuncunun oyun boyunca yaptığı toplam hamle değerini arttırır.

        void SetTotalAmountOfGoldSpent(int value); // Oyuncunun oyun boyunca harcadığı toplam altın değerini arttırır.

        void SetTotalAmountOfGoldEarned(int value); // Oyuncunun oyun boyunca kazandığı toplam altın değerini arttırır.

        void SetPlayerGold(int gold);//Oyuncunun kasasında bulunan altını belirler.

        void SetLog(string log);//Oyuncunun hareketlerini listeye ekler.

        void SetGoldEarnedOnReachTarget(int gold);//Hedeflenen altına ulaşıldığında elde edeceği kar değerini belirler.

        void SetRemainingSteps(int remainingSteps);//Oyuncunun hedefine kalan hamle sayısını belirler.

        void SetTargetedGoldCord(int CordY, int CordX);//Hedeflenen altının koordinatlarını belirler.

        void SetTargetedGoldValue(int goldValue);//Hedeflenen altının değerini belirler.

        void SetPlayerMapValue(int CordY, int CordX, int data); //Belirtilen kordinattaki değeri değiştirir.

        #endregion SET

        #region UPDATE

        void UpdatePlayerGoldValue(int gold);//Oyuncunun kasasındaki altına ekleme, çıkarma yapar.

        void UpdateCord(int yCord, int xCord);//Oyuncunun bulunduğu konumu belirler.

        #endregion UPDATE

        #region GAME FUNCTION

        abstract void SearchForGold(IMap map);

        void PrivateGoldShow(char duzlem, int hareket, IMap map);

        void Move(IMap map);

        bool IsDeath();

        #endregion GAME FUNCTION

        #region WRITE TXT

        void CreateFolder(); //Oyun kayıtlarını tutan bir klasör oluşturur.

        void WriteToFile(string maptext); //Oyun kayıtlarını txt dosyasına yaz.

        #endregion WRITE TXT
    }
}