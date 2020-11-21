using AltınOyunuCSharp.Game.Map.Abstract;
using AltınOyunuCSharp.Game.Player.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace AltınOyunuCSharp.Game.Player.Concrete
{
    public abstract class Player : IPlayer
    {
        protected int totalNumberOfSteps; // Toplam adım sayısı
        protected int totalAmountOfGoldSpent; // Toplam harcanan altın miktarı
        protected int totalAmountOfGoldEarned; // Toplam kazanılan altın miktarı

        protected int[,] playerMap;//Oyuncunun oyun alanındaki konumu
        protected string name; //Oyuncu adı
        protected int gold; // Oyuncunun sahip olduğu altın.
        protected int startGold; // Oyuncunun sahip olduğu altın.
        protected int moveLenght; //Bir turdaki(hamle) hareket uzunluğu
        protected int lastYCord, lastXCord; // O an bulunduğu kordinat
        protected int cost; //Hamle maliyeti
        protected int searchCost; //Hedef belirleme maliyeti
        protected List<string> log; // Log kayıtları
        protected int[] targetedGoldCord; // Hedeflenen altının koordinatları
        protected int targetedGoldValue; // Hedeflenen altının değeri
        protected int remainingSteps; // Hedefe kalan tur sayısı
        protected int GoldEarnedOnReachTarget; // Hedefe ulaşıldığında alınacak kazanç
        protected int logCount = 0; // Log kayıt sayısı

        protected int howManyGoldToShow = -1; //Oyuncunun hamle başı kaç adet gizli altın açacağı

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
            this.gold = gold;
            this.targetedGoldCord = new int[2];
            this.SetTargetedGoldCord(-1, -1);
            this.targetedGoldValue = -1;
            log = new List<string>();
            //SetLog("Y: " + (cordY) + ", X: " + (cordX) + " kordinatından " + gold + " altın ile oyuna katıldı.");
            SetLog("X: " + (cordX) + " Y: " + (cordY) + " kordinatından " + gold + " altın ile oyuna katıldı.");

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

        public string GetName()
        {
            return this.name;
        }

        public int GetTotalNumberOfSteps()
        {// Oyuncunun oyun boyunca toplam hamle sayısı
            return this.totalNumberOfSteps;
        }

        public int GetTotalAmountOfGoldSpent()
        {// Oyuncunun oyun boyunca harcadığı toplam altın
            return this.totalAmountOfGoldSpent;
        }

        public int GetTotalAmountOfGoldEarned()
        {// Oyuncunun oyun boyunca kazandığı toplam altın
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
        {// Oyuncunun oyun boyunca yaptığı toplam hamle değerini arttırır.
            this.totalNumberOfSteps += value;
        }

        public void SetTotalAmountOfGoldSpent(int value)
        {// Oyuncunun oyun boyunca harcadığı toplam altın değerini arttırır.
            this.totalAmountOfGoldSpent += value;
        }

        public void SetTotalAmountOfGoldEarned(int value)
        {// Oyuncunun oyun boyunca kazandığı toplam altın değerini arttırır.
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
        {// Oyuncu konumunu tutan haritada girilen koordinattaki değeri belirler.
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

        //Hedef belirleme, altın arama

        public void PrivateGoldShow(char cord, int move, IMap map)
        {// Yapınlan hareketin sonucunda gidilen yol üzerinde gizli altın bulunuyor ise onu görünür hale geririr.
         // cord: Hangi düzlemde hareket yapılacak
         // move: Kaç kare hareket edilecek

            if (cord == 'X')
            {
                // -X yönünde
                if (move < 0)
                {
                    for (int x = lastXCord; x >= lastXCord - Math.Abs(move); x--)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            //this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                            this.SetLog("X:" + x + " Y:" + lastYCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +X yönünde
                else if (move > 0)
                {
                    for (int x = lastXCord; x <= Math.Abs(move) + lastXCord; x++)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.UpdateGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            //this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                            this.SetLog("X:" + x + " Y:" + lastYCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
            }
            else
            {
                // -Y yönünde
                if (move < 0)
                {
                    for (int y = lastYCord; y >= lastYCord - Math.Abs(move); y--)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            //this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                            this.SetLog("X:" + lastXCord + " Y:" + y + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                // +Y yönünde
                else if (move > 0)
                {
                    for (int y = lastYCord; y <= Math.Abs(move) + lastYCord; y++)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.UpdateGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            //this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                            this.SetLog("X:" + lastXCord + " Y:" + y + " kordinatındaki gizli altın açıldı.");
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

                // Önce Yatayda eşitleme
                int totalMoveLenght = moveLenght;                       // Oyuncunun toplam yapması gereken 1 hamledeki adım sayısı
                int tempCordX = lastXCord, tempCordY = lastYCord;       // Oyuncunun son konumunu geçici bir değişkene atama

                if (Math.Abs(targetXToPlayerX) <= totalMoveLenght)
                {// Yatayda gitmesi gereken hareket, bir turda yapabileceği
                 //maksimum hareket sayısından küçük veya eşit ise
                    tempCordX = targetX;
                    totalMoveLenght -= Math.Abs(targetXToPlayerX);      // Gidilen hareket sayısını toplam hareket sayısından düş
                }
                else
                {// Yatayda gitmesi gereken hareket, bir turda yapabileceği
                 //maksimum hareket sayısından büyük ise
                    if (targetXToPlayerX > 0)//  Hedef altına hareket pozitif yönde ise
                    {//  +X
                        tempCordX += totalMoveLenght;
                    }
                    else                     //  Hedef altına hareket negatif yönde ise
                    {//  -X
                        tempCordX -= totalMoveLenght;
                    }
                    // Bir turda gidilecek maksimun hareket yapıldığından bu tur için kalan hareketi sıfırla
                    totalMoveLenght = 0;
                }

                PrivateGoldShow('X', targetXToPlayerX, map);// Gidilen yolda gizli altın var ise görünür yap
                this.UpdateCord(lastYCord, tempCordX);// Oyuncunun konumunu güncelle

                // Yatayda yapılan hareketten sonra kalan adım var ise veya
                //yatayda hiç hareket edilmemiş ise dikeyde hareket yap
                if (totalMoveLenght > 0)
                {
                    if (Math.Abs(targetYToPlayerY) <= totalMoveLenght)
                    {// Dikeyde gitmesi gereken hareket, bir turda yapabileceği
                     //maksimum hareket sayısından küçük veya eşit ise
                        tempCordY = targetY;
                    }
                    else
                    {// Dikeyde gitmesi gereken hareket, bir turda yapabileceği
                     //maksimum hareket sayısından büyük ise                                                               //hedefe olan mesafe toplam gideceği haktan büyükse
                        if (targetYToPlayerY > 0)//  Hedef altına hareket pozitif yönde ise
                        {//  + Y
                            tempCordY += totalMoveLenght;
                        }
                        else                     //  Hedef altına hareket negatif yönde ise
                        {//  - Y
                            tempCordY -= totalMoveLenght;
                        }
                    }
                }
                PrivateGoldShow('Y', targetYToPlayerY, map);// Gidilen yolda gizli altın var ise görünür
                this.UpdateCord(tempCordY, tempCordX);// Oyuncunun konumunu güncelle

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
            sw.WriteLine("(!) Yatay düzlem [X] ve Dikey Düzlem [Y] Olarak adlandırılmaktadır.\r\n");
            sw.WriteLine(maptext); ;
            sw.WriteLine("##### Oyuncu Bilgileri #####");
            sw.WriteLine("Oyuncu adı                      : " + this.name);
            sw.WriteLine("Oyuncu hedef belirleme maliyeti : " + this.GetSearchCost());
            sw.WriteLine("Oyuncu adım maliyeti            : " + this.cost);
            sw.WriteLine("Oyuncu başlangıç altını         : " + this.startGold);
            if (howManyGoldToShow != -1)
                sw.WriteLine("Oyuncunun sırası geldiğinde açacağı gizli altın sayısı         : " + this.howManyGoldToShow);
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