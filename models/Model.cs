namespace CipherBreakerApi.Models
{
    public class EncryptItem
    {
        public string method{ get; set; }

        public string str{ get; set; }

        public string key{ get; set; }

        public string result{ get; set; }
    }

    public class DecryptItem
    {
        public string method{ get; set; }

        public string str{ get; set; }

        public string key{ get; set; }

        public string result{ get; set; }
    }

    public class BreakItem
    {
        public string method{ get; set; }

        public string str{ get; set; }

        public (string, double) result{ get; set; }
    }
}