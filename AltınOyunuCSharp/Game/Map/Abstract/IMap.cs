namespace AltınOyunuCSharp.Game.Map.Abstract
{
    /*
     *  Harita Matrisi değerleri   |  Örnek Gösterim
     *                             |
     *  Boş kare           :       |     |0   |1   |2   |3   |4   |
     *  ---------------------------|  0  |A   |    |5   |10  |B   |
     *  A kullanıcı        : A     |  1  |G-5 |10  |G-5 |    |20  |
     *  B kullanıcı        : B     |  2  |G-20|    |15  |10  |    |
     *  C kullanıcı        : C     |  3  |20  |5   |G-15|    |    |
     *  D kullanıcı        : D     |  4  |C   |    |    |15  |D   |
     *  ---------------------------|
     *  Altın 5            : 5     |
     *  Altın 10           : 10    |
     *  Altın 15           : 15    |
     *  Altın 20           : 20    |
     *  ---------------------------|
     *  Gizli altın 5      : G-5   |
     *  Gizli altın 10     : G-10  |
     *  Gizli altın 15     : G-15  |
     *  Gizli altın 20     : G-20  |
     */

    public interface IMap
    {
        #region GET

        string[,] GetMap();// Harita Matrisini döndürür.

        int[,] GetGoldMap();// Altın harita matrisini geri döndürür.

        int[,] GetPrivateGoldMap();// Gizli Altın harita matrisini geri döndürür.

        int[] GetPlayerTarget(string playerName);// Oyuncunun hedefinin koordinatlarını döndürür.

        int GetPlayerRemainingSteps(string playerName);// Oyuncunun hedefe kalan adim sayisini verir.

        int GetGoldCount();// Oyun alanında bulunan toplam görünür altın sayısını döndürür.

        int GetPrivateGoldCount();// Oyun alanında bulunan toplam gizli altın sayısını döndürür.

        string GetMapPointValue(int CordY, int CordX); // Harita matrisinin girilen koordinatlardaki değerini döndürür.

        int GetGoldPointValue(int CordY, int CordX);// Koordinatları girilen altının değerini döndürür.

        int GetPrivateGoldPointValue(int CordY, int CordX);// Koordinatları girilen gizli altının değerini döndürür.

        int GetGameOrder();// Oyun sırasının hangi oyuncuda olduğunu döndürür.

        bool IsFull();// Harita tamamen dolu mu ?

        bool GetgameOver();// Oyun bitti mi ?

        string GetgameOverReason();// Oyunun bitiş sebebini döndürür.

        public string GetMapString();// 
        #endregion GET

        #region SET

        void SetPlayerTarget(int targetY, int targetX, string playerName);// Oyuncuya hedef ver.

        void SetPlayerRemainingSteps(int steps, string playerName);// Oyuncunun hedefe kaç adımı var.

        void SetGameOrder();// Oyun sırasını belirler.

        #endregion SET

        #region REMOVE

        void RemovePlayersIsDeath(int gameOrder);// Altını bitip ölen oyuncuyu oyun sırasından çıkarır.

        public void RemoveGoldPoint(int CordY, int CordX);// Altın haritasinda girilen koordinatlardaki altını siler.

        void RemovePrivateGoldPoint(int yCord, int xCord);// Gizli Altın haritasinda girilen koordinatlardaki altını siler.

        #endregion REMOVE

        #region UPDATE

        void UpdateGoldMapPoint(int CordY, int CordX, int data);// Altın matrisinin girilen koordinatındaki değeri değiştirir.

        void UpdateMapPointData(int CordY, int CordX, string data);// Harita matrisinin girilen koordinatındaki değeri değiştirir.

        void UpdatePrivateGoldMapPoint(int CordY, int CordX, int data);// Gizli aktın matrisinin girilen koordinatındaki değeri değiştirir.

        void AddPlayer(int CordY, int CordX, string PlayerCode); // Oyuncuyu haritaya ekler.

        void AddAllGold(int GoldRate, int PrivateGoldRate); // Kaç adet altın eklenecek. Yüzde kaçı gizli.

        #endregion UPDATE
    }
}