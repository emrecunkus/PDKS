using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonelGirisKontrolSistemi.Models;
using Microsoft.EntityFrameworkCore;
using YourNamespace;

namespace PersonelGirisKontrolSistemi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, MyDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    //
     public IActionResult Index()
    {
        // Örnek veri oluşturmak için bir liste kullanalım
        List<Personel> personelListesi = new List<Personel>
        {
            new Personel {  Ad_Soyad = "John", Kullanici_Adi = "Doe" },
            new Personel {  Ad_Soyad = "Jane", Kullanici_Adi = "Smith" },
            new Personel {  Ad_Soyad = "Emre", Kullanici_Adi = "Smith" },
            new Personel {  Ad_Soyad = "Melike", Kullanici_Adi = "Smith" }
        };
        string query = " SELECT [#],[Tarih] ,[Mesai Günü],[Vardiya Planı] ,[Ad Soyad],[Kullanıcı Adı],[Kullanıcı Adı (AD)] ,[Ünvanı],[Müdürlük],[Departman],[Departman Kısa Adı],[İş Yeri],[Vardiya Tipi],[Yoklaması],[Durumu],[(Mesai) Girişi],[(Plan) Süresi],[(İzin) Nedeni],[(İzin) Nedeni2],[(İzin) Katılma],[(İzin) Açıklaması],[(PDKS) Giriş Konumu],[Yetki Seviyesi],[Pozisyon Seviyesi],[Emp Id (PDKS)] FROM [PDKS].[dbo].[denemeVRYoklamaKopya] order by #";
         //Personeller = _dbContext.Personeller.FromSqlRaw(query).ToList();
         List<Personel> personelListe_from_db =  _dbContext.Personeller.FromSqlRaw(query).ToList();
         //Console.WriteLine(personelListe_from_db);
        return View(personelListe_from_db); // Personel listesini Index.cshtml görünümüne gönderiyoruz
    }

  
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
