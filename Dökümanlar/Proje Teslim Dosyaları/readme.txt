					 _______________________________________
					|		  T.C.			|
					|	   KOCAELİ ÜNİVERSİTESİ 	|
					|	  MÜHENDİSLİK FAKÜLTESİ 	|
					|        BİLGİSAYAR MÜHENDİSLİĞİ	|
					|_______________________________________|
					|    YAZILIM LABORATUVARI-1 PROJE -1	|
					|	  ALTIN TOPLAMA OYUNU		|
					|_______________________________________|
					|	ENGİN YENİCE - 190201133	|
					|	CEMRE CAN KAYA - 190201137	|
					|_______________________________________|



 _______________________________________________________________________________________________________________________________
|PROJE HAKKINDA															|
|																|
|Oyun C# Programlama dili kullanılarak nesne tabanlı programlama mantığı ile geliştirildi. Oyun kullanıcının belirlediği m x n 	|
|karelik bir oyun alanında ve belirlenen kurallara göre bir simülasyon şeklinde çalışmaktadır. Kullanıcı oyun alanının boyutunu |
|ve oyuncuların özelliklerini belirledikten sonra oyun başlatılır oyun sonunda oyuncuların tüm hareketleri ve tüm bilgileri 	|
|ekrana tablo olarak yansıtılır. Bu bilgiler her kullanıcı için ayrı ayrı dosyalara yazdırılır.					|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|TESLİM EDİLEN DOSYALAR VE İÇERİKLERİ												|
|																|
|190201137-190201133-Rapor.pdf      : Projenin raporu										|
|190201137-190201133-Kaba-Kod.pdf   : Proje içerisinde yazıların kodların kaba kod çıktıları					|
|190201137-190201133-Proje.zip	    : Proje dosyalarının bulunduğu zip dosyası							|
|Altın Oyunu Exe		    : Projenin exe olarak çalıştırılabilir hali bulunmaktadır.					|
|190201137-190201133.txt 	    : Projenin tüm kodlarının kopyalandığı metin belgesi					|	
|readme.txt	    		    : Projenin nasıl çalıştırılacağı ve önemli notların bulunduğu metin belgesi			|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|PROJE NASIL ÇALIŞTIRILIR													|
|																|
|Projeyi çalıştırmak için 3 farklı yol izleyebilirsiniz.									|
|																|
|1-)Altın Oyunu Exe klasörü içerisindeki Altın Oyunu.exe uygulaması ile çalıştırabilirsiniz.					|
|2-)AltınOyunuCSharp\bin\Debug klasörü altında bulunan AltınOyunuCSharp.exe uygulaması ile çalıştırabilirsiniz.			|
|3-)Proje dizini içerisindeki AltınOyunuCSharp.sln proje dosyasını açarak visual studio programından projeyi başlatabilirsiniz.	|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|(!!)ÖNEMLİ NOT:													    (!!)|
|Oyuncu hareketleri önce yatay düzlemde(X) tamamlanır. Ardından dikey düzlemde(Y) tamamlanır.					|
|Örneğin:															|
|X:0 Y:0 koordinatında bulunan bir oyuncunun X:3 Y:3 koordinatına gidebilmesi için						|
| ->Oyuncu önce yatay düzlemde (X koordinatında) 3 birim hareket eder. 								|
| ->Ardından dikey düzlemde (Y koordinatında) 3 birim hareket eder.								|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|PROJE NASIL KULLANILIR														|
|Program başlatıldığında ilk olarak tüm oyun ayarlarınının düzenleneceği bir form ekranı karşınıza çıkmaktadır.			|
|																|
|Oyun ayarlarını belirledikten sonra 												|
|->Oyunu Başlat butonuna tıklayarak oyun ekranına geçebilirsiniz.								|
|->Oyunu Kapat butonuna tıklayarak programı sonlandırabilirsiniz								|
|																|
|Oyun ekranına geldiğinizde													|
|->Gizli altınları harita üzerinde göstermek için Gizli altınları göster butonuna tıklayabilirsiniz				|
|->Gizli altınları harita üzerinde gizlemek için Gizli altınları gizle butonuna tıklayabilirsiniz				|
|->Oyunu başlat butonuna tıklayarak oyunun otomatik bir şekilde oynamasını sağlayabilirsiniz.					|
|->Oyunu durdur butonuna tıklayarak başlamış bir oyunu durdurabilirsiniz.							|
|->Timer Interval özelliği ile oyunun hızını arttırabilir veya azaltabilirsiniz.						|
|->Tur butonu ile oyuncuların hamlelerini adım adım oynatabilirsiniz. (Her tıklama 1 oyuncunun hamlesini gerçekleştirir)	|
|_______________________________________________________________________________________________________________________________|

 _______________________________________________________________________________________________________________________________
|OYUN SONU OYUNCU KAYITLARI													|
|																|
|Oyun tamamlandığında oyuncuların hareket kayıtları AltınOyunuCSharp.exe uygulaması ile aynı dizinde oluşturulan GameLog klasörü|
|içerisinde her oyuncunun kendisine ait kayıtlarının bulunduğu .txt uzantılı metin belgelerine kayıt edilmektedir.		|
|																|
|A Oyuncusu => A.txt														|
|B Oyuncusu => B.txt														|
|C Oyuncusu => C.txt														|
|D Oyuncusu => D.txt														|
|_______________________________________________________________________________________________________________________________|
