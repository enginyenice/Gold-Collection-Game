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