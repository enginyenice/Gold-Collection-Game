using AltınOyunuCSharp.Game.Map.Abstract;
using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public abstract class Player : IPlayer
    {
        public int totalNumberOfSteps; // Toplam adım sayısı
        public int totalAmountOfGoldSpent; // Toplam harcanan altın miktarı
        public int totalAmountOfGoldEarned; // Toplam kazanılan altın miktarı

        public int[,] playerMap;//Oyuncunun oyun alanındaki konumu
        public string name; //Oyuncu adı
        public int gold; // Oyuncunun sahip olduğu altın.
        public int startGold; // Oyuncunun sahip olduğu altın.
        public int moveLenght; //Bir turdaki(hamle) hareket uzunluğu
        public int lastYCord, lastXCord; // O an bulunduğu kordinat
        public int cost; //Hamle maliyeti
        public int searchCost; //Hedef belirleme maliyeti
        public List<string> log; // Log kayıtları
        public int[] targetedGoldCord; // Hedeflenen altının koordinatları
        public int targetedGoldValue; // Hedeflenen altının değeri
        public int remainingSteps; // Hedefe kalan tur sayısı
        public int GoldEarnedOnReachTarget; // Hedefe ulaşıldığında alınacak kazanç
        public int logCount = 0; // Log kayıt sayısı

        public Player(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX)
        {
            this.name = name;
            this.cost = cost;
            this.moveLenght = moveLenght;
            this.searchCost = searchCost;
            this.startGold = gold;
            this.totalAmountOfGoldEarned = 0;
            this.totalAmountOfGoldSpent = 0;
            this.totalNumberOfSteps = 0;

            SetPlayerGold(gold);
            this.targetedGoldCord = new int[2];
            this.SetTargetedGoldCord(-1, -1);
            this.targetedGoldValue = -1;
            log = new List<string>();
            SetLog("X: " + (cordY) + ", Y: " + (cordX) + " kordinatından " + gold + " altın ile oyuna katıldı.");

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
            this.log.Add((++logCount) + ")  " + log);
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
        {//Hareketler tersine idi onu düzelttim + ise o yünde artacak
            if (duzlem == 'X')
            {
                // -X yönünde
                if (hareket < 0)
                {
                    for (int x = lastXCord; x >= lastXCord - Math.Abs(hareket); x--)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("X:" + lastYCord + " Y:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +X yönünde
                else if (hareket > 0)
                {
                    for (int x = lastXCord; x <= Math.Abs(hareket) + lastXCord; x++)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("X:" + lastYCord + " Y:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
            }
            else
            {
                // -Y yönünde
                if (hareket < 0)
                {
                    for (int y = lastYCord; y >= lastYCord - Math.Abs(hareket); y--)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("X:" + y + " Y:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +Y yönünde
                else if (hareket > 0)
                {
                    for (int y = lastYCord; y <= Math.Abs(hareket) + lastYCord; y++)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("X:" + y + " Y:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
            }
        }

        public void Move(IMap map)
        {
            if (map.GetGoldCount() > 0)
            {
                //Eğer hedef belirlenmemiş ise hedef belirle
                if (this.GetTargetedGoldValue() == -1 || targetedGoldCord[0] == Int32.MaxValue)
                {
                    this.SearchForGold(map);
                }

                //Eğer hedef belirlenmiş ancak belirlenen hedef yerinde yoksa hedefi başka oyuncu almıştır
                //Yeni hedef belirle
                if (this.GetTargetedGoldValue() != -1)
                {
                    if (map.GetGoldPointValue(this.GetTargetedGoldCord()[0], this.GetTargetedGoldCord()[1]) == 0)
                    {
                        SetLog("Hedeflenen altın başka bir oyuncu tarafından alınmış.");
                        SetLog("Yeni altın hedefleniyor.");
                        SetGoldEarnedOnReachTarget(-1);
                        SetRemainingSteps(-1);
                        SetTargetedGoldCord(-1, -1);
                        SetTargetedGoldValue(-1);
                        map.SetPlayerRemainingSteps(-1, this.name);
                        map.SetPlayerTarget(-1, -1, this.name);
                        this.SearchForGold(map);
                    }
                }

                int targetY = targetedGoldCord[0]; //Hedef koordinatları
                int targetX = targetedGoldCord[1];

                // Hedef ile oyuncu konumu arasındaki, y ve x koordinatındaki uzaklık (kaç kare)
                int targetYToPlayerY = targetY - lastYCord;                 //- ise kordinat küçülür
                int targetXToPlayerX = targetX - lastXCord;                // + ise kordinat büyür

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
                    if (targetXToPlayerX > 0)                                  //Hedeflenen kordinat ile arasındaki fark 0'dan büyük ise
                    {//  +X
                        tempCordX += totalMoveLenght;                                   //Hafızadaki X kordinatından tüm hareket hakkını çıkart.
                    }
                    else
                    {//  -X
                        tempCordX -= totalMoveLenght;                                   //Hafızadaki X kordinatından tüm hareket hakkını ekle
                    }
                    totalMoveLenght = 0;                                                //Toplam adım hakkını 0 yap.
                }

                PrivateGoldShow('X', targetXToPlayerX, map);
                this.UpdateCord(lastYCord, tempCordX);                                                                       //lastXCord = tempCordX;
                                                                                                                             //Gelen data + ise azaltacan
                if (totalMoveLenght > 0)                                                // hareket hakkı 0 dan büyükse
                {
                    if (Math.Abs(targetYToPlayerY) <= totalMoveLenght)                   //hedefe olan mesafe toplam gideceği hakka küçük esitse
                    {
                        tempCordY = targetY;                                              // tempy yi hedef y yap
                    }
                    else
                    {                                                                    //hedefe olan mesafe toplam gideceği haktan büyükse
                        if (targetYToPlayerY > 0)                                   // fark + ise çıkart
                        {//  + Y
                            tempCordY += totalMoveLenght;
                        }
                        else
                        {//  - Y
                            tempCordY -= totalMoveLenght;
                        }
                    }
                }
                PrivateGoldShow('Y', targetYToPlayerY, map);
                this.UpdateCord(tempCordY, tempCordX);

                // Hedefe ulaşıldı mı?
                if (tempCordY == targetY && tempCordX == targetX)
                {
                    //Altını puan olarak ekle
                    this.UpdatePlayerGoldValue(GetTargetedGoldValue() - this.cost);
                    this.SetTotalAmountOfGoldEarned(GetTargetedGoldValue());
                    //Altını sil
                    map.RemoveGoldPoint(tempCordY, tempCordX);
                    //Hedeflemeyi boşalt
                    this.SetTargetedGoldValue(-1);
                    this.SetRemainingSteps(-1);
                    this.SetTargetedGoldCord(-1, -1);
                    this.SetLog("Hedefine ulaştı.");

                    map.SetPlayerRemainingSteps(-1, this.name);
                    map.SetPlayerTarget(-1, -1, this.name);
                }
                // Hedefe ulaşılamadıysa bilgileri güncelle
                else
                {
                    this.SetRemainingSteps(this.GetRemainingSteps() - 1);
                    map.SetPlayerRemainingSteps(map.GetPlayerRemainingSteps(this.name) - 1, this.name); //Oyuncunun adım sayısını 1 azalt
                    UpdatePlayerGoldValue((-1) * this.cost);
                    this.SetLog("Hedefine ulaşması için " + map.GetPlayerRemainingSteps(this.name) + " adım kaldı.");
                }
            }
            SetTotalAmountOfGoldSpent(this.cost);
            SetTotalNumberOfSteps(1);
        }

        public bool IsDeath()
        {
            if (GetPlayerGold() <= 0)
            {
                this.SetLog("Oyuncunun altını bitti ve elendi.");
                return true;
            }
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

        public void WriteToFile(string maptext)
        {
            CreateFolder();
            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "/GameLog/" + this.name + ".txt";
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.WriteLine("##### Oyun alanı altın dağılımı #####\r\n");
            sw.WriteLine("(!) 5: 5 değerinde altını ifade eder.  G-10: 10 değerinde gizli altını ifade eder.\r\n");
            sw.WriteLine(maptext); ;
            sw.WriteLine("##### Oyuncu Bilgileri #####");
            sw.WriteLine("Oyuncu adı                      : " + this.name);
            sw.WriteLine("Oyuncu hedef belirleme maliyeti : " + this.GetSearchCost());
            sw.WriteLine("Oyuncu adım maliyeti            : " + this.cost);
            sw.WriteLine("Oyuncu başlangıç altını         : " + this.startGold);
            sw.WriteLine("\r\n##### Oyun Sonucu #####");
            sw.WriteLine("Toplam adım sayısı              : " + this.GetTotalNumberOfSteps());
            sw.WriteLine("Toplam kazanılan altın          : " + this.GetTotalAmountOfGoldEarned());
            sw.WriteLine("Toplam harcanan altın           : " + this.GetTotalAmountOfGoldSpent());
            sw.WriteLine("Kasada bulunan altın            : " + this.GetPlayerGold());
            sw.WriteLine("\r\n##### Oyun Bilgisi #####");
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