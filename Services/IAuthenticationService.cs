namespace YourNamespace.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticatedAsync(string username);
    }
}
