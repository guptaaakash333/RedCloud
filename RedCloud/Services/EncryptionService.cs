using Microsoft.AspNetCore.DataProtection;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IDataProtectionProvider _provider;

        public EncryptionService(IDataProtectionProvider provider)
        {
            _provider = provider;
        }

        public string EncryptValue(int value)
        {
            var protector = _provider.CreateProtector("ValueProtector");
            var stringValue = value.ToString(); // Convert int to string
            return protector.Protect(stringValue);
        }

        public int DecryptValue(string encryptedValue)
        {
            var protector = _provider.CreateProtector("ValueProtector");
            var decryptedString = protector.Unprotect(encryptedValue);
            return int.Parse(decryptedString); // Parse back to int
        }
    }

}
