using AltınOyunuCSharp.Game.Map.Abstract;
using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public abstract class Player : IPlayer
    {
        public int totalNumberOfSteps; // toplam adım sayısı
        public int totalAmountOfGoldSpent; // toplam harcanan altın miktarı
        public int totalAmountOfGoldEarned; // toplam kazanılan altın miktarı

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

            this.totalAmountOfGoldEarned = 0;
            this.totalAmountOfGoldSpent = 0;
            this.totalNumberOfSteps = 0;

            SetPlayerGold(gold);
            this.targetedGoldCord = new int[2];
            this.moveCordValue = new int[2];
            this.SetTargetedGoldCord(-1, -1);
            this.targetedGoldValue = -1;
            log = new List<string>();
            SetLog("Y: " + (cordY) + ", X: " + (cordX) + " kordinatından " + gold + " altın ile oyuna katıldı.");

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

        /*
         public int totalNumberOfSteps; // toplam adım sayısı
        public int totalAmountOfGoldSpent; // toplam harcanan altın miktarı
        public int totalAmountOfGoldEarned; // toplam kazanılan altın miktarı
        */

        public int GetTotalNumberOfSteps()
        {
            return this.totalNumberOfSteps;
        }

        public int GetTotalAmountOfGoldSpent()
        {
            return this.totalAmountOfGoldSpent;
        }

        public int GetTotalAmountOfGoldEarned()
        {
            return this.totalAmountOfGoldEarned;
        }

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

        #endregion GET

        #region SET

        public void SetTotalNumberOfSteps(int value)
        {
            this.totalNumberOfSteps += value;
        }

        public void SetTotalAmountOfGoldSpent(int value)
        {
            this.totalAmountOfGoldSpent += value;
        }

        public void SetTotalAmountOfGoldEarned(int value)
        {
            this.totalAmountOfGoldEarned += value;
        }

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
            moveCordValue[0] = CordY;
            moveCordValue[1] = CordX;
        }

        public void SetPlayerMapValue(int CordY, int CordX, int data)
        {
            this.playerMap[CordY, CordX] = data;
        }

        #endregion SET

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

        #endregion UPDATE

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
            int y = 0, x = 0;
            int tempGetTargetGoldValue = this.GetTargetedGoldValue();
            if (map.GetGoldCount() > 0)
            {
                if (this.GetTargetedGoldValue() == -1 || targetedGoldCord[0] == Int32.MaxValue)
                {
                    this.SearchForGold(map);
                    this.SetTotalAmountOfGoldSpent(this.GetSearchCost());
                }

                if (this.GetTargetedGoldValue() != -1)
                {
                    if (map.GetGoldPointValue(this.GetTargetedGoldCord()[0], this.GetTargetedGoldCord()[1]) == 0)
                    {
                        SetLog("Hedeflenen altın başka bir oyuncu tarafından alınmıştır. Yeni altın hedefleniyor.");
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
                    this.SetTotalAmountOfGoldEarned(GetTargetedGoldValue());
                    //Altını sil
                    map.RemoveGoldPoint(tempCordY, tempCordX);
                    //Hedeflemeyi boşalt
                    map.SetPlayerRemainingSteps(-1, this.name);
                    map.SetPlayerTarget(-1, -1, this.name);

                    this.SetTargetedGoldValue(-1);
                    this.SetRemainingSteps(-1);
                    this.SetTargetedGoldCord(-1, -1);
                    this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
                    this.SetLog("Hedefine ulaştı.");
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
                        this.SetLog("Hedefini önceden belirlediği için hedef belirleme maliyeti alınmadı.");
                        this.SetLog("Hedefine ulaşması için " + map.GetPlayerRemainingSteps(this.name) + " adım kaldı.");
                    }
                    else
                    { // Bu benim ilk hareketim
                        //SetGoldEarnedOnReachTarget(GetGoldEarnedOnReachTarget() - (this.cost));
                        //UpdatePlayerGoldValue((-1) * (this.searchCost + this.cost));
                        UpdatePlayerGoldValue((-1) * (this.cost));
                        this.SetLog("Hedef belirlemek için " + this.GetSearchCost() + " altın harcadı.");
                        this.SetLog("Hedefine ulaşması için " + map.GetPlayerRemainingSteps(this.name) + " adım kaldı.");
                    }
                }
            }

            SetTotalAmountOfGoldSpent(this.cost);
            SetTotalNumberOfSteps(1);
        }

        public bool IsDeath()
        {
            if (GetPlayerGold() <= 0)
                return true;
            else
                return false;
        }

        #endregion GAME FUNCTION

        #region WRITE TXT

        public void CreateFolder()
        {
            bool Kontrol = Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/GameLog");//Exists klasör yolu verilen dizin i kontrol edip true veya false döner
            if (Kontrol == false)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/GameLog");
            }
        }

        public void WriteToFile()
        {
            CreateFolder();
            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "/GameLog/" + this.name + ".txt";
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.WriteLine("#####Oyuncu Bilgileri#####");
            sw.WriteLine("Oyuncu adı                      : " + this.name);
            sw.WriteLine("Oyuncu hedef belirleme maliyeti : " + this.GetSearchCost());
            sw.WriteLine("Oyuncu adım maliyeti            : " + this.cost);
            sw.WriteLine("-Oyun Sonucu-");
            sw.WriteLine("Toplam adım sayısı              : " + this.GetTotalNumberOfSteps());
            sw.WriteLine("Toplam kazanılan altın          : " + this.GetTotalAmountOfGoldSpent());
            sw.WriteLine("Toplam karcanan altın           : " + this.GetTotalAmountOfGoldEarned());
            sw.WriteLine("Kasada bulunan altın            : " + this.GetPlayerGold());
            sw.WriteLine("#####Oyun Bilgisi#####");
            foreach (var item in this.GetLog())
            {
                sw.WriteLine(item);
            }

            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.
        }

        #endregion WRITE TXT
    }
}