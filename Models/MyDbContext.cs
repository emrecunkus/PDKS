using Microsoft.EntityFrameworkCore;

namespace YourNamespace // Kullandığınız projenin namespace'i
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            

        }

        // DbSet özelliklerini burada tanımlayarak veritabanı tablolarınızı temsil edebilirsiniz.
        public DbSet<Personel>? Personeller { get; set; }
        // Diğer DbSet'leri buraya ekleyin
      

        // Model oluşturma ve diğer DbContext konfigürasyonlarını burada yapabilirsiniz.
    }
}
