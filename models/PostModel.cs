namespace CipherBreakerApi.Models
{
    public class EncryptItem
    {
        public string encryptMethod{ get; set; }

        public string str{ get; set; }

        public string key{ get; set; }
    }

    public class DecryptItem
    {
        public string decryptMethod{ get; set; }

        public string str{ get; set; }

        public string key{ get; set; }
    }
}