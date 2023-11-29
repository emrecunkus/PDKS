namespace PersonelGirisKontrolSistemi.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
    }
}
