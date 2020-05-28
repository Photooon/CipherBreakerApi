using Microsoft.EntityFrameworkCore;

namespace CipherBreakerApi.Models
{
    public class WordFrequencyContext : DbContext{
        public WordFrequencyContext(DbContextOptions<WordFrequencyContext> options)
            : base(options){
            this.Database.EnsureCreated(); //自动建库建表
        }

        public DbSet<WordFrequencyItem> WordFrequencyItems { get; set; }
    }
}