using Microsoft.AspNetCore.Identity;

namespace olympo_webapi.Services
{
    public static class HashService
    {
        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.HashPassword(null, password);
        }

        public static PasswordVerificationResult PasswordVerificationResult(string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        }
    }
}