using AltınOyunuCSharp.Game.Map.Abstract;
using System.Collections.Generic;

namespace AltınOyunuCSharp.Game.Player.Abstract
{
    internal interface IPlayer
    {
        #region GET

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

        int[] GetMoveCordValue();

        #endregion GET

        #region SET

        void SetPlayerGold(int gold);//Oyuncunun kasasında bulunan altını belirler.

        void SetLog(string log);//Oyuncunun hareketlerini listeye ekler.

        void SetGoldEarnedOnReachTarget(int gold);//Hedeflenen altına ulaşıldığında elde edeceği kar değerini belirler.

        void SetRemainingSteps(int remainingSteps);//Oyuncunun hedefine kalan hamle sayısını belirler.

        void SetTargetedGoldCord(int CordY, int CordX);//Hedeflenen altının koordinatlarını belirler.

        void SetTargetedGoldValue(int goldValue);//Hedeflenen altının değerini belirler.

        void SetMoveCordValue(int CordY, int CordX);

        void SetPlayerMapValue(int CordY, int CordX, int data);

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
    }
}