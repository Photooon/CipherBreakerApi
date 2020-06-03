using Microsoft.EntityFrameworkCore;

namespace CipherBreakerApi.Models
{
    public class WordFrequencyItem{

        [Key]
        public string Word { get; set; }
        
        public long Frequency { get; set; }
        
    }
}