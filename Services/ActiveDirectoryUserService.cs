using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Net;
using Microsoft.Extensions.Logging;

namespace PersonelGirisKontrolSistemi.Services
{
    public class ActiveDirectoryUserService : IUserService
    {
        private readonly ILogger<ActiveDirectoryUserService> _logger;
        public ActiveDirectoryUserService(ILogger<ActiveDirectoryUserService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ValidateCredentials(string username, string password)
        {
            return await Task.Run(
                () =>
                {
                    try
                    {
                        // LDAP sunucusunun adresini ve domain bilgisini buraya girin
                        string ldapPath = "10.150.140.10";
                        string domain = "aspilsan";

                        using (
                            var connection = new LdapConnection(
                                new LdapDirectoryIdentifier(ldapPath)
                            )
                        )
                        {
                            // Kullanıcı adını domain ile birleştir
                            string domainAndUsername = $"{domain}\\{username}";

                            // Bağlantı için kimlik bilgilerini ayarla
                            connection.Credential = new NetworkCredential(
                                domainAndUsername,
                                password
                            );
                            Console.WriteLine(domainAndUsername);
                            Console.WriteLine(password);
                            connection.AuthType = AuthType.Basic;

                            // Bağlantıyı aç (bu, kimlik doğrulamasını da yapacaktır)
                            connection.Bind(); // Senkron metodu kullan

                            // Bağlantı başarılıysa, kimlik doğrulama başarılı demektir
                            Console.WriteLine("Ldap is successfull");
                            return true;
                           
                        }
                    }
                    catch (LdapException ex)
                    {
                        // Hata yönetimi (kimlik doğrulama hatası vs.)
                        // Hata mesajı veya loglama burada yapılabilir

                        // Örnek 1: Hata mesajını bir değişkene atama
                        string errorMessage = ex.Message;
                        Console.WriteLine("Ldap conn cant be established");

                        // Örnek 2: Hata mesajını loglama
                        _logger.LogError(
                            ex,
                            "LDAP Authentication Error : {ErrorMessage}",
                            ex.Message
                        );

                        // Kimlik doğrulama başarısız olduğu için false dönün
                        return false;
                    }
                }
            );
        }
    }
}
