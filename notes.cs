using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_RESTfulApi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bir masaüstü uygulama var bunu web uygulamasına dönüştürmek istiyorum.Daha ulaşılabilir daha ölçeklenebilir olsun diye vs.
            //Bu çekirdek yazılım altyapısını dışarıya açmak için yetkili ya da yetkisiz(dışarıya açmak apiyi kullanacak bir cihaz / yazılımın ona erişebiliyor olması)
            //İyzico Paypal banka altyapısını eklemek için size bir erişim verilir. Bu erişimi api sayesinde veriyorlar.
            //Api yazılırken dökümantasyon oluşturmak çok önemlidir.
            //Eğer sunucu tarafında çalışan bir apiye bağlanılacaksa client işletim sisteminin önemi yoktur. Tarayıcı olduğu sürece apiye url üzerinden erişilebilir
            //Sadece internete bağlanıp istek gönderip cevap alacaksın.

            ///////////

            //API => Application Program Interface 
            //REST => REspresentational State Transfer 
            //Resource => API'den elde edilen bir veri parçasına denir.
            //Response => API'ye yapılan request sonucunda API'den dönen sonuca denir.

            //client => internet => api => web server => database
            //request olmadan responce olmaz.

            //Request temel olarak 4 parçadan oluşur 
            //Endpoint (ya da route)
            //HTTP Method => get post
            //Http Header => gönderilecek verinin formatını belirlemek için  => örn/application/json
            //Data (ya da body,message)

            //Endpoint/Route
            //Sorgu oluşturmak için kullanılan url'lere verilen isim.
            //Restful apilere urller üzerinden erişiriz.
            //Onun kurallarına ve dökümantastonuna göre bir url oluşturup onu request olarak göndeririz.
            //Bir diğer adı da route'dir. Endpoint uçnokta ve gidilmesi gereken noktadır. Apinin geliştiricileri tarafından oluşturulan uç noktalar.
            //Route uç nokta anlamıyla ve geliştiricinin istekleri oluşturma ve yönlendirme amacıyla da kullanılır yani 2 amaçlı.
            //Route ya da endpoint yerine base url de kullanılabilir. Baseurl daha çok kullanılır.
            //Path endpointin içindeki url parçasıdır.
            //Tam URL => www.simalbulbul.com/category/music
            //Route-Endpoint => www.simalbulbul.com/ - sonuna slash / koyarak bir endpoint olduğunu da belirtebiliriz.
            //Path => /category/music

            //Sorgu Parametreleri
            //Örnek sorgu parametresi => ?query1=value1&query2=value2
            //Sorgu parametreleri teknik olarak REST mimarisinin bir parçası değildir. Ama çok işlevsel ve sık kullanılır.
            //Soru işareti ile başlar
            //Birden fazla parametre art arda kullanılabilir ve her parametre diğerinden ampersand(&) ile ayrılır.


            //HTTP Method =>
            //Gerçekleştirilen HTTP çağrısının tipini sunucuya bildirmek için kullanılır.

            //GET => sunucudan kaynak almak için kullanılır. yani READ işlemi. url üzerinden gerçekleştirilir / okuma
            //POST => sunucuda yeni bir kaynak oluşturmak için kullanılır. yani CREATE işlemi.veri demiyoruz resource diyoruz. sunucuda oluşturlacak herhangi bi şeye denir.
            //PUT ve PATCH => Sunucuda kaynak güncellemek için kullanılır. yani UPDATE işlemi. güncelleme işleminin sonucunda da istemciye bildirilir.
            //DELETE => Sunucuda kaynak silmek için kullanılır. yani DELETE işlemi. silme işleminin sonucunda da istemciye bildirilir.

            //güncelleme işleminde delete işleminde de post kullanılması teknik olarak mümkündür. ama doğru bir yöntem değildir. design patterne aykırı

            //HEAD => GET ile aynı. sadece status line ve header bölümlerini aktarır.
            //      > sayfa var mı bilgisi ne ama içeriği verme
            //      > sana body(asıl içerik göndermez) sadece satus code ve başlık biligisini verir
            //      > ne zaman kullanılır
            //      > bu link çalışıyor mu??
            //      > dosya kaç mb?
            //      > sayfayı indirmeye gerek yok sadece kontrol et.

            //CONNECT => verilen url taradından tanımlanan sunucuya bir tünel oluşturur.
            //         > direkt “server’a bağ kur, arada tünel aç” demek.
            //         > Sen → Proxy → Asıl server
            //         > HTTPS sitelere proxy üzerinden girerken ve VPN / corporate network durumlarında

            //OPTIONS => hedef kaynak için iletişim seçeneklerini sağlar.
            //         > “sen neyi destekliyorsun?”
            //         > Server sana der ki: get / post / delete var mı CORS izni var mı?
            //         > frontend bir API’ye istek atmadan önce / CORS kontrolü sırasında (tarayıcı bunu otomatik yapar) 
            //         > yani “ sen ne özelliklere sahipsin?” sorgusu.

            //CORS KONTROLÜ => 
            //CORS kontrolü şudur: Tarayıcı, bir web sitesinin başka bir siteye API isteği atmasını güvenlik için kontrol eder. 
            //Yani sen siteA.com’dayken siteB.com’daki veriyi çekmek istiyorsan tarayıcı önce “bu site buna izin veriyor mu?” diye 
            //bakar. Eğer server izin verdiyse veriyi gösterir, izin vermediyse isteği engeller ve sana hata verir. Amaç, kötü 
            //sitelerin izinsiz şekilde başka sitelerden veri çekmesini veya işlem yapmasını engellemektir.


            //TRACE => hedef kaynağa giden yol boyunca message loop-back testi gerçekleştirir
            //       > sen bir request atıyorsun, server onu aynen geri gönderiyor.
            //       > “ben sana ne yolluyorum, sen onu bana birebir geri at”
            //       > çoğu yerde güvenlik nedeniyle kapalıdır, çünkü kötü niyetli kişiler bunu kullanabilir.
            //       > çoğunlukla debug/test veya request yolda değişiyor mu sorusunu gözlemlemek için kullanılır.


            //HTTP Header=>
            //Hem istemci hem sunucuya bilgi sağlamak için kullanılır.
            //HTTP başlıkları Property-Value pairs yöntemiyle tutulur. (key value mantığı)
            //Örnek = Content-Type: application/json
            


        }
    }
}
