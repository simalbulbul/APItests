namespace KitapApi.Models;

public class Kitap
{
    public int Id { get; set; }
    public string Baslik { get; set; } = "";
    public string Yazar { get; set; } = "";
    public int YayinYili { get; set; }
    public double Fiyat { get; set; }

}