using Microsoft.EntityFrameworkCore;

namespace CipherBreakerApi.Models
{
    public class CBContext : DbContext{
        public CBContext(DbContextOptions<CBContext> options)
            : base(options){
            this.Database.EnsureCreated(); //自动建库建表
        }

        public DbSet<EncryptItem> EncryptItems { get; set; }
        public DbSet<DecryptItem> DecryptItems { get; set; }
        public DbSet<BreakItem> BreakItems { get; set; }
    }
}