using AltınOyunuCSharp.Game.Map.Abstract;
using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public abstract class Player : IPlayer
    {
        public int[,] playerMap;//Oyuncunun oyun alanındaki konumu        
        public string name; //Oyuncu adı
        public int gold; // Oyuncunun sahip olduğu altın.
        public int moveLenght; //Bir turdaki(hamle) hareket uzunluğu
        public int lastYCord, lastXCord; // O an bulunduğu kordinat
        public int cost; //Hamle maliyeti
        public int searchCost; //Hedef belirleme maliyeti
        public List<string> log; // Log kayıtları
        public int[] targetedGoldCord; // Hedeflenen altının koordinatları 
        public int targetedGoldValue; // Hedeflenen altının değeri
        public int remainingSteps; // Hedefe kalan tur sayısı
        public int GoldEarnedOnReachTarget; //Hedefe ulaşıldığında alınacak kazanç
        public int[] moveCordValue;/*
            Oyuncu hareket ederken y ve x koordinatında hangi yöne ve kaç kare ilerledi.
            moveCordValue[0] => Negatif = Yukarı, Pozitif = Aşağı. Y koordinatında kaç adım ilerledi. 
            moveCordValue[1] => Negatif = Sol, Pozitif = Sağ. X koordinatında kaç adım ilerledi. 
        */
        public Player(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX)
        {
            this.name = name;
            this.cost = cost;
            this.moveLenght = moveLenght;
            this.searchCost = searchCost;
            SetPlayerGold(gold);
            this.targetedGoldCord = new int[2];
            this.moveCordValue = new int[2];
            this.SetTargetedGoldCord(-1, -1);
            this.targetedGoldValue = -1;
            log = new List<string>();
            SetLog(name + " oyuncusu Y: " + (cordY) + ", X: " + (cordX) + " kordinatından " + gold + " altın ile oyuna katıldı.");

            playerMap = new int[gameY, gameX];
            for (int i = 0; i < gameY; i++)
            {
                for (int k = 0; k < gameX; k++)
                {
                    playerMap[i, k] = 0;
                }
            }
            UpdateCord(cordY, cordX);
        }
        
        #region GET
        public int[,] GetPlayerMatris()
        {// Oyuncu matrisini (int) döndürür.
            return playerMap;
        }    
        public string GetPlayerMapString()
        {//Oyuncu matrisini(string) Consol için text olarak döndürür.
            string mapText = this.name + " oyuncusunun haritası \n";
            for (int y = 0; y < playerMap.GetLength(0); y++)
            {
                for (int x = 0; x < playerMap.GetLength(1); x++)
                {
                    mapText += " | " + playerMap[y, x];
                }
                mapText += " |\n";
            }
            return mapText;
        }
        public int GetPlayerGold()
        {//Oyuncunun kasasında bulunan altını döndürür.
            return this.gold;
        }
        public int GetGoldEarnedOnReachTarget()
        {//Hedeflenen altına ulaşıldığında elde edeceği kar değerini döndürür.
            return GoldEarnedOnReachTarget;
        }
        public int[] GetLastCord()
        {//Oyuncunun oyun alanında bulunduğu son konumu döndürür.
            int[] cord = { this.lastYCord, this.lastXCord };
            return cord;
        }
        public int GetSearchCost()
        {//Hedef belirleme maliyetini döndürür.
            return this.searchCost;
        }
        public int GetRemainingSteps()
        {//Oyuncunun hedefine kalan hamle sayısını döndürür.
            return this.remainingSteps;
        }
        public List<string> GetLog()
        {//Oyuncunun oyun sırasında yaptığı tüm işlemlerin kaydını döndürür.
            return this.log;
        }
        public int[] GetTargetedGoldCord()
        {//Hedeflenen altının bulunduğu koordinatı döndürür.
            return this.targetedGoldCord;
        }
        public int GetTargetedGoldValue()
        {//Hedeflenen altının değerini döndürür.
            return this.targetedGoldValue;
        }
        public int[] GetMoveCordValue()
        {
            return moveCordValue;
        }
        #endregion

        #region SET
        public void SetPlayerGold(int gold)
        {//Oyuncunun kasasında bulunan altını belirler.
            this.gold = gold;
        }
        public void SetLog(string log)
        {//Oyuncunun hareketlerini listeye ekler.
            this.log.Add(log);
        }
        public void SetGoldEarnedOnReachTarget(int gold)
        {//Hedeflenen altına ulaşıldığında elde edeceği kar değerini belirler.
            this.GoldEarnedOnReachTarget = gold;
        }
        public void SetRemainingSteps(int remainingSteps)
        {//Oyuncunun hedefine kalan hamle sayısını belirler.
            this.remainingSteps = remainingSteps;
        }
        public void SetTargetedGoldCord(int CordY, int CordX)
        {//Hedeflenen altının koordinatlarını belirler.
            this.targetedGoldCord[0] = CordY;
            this.targetedGoldCord[1] = CordX;
        }
        public void SetTargetedGoldValue(int goldValue)
        {//Hedeflenen altının değerini belirler.
            this.targetedGoldValue = goldValue;
        }
        public void SetMoveCordValue(int CordY, int CordX)
        {
            moveCordValue[0]=CordY;
            moveCordValue[1]=CordX;
        }
        public void SetPlayerMapValue(int CordY, int CordX,int data)
        {
            this.playerMap[CordY, CordX] = data;    
        }
        #endregion

        #region UPDATE
        public void UpdatePlayerGoldValue(int gold)
        {//Oyuncunun kasasındaki altına ekleme, çıkarma yapar. 
            this.gold += gold;
        }
        public void UpdateCord(int yCord, int xCord)
        {//Oyuncunun bulunduğu konumu belirler.
            this.playerMap[this.lastYCord, this.lastXCord] = 0;
            this.lastYCord = yCord;
            this.lastXCord = xCord;
            this.playerMap[this.lastYCord, this.lastXCord] = 1;
        }
        #endregion

        #region GAME FUNCTION
        public abstract void SearchForGold(IMap map);
        public void PrivateGoldShow(char duzlem, int hareket, IMap map)
        {
            if (duzlem == 'X')
            {   
                // -X yönünde
                if (hareket > 0)     
                {
                    for (int x = lastXCord; x >= lastXCord - Math.Abs(hareket); x--)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +X yönünde
                else if (hareket < 0)
                {
                    for (int x = lastXCord; x <= Math.Abs(hareket) + lastXCord; x++)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
            }
            else
            {
                // -Y yönünde
                if (hareket > 0)
                {
                    for (int y = lastYCord; y >= lastYCord - Math.Abs(hareket); y--)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +Y yönünde
                else if (hareket < 0)
                {
                    for (int y = lastYCord; y <= Math.Abs(hareket) + lastYCord; y++)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
            }
        }
        public void Move(IMap map)
        {
            int y=0, x=0;
            int tempGetTargetGoldValue = this.GetTargetedGoldValue();
            if (map.GetGoldCount() > 0)
            {
                if (this.GetTargetedGoldValue() == -1 || targetedGoldCord[0] == Int32.MaxValue)
                    this.SearchForGold(map);

                if (this.GetTargetedGoldValue() != -1)
                {
                    if (map.GetGoldPointValue(this.GetTargetedGoldCord()[0], this.GetTargetedGoldCord()[1]) == 0)
                    {
                        SetLog("Hedeflediği altın alınmış. Yeni altın hedefleniyor.");
                        SetGoldEarnedOnReachTarget(-1);
                        SetRemainingSteps(-1);
                        SetTargetedGoldCord(-1, -1);
                        SetTargetedGoldValue(-1);
                        map.SetPlayerRemainingSteps(-1, this.name);
                        map.SetPlayerTarget(-1, -1, this.name);
                        this.SearchForGold(map);
                    }
                }

                int targetY = targetedGoldCord[0];
                int targetX = targetedGoldCord[1];

                int targetYToPlayerY = lastYCord - targetY;                 //- ise kordinat büyür
                int targetXToPlayerX = lastXCord - targetX;                 // + ise kordinat küçülür

                /*
                 * Önce Yatayda eşitle
                 */
                int totalMoveLenght = moveLenght;                           //Oyuncunun toplam yapması gereken maksimum hamle
                int tempCordX = lastXCord, tempCordY = lastYCord;           // Hafızada tutulan X ve Y kordinatları

                if (Math.Abs(targetXToPlayerX) <= totalMoveLenght)           //Gitmesi gereken X kordinatı ile arasındaki mesafe toplam yapabileceği hareketten küçük eşit ise
                {
                    tempCordX = targetX;                                        //Gitmesi gereken kordinata git
                    totalMoveLenght -= Math.Abs(targetXToPlayerX);              //Aradaki hamle sayısını toplam hamle sayısı
                }
                else                                                         //Gitmesi gereken X kordinatı ile arasındaki mesafe toplam yapabileceği hareketten büyük ise
                {
                    if (targetXToPlayerX > 0) // +x                                 //Hedeflenen kordinat ile arasındaki fark 0'dan büyük ise
                    {
                        tempCordX -= totalMoveLenght;                                   //Hafızadaki X kordinatından tüm hareket hakkını çıkart.

                    }
                    else
                    {
                        tempCordX += totalMoveLenght;                                   //Hafızadaki X kordinatından tüm hareket hakkını ekle
                    }
                    totalMoveLenght = 0;                                                //Toplam adım hakkını 0 yap.
                }

                PrivateGoldShow('X', (lastXCord - tempCordX), map);                     //Düzlem, (gerçek konum - hedefe yaklaşan son konum)
                x = lastXCord - tempCordX;                                                                  //Gelen data - ise arttırcan
                UpdateCord(lastYCord, tempCordX);                                                                       //lastXCord = tempCordX;
                                                                                                                        //Gelen data + ise azaltacan
                if (totalMoveLenght > 0)                                                // hareket hakkı 0 dan büyükse
                {

                    if (Math.Abs(targetYToPlayerY) <= totalMoveLenght)                   //hedefe olan mesafe toplam gideceği hakka küçük esitse
                    {
                        tempCordY = targetY;                                              // tempy yi hedef y yap
                        totalMoveLenght -= Math.Abs(targetYToPlayerY);                    // hakkı güncelle
                    }
                    else
                    {                                                                    //hedefe olan mesafe toplam gideceği haktan büyükse
                        if (targetYToPlayerY > 0) // +x                                  // fark + ise çıkart
                        {
                            tempCordY -= totalMoveLenght;

                        }
                        else
                        {
                            tempCordY += totalMoveLenght;                               //fark - ise topla
                        }
                        totalMoveLenght = 0;                                            //hakkı 0la
                    }

                }
                PrivateGoldShow('Y', (lastYCord - tempCordY), map);                     //düzlem,(konum,hafıza konum)
                y = lastYCord - tempCordY;
                this.UpdateCord(tempCordY, tempCordX);                                  //cord güncelle

                this.SetMoveCordValue(y, x);
                
                //Şuanda ki hedef Y == Hedeflenen y 
                if (tempCordY == targetY && tempCordX == targetX)                       //hedefe ulaştıysa
                {
                    //Altını puan olarak ekle
                    this.UpdatePlayerGoldValue(GetTargetedGoldValue() - this.cost);
                    //Altını sil
                    map.RemoveGoldPoint(tempCordY, tempCordX);
                    //Hedeflemeyi boşalt
                    map.SetPlayerRemainingSteps(-1, this.name);
                    map.SetPlayerTarget(-1, -1, this.name);

                    this.SetTargetedGoldValue(-1);
                    this.SetRemainingSteps(-1);
                    this.SetTargetedGoldCord(-1, -1);
                    this.SetLog(this.name + " Hedefine ulaştı.");
                    //Oyuncu puanını düzenle
                }


                //bu benim ilk hareketim mi
                else
                {

                    map.SetPlayerRemainingSteps(map.GetPlayerRemainingSteps(this.name) - 1, this.name); //Oyuncunun adım sayısını 1 azalt
                    //UpdatePlayerGoldValue((-1) * this.cost);




                    int tempGetTargetGoldValue2 = this.GetTargetedGoldValue();
                    if (tempGetTargetGoldValue == tempGetTargetGoldValue2) // Bu benim ilk hareketim değil
                    {
                        //SetGoldEarnedOnReachTarget(GetGoldEarnedOnReachTarget() + ((-1) * this.cost));
                        UpdatePlayerGoldValue((-1) * this.cost);
                        this.SetLog(this.name + " Hedefine ulaşması için " + map.GetPlayerRemainingSteps(this.name) + " tur kaldi. Bu birden çok adımınız");
                    }
                    else
                    { // Bu benim ilk hareketim
                        //SetGoldEarnedOnReachTarget(GetGoldEarnedOnReachTarget() - (this.cost));
                        //UpdatePlayerGoldValue((-1) * (this.searchCost + this.cost));
                        UpdatePlayerGoldValue((-1) * (this.cost));
                        this.SetLog(this.name + " Hedefine ulaşması için " + map.GetPlayerRemainingSteps(this.name) + " tur kaldi. Bu ilk adımınız.");
                    }



                }
            }
        }
        public bool IsDeath()
        {
            if (GetPlayerGold() <= 0)
                return true;
            else
                return false;
        }
        #endregion

    }
}
