using KitapApi.Models;

namespace KitapApi.Services;

public interface IKitapService
{
    List<Kitap> HepsiniGetir(int sayfa, int limit);
    Kitap? IdIleGetir(int id);
    Kitap Ekle(Kitap yeniKitap);
    Kitap? Guncelle(int id, Kitap guncelKitap);
    bool Sil(int id);
    List<Kitap> YilaGoreFiltrele(int yil);
    List<Kitap> YazarAdinaGore(string yazarAdi);
    List<Kitap> FiyatAraliginaGore(double minFiyat, double maxFiyat);
    List<Kitap> KitapAdinaGore(string kitapAdi);

}