using System; // DateTime kullanabilmek için eklenmesi gereken using direktifi
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Personel
{
    [Column("#")]
    public long? Id { get; set; } // Personel ID

    [Column("Tarih")]   
    public string? Tarih { get; set; }

    [Column("Mesai Günü")]   
    public string? Mesai_Gunu { get; set; }

    [Column("Vardiya Planı")]   
    public string? Vardiya_Plani { get; set; }

    [Column("Ad Soyad")]
    public string? Ad_Soyad { get; set; }

    [Column("Kullanıcı Adı")]
    public string? Kullanici_Adi { get; set; }

    [Column("Kullanıcı Adı (AD)")]
    public string? Kullanici_Adi_AD { get; set; }

    [Column("Ünvanı")]
    public string? Unvani { get; set; }

    [Column("Müdürlük")]
    public string? Mudurluk { get; set; }

    [Column("Departman")]
    public string? Departman { get; set; }

    [Column("Departman Kısa Adı")]
    public string? Departman_Kisa_AD { get; set; }

    [Column("İş Yeri")]
    public string? Is_Yeri { get; set; }

    [Column ("Vardiya Tipi")]
    public string? Vardiya_Tipi { get; set; }

    [Column ("Yoklaması")]
    public string? Yoklamasi  { get; set; }

    [Column ("Durumu")]
    public string? Durumu { get; set; }

    [Column ("(Mesai) Girişi")]
    public string? Mesai_Girişi{ get; set; }

    [Column ("(Plan) Süresi")]
    public string? Plan_Suresi { get; set; }

    [Column ("(İzin) Nedeni")]
    public string? Izin_Nedeni { get; set; }

    [Column ("(İzin) Nedeni2")]
    public string? Izin_Nedeni2 { get; set; }

    [Column ("(İzin) Katılma")]
    public DateTime? Izin_Katilma { get; set; }

    [Column ("(İzin) Açıklaması")]
    public string? Izin_Aciklamasi {get;set;}

    [Column ("(PDKS) Giriş Konumu")]
    public string? PDKS_Giris_Konumu {get;set;}

    [Column ("Yetki Seviyesi")]
    public string? Yetki_Seviyesi {get;set;}

   // [Column ("Pozisyon Seviyesi")]
   // public int? Pozisyon_Seviyesi {get;set;}

   // [Column ("Emp Id (PDKS)")]
   // public int? Emp_Id_PDKS {get;set;}



   
}
