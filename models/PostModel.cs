namespace CipherBreakerApi.Models
{
    public class EncryptItem
    {
        public string str{ get; set; }
        public string encryptMethod{ get; set; }
    }

    public class DecryptItem
    {
        public string str{ get; set; }
        
        public string decryptMethod{ get; set; }

        public string key{ get; set; }
    }
}