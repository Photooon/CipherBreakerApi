using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CipherBreakerApi.Models
{
    public class EncryptItem
    {
        [Key,Column(Order = 0)]
        public string method{ get; set; }

        [Key,Column(Order = 1)]
        public string str{ get; set; }

        [Key,Column(Order = 2)]
        public string key{ get; set; }

        public string result{ get; set; }

        [Key,Column(Order = 3)]
        public string datetime{ get; set; }
    }

    public class DecryptItem
    {
        [Key,Column(Order = 0)]
        public string method{ get; set; }

        [Key,Column(Order = 1)]
        public string str{ get; set; }

        [Key,Column(Order = 2)]
        public string key{ get; set; }

        public string result{ get; set; }

        [Key,Column(Order = 3)]
        public string datetime{ get; set; }
    }

    public class BreakItem
    {
        [Key,Column(Order = 0)]
        public string method{ get; set; }

        [Key,Column(Order = 1)]
        public string str{ get; set; }

        public string result_str{ get; set; }

        public double result_prob{ get; set; }

        [Key,Column(Order = 2)]
        public string datetime{ get; set; }
    }
}