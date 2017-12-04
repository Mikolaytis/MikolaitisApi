using Microsoft.AspNet.Identity;
using Mikolaitis.Api.Core.Utils;

namespace Mikolaitis.Api.Authorization.Identity
{
    public class CustomPasswordHasher : PasswordHasher
    {
        private readonly KeyDerivationFunction _hasher = new KeyDerivationFunction();

        public override string HashPassword(string password)
        {
            return _hasher.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return _hasher.VerifyHashedPassword(hashedPassword, providedPassword)
                ? PasswordVerificationResult.Success 
                : PasswordVerificationResult.Failed;
        }
    }
}