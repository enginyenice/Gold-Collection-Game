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
        public int[,] playerMap;
        public int gold; // Oyuncunun sahip olduğu altın.
        public List<string> log; // Log kayıtları
        public int lastYCord, lastXCord; // O an bulunduğu kordinat
        public int[] targetedGold; // 0-> Y | 1->X
        public int targetGoldValue; // Hedefteki Altın Değeri
        public int remainingSteps; // Hedefe kalan adım sayısı
        public int cost; //Maliyet
        public int moveLenght; //Hareket uzunluğu
        public int searchCost; //Hedef belirleme maliyeti
        public string name; //Oyuncu Adı
        public int hedefeVardigindaAlacagiToplamPuan;


        public Player(int gold, string name, int cordY, int cordX, int cost, int moveLenght, int searchCost, int gameY, int gameX)
        {
            this.targetedGold = new int[2];
            this.SetTargetedGold(-1, -1);
            this.targetGoldValue = -1;
            this.cost = cost;
            this.moveLenght = moveLenght;
            this.searchCost = searchCost;
            SetGold(gold);
            this.name = name;
            log = new List<string>();
            SetLog(name + " oyuncusu Y:" + (cordY) + ", X:" + (cordX) + " kordinatından " + gold + " altın ile oyuna katıldı.");


            playerMap = new int[gameY, gameX];
            for (int i = 0; i < gameY; i++)
            {
                for (int k = 0; k < gameX; k++)
                {
                    playerMap[i, k] = 0;
                }
            }
            CordUpdate(cordY, cordX);



        }

        public int[,] GetPlayerMatris()
        {
            return playerMap;
        }

        public void UpdatePlayerGoldValue(int gold)
        {
            this.gold += gold;
        }
        public int GetPlayerGoldValue()
        {
            return this.gold;
        }

        public void SetHedefeVardigindaAlacagiToplamPuan(int gold)
        {
            this.hedefeVardigindaAlacagiToplamPuan = gold;
        }

        public int GetHedefeVardigindaAlacagiToplamPuan()
        {
            return hedefeVardigindaAlacagiToplamPuan;
        }


        public void PrivateGoldShow(char duzlem, int hareket, IMap map)
        {
            if (duzlem == 'X')
            {
                if (hareket > 0) //-x
                {
                    //hareket = 2
                    //X = 0
                    
                    for (int x = lastXCord; x >= lastXCord - Math.Abs(hareket); x--)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.AddGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                else if (hareket < 0)//+x
                {//////////////////
                    for (int x = lastXCord; x <= Math.Abs(hareket) + lastXCord; x++)
                    {
                        if (map.GetPrivateGoldMap()[lastYCord, x] != 0)
                        {
                            map.AddGoldMapPoint(lastYCord, x, map.GetPrivateGoldMap()[lastYCord, x]);
                            map.RemovePrivateGoldPoint(lastYCord, x);
                            this.SetLog("Y:" + lastYCord + " X:" + x + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }



            }
            else
            {


                if (hareket > 0)
                {
                    for (int y = lastYCord; y >= lastYCord - Math.Abs(hareket); y--)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.AddGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }
                else if (hareket < 0)//+y
                {
                    //for (int x = lastXCord;x< Math.Abs(hareket)+lastXCord;x++)
                    for (int y = lastYCord; y <= Math.Abs(hareket) + lastYCord; y++)
                    {
                        if (map.GetPrivateGoldMap()[y, lastXCord] != 0)
                        {
                            map.AddGoldMapPoint(y, lastXCord, map.GetPrivateGoldMap()[y, lastXCord]);
                            map.RemovePrivateGoldPoint(y, lastXCord);
                            this.SetLog("Y:" + y + " X:" + lastXCord + " kordinatındaki gizli altın açıldı.");
                        }
                    }
                }






            }
        }

        public void Move(IMap map)
        {

            int tempGetTargetGoldValue = this.GetTargetGoldValue();
            if (map.GetGoldCount() > 0)
            {
                if (this.GetTargetGoldValue() == -1 || targetedGold[0] == Int32.MaxValue)
                    this.SearchForGold(map);
                if(this.GetTargetGoldValue() != -1)
                {
                    if(map.GetGoldPoint(this.GetTargetedGold()[0], this.GetTargetedGold()[1]) == 0)
                    {
                        SetLog("Hedeflediği altın alınmış. Yeni altın hedefleniyor.");
                        SetHedefeVardigindaAlacagiToplamPuan(-1);
                        SetRemainingSteps(-1);
                        SetTargetedGold(-1, -1);
                        SetTargetGoldValue(-1);
                        map.SetOyuncuHedefeKalanAdim(-1,this.name);
                        map.SetOyuncuHedefi(-1, -1, this.name);
                        this.SearchForGold(map);
                    }


                }

                int targetY = targetedGold[0];
                int targetX = targetedGold[1];

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
                CordUpdate(lastYCord, tempCordX);                                                                       //lastXCord = tempCordX;
                                                                                        //Gelen data - ise arttırcan
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
                this.CordUpdate(tempCordY, tempCordX);                                  //cord güncelle
                
                    //Şuanda ki hedef Y == Hedeflenen y 
                if (tempCordY == targetY && tempCordX == targetX)                       //hedefe ulaştıysa
                {
                    //Altını puan olarak ekle
                    this.UpdatePlayerGoldValue(GetHedefeVardigindaAlacagiToplamPuan());
                    //Altını sil
                    map.RemoveGoldMapPoint(tempCordY, tempCordX);
                    //Hedeflemeyi boşalt
                    map.SetOyuncuHedefeKalanAdim(-1, this.name);
                    map.SetOyuncuHedefi(-1, -1, this.name);
                    
                    this.SetTargetGoldValue(-1);
                    this.SetRemainingSteps(-1);
                    this.SetTargetedGold(-1, -1);
                    this.SetLog(this.name + " Hedefine ulaştı");
                    //Oyuncu puanını düzenle
                }
                
                
                //bu benim ilk hareketim mi
                else
                {

                    map.SetOyuncuHedefeKalanAdim(map.GetOyuncuHedefeKalanAdim(this.name)-1, this.name); //Oyuncunun adım sayısını 1 azalt
                    //UpdatePlayerGoldValue((-1) * this.cost);

                    int tempGetTargetGoldValue2 = this.GetTargetGoldValue();
                    if(tempGetTargetGoldValue == tempGetTargetGoldValue2) // Bu benim ilk hareketim değil
                    {
                         SetHedefeVardigindaAlacagiToplamPuan(GetHedefeVardigindaAlacagiToplamPuan() + ((-1) * this.cost));
                        UpdatePlayerGoldValue((-1) * this.cost);
                        this.SetLog(this.name + " Hedefine ulaşması için " + map.GetOyuncuHedefeKalanAdim(this.name) + " kaldi. Bu birden çok adımınız");
                    } else
                    { // Bu benim ilk hareketim
                        SetHedefeVardigindaAlacagiToplamPuan(GetHedefeVardigindaAlacagiToplamPuan() - (this.cost + this.searchCost));
                        UpdatePlayerGoldValue((-1) * (this.searchCost + this.cost));
                       this.SetLog(this.name + " Hedefine ulaşması için "+map.GetOyuncuHedefeKalanAdim(this.name)+" kaldi. Bu ilk adımınız");
                    }

                }


            }



        }
        public string GetPlayerMap()
        {
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

        public void SetRemainingSteps(int remainingSteps)
        {
            this.remainingSteps = remainingSteps;
        }
        public void SetTargetedGold(int cordY, int cordX)
        {
            this.targetedGold[0] = cordY;
            this.targetedGold[1] = cordX;
        }
        public void CordUpdate(int yCord, int xCord)
        {
            this.playerMap[this.lastYCord, this.lastXCord] = 0;

            this.lastYCord = yCord;
            this.lastXCord = xCord;
            this.playerMap[this.lastYCord, this.lastXCord] = 1;

        }
        public int[] GetCord()
        {
            int[] cord = { this.lastYCord, this.lastXCord };
            return cord;
        }
        public int GetRemainingSteps()
        {
            return this.remainingSteps;
        }
        public int GetGold()
        {
            return this.gold;
        }
        public List<string> GetLog()
        {
            return this.log;
        }
        public bool IsDeath()
        {
            if (GetGold() <= 0)
                return true;
            else
                return false;

        }
        public abstract void SearchForGold(IMap map);
        public void SetGold(int gold)
        {
            this.gold = gold;
        }
        public void SetLog(string log)
        {
            this.log.Add(log);
        }
        public int[] GetTargetedGold()
        {
            return this.targetedGold;
        }
        public int GetTargetGoldValue()
        {
            return this.targetGoldValue;
        }
        public void SetTargetGoldValue(int goldValue)
        {
            this.targetGoldValue = goldValue;
        }
        public void SetSearchCost(int searchCost)
        {
            this.searchCost = searchCost;
        }
        public int GetSearchCost()
        {
            return this.searchCost;
        }
    }
}
