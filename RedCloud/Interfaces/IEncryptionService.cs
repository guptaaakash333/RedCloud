namespace RedCloud.Interfaces
{
    public interface IEncryptionService
    {
        public string EncryptValue(int value);
        public int DecryptValue(string encryptedValue);
    }
}
