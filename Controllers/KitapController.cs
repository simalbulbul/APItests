using Microsoft.AspNetCore.Mvc;
using KitapApi.Models;
using KitapApi.Services;

namespace KitapApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KitapController : ControllerBase
{
    private readonly IKitapService _kitapService;

    public KitapController(IKitapService kitapService)
    {
        _kitapService = kitapService;
    }

    [HttpGet]
    public IActionResult HepsiniGetir([FromQuery] int sayfa = 1, [FromQuery] int limit = 10)
    {
        var kitaplar = _kitapService.HepsiniGetir(sayfa, limit);
        return Ok(kitaplar);
    }

        [HttpGet("{id:int}")]
    public IActionResult IdIleGetir(int id)
    {
        var kitap = _kitapService.IdIleGetir(id);
        if (kitap is null)
            return NotFound(new { message = $"Kitap {id} bulunamadı" });
        return Ok(kitap);
    }

    [HttpPost]
    public IActionResult Ekle([FromBody] Kitap yeniKitap)
    {
        var eklenen = _kitapService.Ekle(yeniKitap);
        return CreatedAtAction(nameof(IdIleGetir), new { id = eklenen.Id }, eklenen);
    }
    [HttpPut("{id:int}")]
    public IActionResult Guncelle(int id, [FromBody] Kitap guncelKitap)
    {
        var sonuc = _kitapService.Guncelle(id, guncelKitap);
        if (sonuc is null)
            return NotFound(new { message = $"Kitap {id} bulunamadı" });
        return Ok(sonuc);
    }
    [HttpDelete("{id:int}")]
    public IActionResult Sil(int id)
    {
        var silindi = _kitapService.Sil(id);
        if (!silindi)
            return NotFound(new { message = $"Kitap {id} bulunamadı" });
        return NoContent();
    }


    [HttpGet("yildansonra")]
    public IActionResult YilaGoreFiltrele([FromQuery]int yil)
    {
        var sonuc = _kitapService.YilaGoreFiltrele(yil);
        if (sonuc is null)
            return NotFound(new { message = $" Aradığınız yıllara göre kitap bulunamadı" });
        return Ok(sonuc);

    }

    [HttpGet("yazarAdinaGore")]
    public IActionResult YazarAdinaGore([FromQuery] string yazarAdi)
    {
        var sonuc = _kitapService.YazarAdinaGore(yazarAdi);
        if (sonuc is null)
            return NotFound(new { message = $" Aradığınız yazar adı bulunamadı" });
        return Ok(sonuc);

    }
    [HttpGet("fiyatAraligi")]
    public IActionResult FiyatAraliginaGore([FromQuery] double minFiyat, [FromQuery] double maxFiyat)
    {
        var sonuc = _kitapService.FiyatAraliginaGore(minFiyat, maxFiyat);
        if (sonuc is null)
            return NotFound(new { message = $" Aradığınız fiyat aralığına göre kitap bulunamadı" });
        return Ok(sonuc);
    }
    
    [HttpGet("kitapAdinaGore")]
    public IActionResult KitapAdinaGore([FromQuery] string kitapAdi)
    {
        var sonuc = _kitapService.KitapAdinaGore(kitapAdi);
        if (sonuc is null)
            return NotFound(new { message = $" Aradığınız kelime adıyla kitap bulunamadı" });
        return Ok(sonuc);

    }

}