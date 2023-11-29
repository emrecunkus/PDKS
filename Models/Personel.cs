public class Personel
{
    public int Id { get; set; } // Personel ID
    public string Ad { get; set; } // Kullanıcının adı
    public string Soyad { get; set; } // Kullanıcının soyadı
    public DateTime SabahGirisSaati { get; set; } // Sabah giriş saati
    public DateTime AksamCikisSaati { get; set; } // Akşam çıkış saati
    // Diğer özellikler eklenebilir

    // İsteğe bağlı olarak ek bilgiler veya hesaplamalar yapabilirsiniz.
    public string TamAd
    {
        get { return $"{Ad} {Soyad}"; } // Tam ad hesaplama örneği
    }
    
}
