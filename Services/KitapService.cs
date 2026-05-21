using KitapApi.Models;

namespace KitapApi.Services;

public class KitapService : IKitapService
{
    private readonly List<Kitap> _kitaplar = new();
    private int _nextId = 1;

    public KitapService()
    {
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Python Programlama", Yazar = "Nilsu Gumrukçu", YayinYili = 2000, Fiyat = 49.99 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Asp.NET Core API", Yazar = "Nidanur Akbaş", YayinYili = 2023, Fiyat = 45.99 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "RESTful Tasarım", Yazar = "Şimal Bülbül", YayinYili = 2024, Fiyat = 39.50 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Veri Yapıları ve Algoritmalar", Yazar = "Ahmet Yıldırım", YayinYili = 2019, Fiyat = 79.90 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "C# ile Nesne Tabanlı Programlama", Yazar = "Elif Karaca", YayinYili = 2021, Fiyat = 64.50 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Modern Web Geliştirme", Yazar = "Burak Demir", YayinYili = 2022, Fiyat = 55.75 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "JavaScript Dünyası", Yazar = "Merve Aydın", YayinYili = 2020, Fiyat = 42.30 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Mikroservis Mimarisi", Yazar = "Can Özkan", YayinYili = 2024, Fiyat = 88.99 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "SQL ve Veritabanı Yönetimi", Yazar = "Fatma Kaya", YayinYili = 2018, Fiyat = 36.45 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Node.js Rehberi", Yazar = "Kaan Arslan", YayinYili = 2023, Fiyat = 51.20 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Temiz Kod Yazımı", Yazar = "Seda Polat", YayinYili = 2021, Fiyat = 70.00 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Yapay Zeka Temelleri", Yazar = "Deniz Ateş", YayinYili = 2025, Fiyat = 95.60 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Linux Sistem Yönetimi", Yazar = "Oğuz Erdem", YayinYili = 2017, Fiyat = 58.90 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Mobil Uygulama Geliştirme", Yazar = "Buse Şahin", YayinYili = 2022, Fiyat = 67.40 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "React ile Frontend", Yazar = "Tolga Keskin", YayinYili = 2023, Fiyat = 53.15 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Docker ve Kubernetes", Yazar = "Eren Çelik", YayinYili = 2024, Fiyat = 99.99 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Siber Güvenlik Rehberi", Yazar = "İrem Yılmaz", YayinYili = 2020, Fiyat = 61.80 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Unity ile Oyun Geliştirme", Yazar = "Kerem Tunç", YayinYili = 2021, Fiyat = 74.35 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Blazor Uygulamaları", Yazar = "Cem Aksoy", YayinYili = 2025, Fiyat = 82.25 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Makine Öğrenmesi", Yazar = "Zeynep Kurt", YayinYili = 2023, Fiyat = 91.10 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "API Güvenliği", Yazar = "Hasan Güneş", YayinYili = 2022, Fiyat = 47.95 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Entity Framework Core", Yazar = "Gamze Taş", YayinYili = 2024, Fiyat = 59.99 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Bulut Bilişim", Yazar = "Levent Kılıç", YayinYili = 2021, Fiyat = 73.45 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Redis ve Cache Sistemleri", Yazar = "Onur Kaplan", YayinYili = 2023, Fiyat = 68.70 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "ASP.NET MVC Projeleri", Yazar = "Ayşe Nur Koç", YayinYili = 2020, Fiyat = 44.90 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Go Programlama Dili", Yazar = "Emre Bulut", YayinYili = 2022, Fiyat = 66.60 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "Yazılım Test Süreçleri", Yazar = "Melis Doğan", YayinYili = 2019, Fiyat = 39.75 });
        _kitaplar.Add(new Kitap { Id = _nextId++, Baslik = "CI/CD ve DevOps", Yazar = "Furkan Çetin", YayinYili = 2025, Fiyat = 89.50 });

    }

    public List<Kitap> HepsiniGetir(int sayfa, int limit)
    {
        return _kitaplar.Skip((sayfa - 1) * limit).Take(limit).ToList();
    }

    public Kitap? IdIleGetir(int id)
    {
        return _kitaplar.FirstOrDefault(k => k.Id == id);
    }

    public Kitap Ekle(Kitap yeniKitap)
    {
        yeniKitap.Id = _nextId++;
        _kitaplar.Add(yeniKitap);
        return yeniKitap;
    }

    public Kitap? Guncelle(int id, Kitap guncelKitap)
    {
        var mevcut = IdIleGetir(id);
        if (mevcut is null) return null;

        mevcut.Baslik = guncelKitap.Baslik;
        mevcut.Yazar = guncelKitap.Yazar;
        mevcut.YayinYili = guncelKitap.YayinYili;
        mevcut.Fiyat = guncelKitap.Fiyat;
        return mevcut;
    }

    public bool Sil(int id)
    {
        var kitap = IdIleGetir(id);
        if (kitap is null) return false;
        return _kitaplar.Remove(kitap);
    }

    public List<Kitap> YilaGoreFiltrele(int yil)
    {
        return _kitaplar.Where(x => x.YayinYili > yil).ToList();
    }

    public List<Kitap> YazarAdinaGore(string yazarAdi)
    {
        return _kitaplar.Where(n => n.Yazar == yazarAdi).ToList();
    }

    public List<Kitap> FiyatAraliginaGore(double minFiyat, double maxFiyat)
    {
        return _kitaplar.Where(n => n.Fiyat > minFiyat && n.Fiyat < maxFiyat).ToList();
    }

    public List<Kitap> KitapAdinaGore(string kitapAdi)
    {
        return _kitaplar.Where(n => n.Baslik.Contains(kitapAdi)).ToList();
    }
}