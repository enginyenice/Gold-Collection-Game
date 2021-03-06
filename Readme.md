## T.C.
## KOCAELİ ÜNİVERSİTESİ
## BİLGİSAYAR MÜHENDİSLİĞİ
## YAZILIM LABORATUVARI-1 PROJE -1 
## ALTIN TOPLAMA OYUNU
## CEMRE CAN KAYA - 190201137
## ENGİN YENİCE - 190201133
---


### PROJE HAKKINDA
---
Oyun C# Programlama dili kullanılarak nesne tabanlı programlama mantığı ile geliştirildi. Oyun kullanıcının belirlediği m x n karelik bir oyun alanında ve belirlenen kurallara göre bir simülasyon şeklinde çalışmaktadır. Kullanıcı oyun alanının boyutunu ve oyuncuların özelliklerini belirledikten sonra oyun başlatılır oyun sonunda oyuncuların tüm hareketleri ve tüm bilgileri ekrana tablo olarak yansıtılır. Bu bilgiler her kullanıcı için ayrı ayrı dosyalara yazdırılır.	
### TESLİM EDİLEN DOSYALAR VE İÇERİKLERİ
---

|Dosya Adı| İçerik  |
|--|--|
|  YazLab-1-Proje-1.pdf  | [Proje Detayları](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/D%C3%B6k%C3%BCmanlar/YazLab-1-Proje-1.pdf) |
|  190201137-190201133-Rapor.pdf  | [Projenin raporu](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/Proje%20Teslim%20Dosyalar%C4%B1/190201137-190201133-Rapor.pdf) |
|  190201137-190201133-Kaba-Kod.pdf  | [Proje içerisinde yazıların kodların kaba kod çıktıları](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/Proje%20Teslim%20Dosyalar%C4%B1/190201137-190201133-Kaba-Kod.pdf) |
|  190201137-190201133.zip  | [Proje dosyalarının bulunduğu zip dosyası](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/Proje%20Teslim%20Dosyalar%C4%B1/190201137-%20190201133-Proje.zip) ||
|  190201137-190201133-Tüm-Kodlar.txt | [Projenin tüm kodlarının kopyalandığı metin belgesi](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/Proje%20Teslim%20Dosyalar%C4%B1/190201137-190201133.txt) |
|  readme.txt  | [Projenin nasıl çalıştırılacağı ve önemli notların bulunduğu metin belgesi](https://github.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/blob/master/D%C3%B6k%C3%BCmanlar/Proje%20Teslim%20Dosyalar%C4%B1/readme.txt)	


---
### PROJE NASIL ÇALIŞTIRILIR
 Projeyi çalıştırmak için 2 farklı yol izleyebilirsiniz.	

 1. AltınOyunuCSharp\bin\Debug klasörü altında bulunan
    AltınOyunuCSharp.exe uygulaması ile çalıştırabilirsiniz.
    
 2. Proje dizini içerisindeki AltınOyunuCSharp.sln proje dosyasını açarak visual studio programından projeyi başlatabilirsiniz.
 3. Proje dizini içerisindeki 190201137-190201133-Exe klasörü altındaki Altın-Toplama-Oyunu.exe uygulamasını çalıştırarak oyuna erişebilirsiniz.

### OYUN SONU OYUNCU KAYITLARI
 Oyun tamamlandığında oyuncuların hareket kayıtları AltınOyunuCSharp.exe uygulaması ile aynı dizinde oluşturulan GameLog klasörü içerisinde her oyuncunun kendisine ait kayıtlarının bulunduğu .txt uzantılı metin belgelerine kayıt edilmektedir.
|Oyuncu| Dosya  |
|--|--|
| A Oyuncusu | A.txt |
| B Oyuncusu | B.txt |
| C Oyuncusu | C.txt |
| D Oyuncusu | D.txt |

# Önemli Notlar

 - Üstünden geçilen altın
	 - Gizliyse görünür olacak
	 - Görünürse alınmadan devam edecek.
 - Hedefe 3 adımdan erken ulaşılıyorsa ulaşıldığı adımda duracak.
 - C Oyuncusu her hamlesine başlamadan önce **varsayılan** olarak 2 adet gizli altını görünür hale getirecek.
 - Hedef dışında bir altının üzerinde durulursa o altın alınmayacak.
 - C Oyuncusu gizli altınları  kendine yakın olandan uzak olana doğru açmaya başlayacak.
 - Adım sayısı **varsayılan** olarak 3 olarak belirlenmiştir.
 - Altını biten oyuncu oyundan ayrılır.
 - Tüm oyuncuların hareketleri kayıt edilecektir.
 - Aynı kare üzerinde 2 oyuncu durabilir yada **duramaz** (kriter değil kendi tercihimiz)
 - Tüm **görünür** altınlar biterse oyun biter.
 - Sadece hedeflenen altın alınabilir. Üzerinden geçilen altınları alıp almamak bize kalmış bir durum. **Tercihen Almamalı**
 - Görünür duruma dönen gizli altınlar tüm kullanıcılar tarafından görünür.
 - Sırası geldiğinde hedefi yoksa eğer hedef belirler. Hedefi varsa hedefini alana kadar hedefine devam eder.
 - Maliyet **varsayılan** olarak 5
 - Oyuncu oyuncunun üzerinden geçebilir.
 - Gizli altınlar ile görünür altınlar ayrı konumlarda olacaktır.
	 - Görünür altınların %10 varsayılan kadar gizli altın oluşturulacaktır. **Örneğin: 10x10 bir oyun alanımız olsun. Görünür altın oranımız %20 gizli altın oranımızın da %10 olduğunu varsayalım. Oyunda toplam (100x20)/100 = 20 adet altın olmalıdır. Bu altınların (20x10)/100 = 2 tanesi gizli altın olmalıdır. O zaman oyunda: 18 Adet görünür 2 adet gizli altın bulunması gerekmektedir.*
 - 0 adımlık hamle yok. Hamle sayılabilmesi için en az 1 adım atmak zorundadır.

***

## Önemli Not: *Varsayılan yazan tüm parametreler değiştirilebilir olmalıdır.*

***

## Oyun Ekranından Kareler

###  Genel Ayarlar
![Genel Ayarlar](https://raw.githubusercontent.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/master/D%C3%B6k%C3%BCmanlar/Resimler/GenelAyarlar.png)

### Oyun Ekranı
![Oyun](https://raw.githubusercontent.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/master/D%C3%B6k%C3%BCmanlar/Resimler/OyunEkran%C4%B1.png)

### Oyun Sonu Ekranı
![Oyun Sonu](https://raw.githubusercontent.com/enginyenice/Altin-Toplama-Oyunu-YazLab-1-Proje-1/master/D%C3%B6k%C3%BCmanlar/Resimler/ScoreBoard.png)
