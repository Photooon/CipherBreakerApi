using Microsoft.EntityFrameworkCore;

namespace CipherBreakerApi.Models
{
    public class CBContext : DbContext{
        public CBContext(DbContextOptions<CBContext> options)
            : base(options){
            this.Database.EnsureCreated(); //自动建库建表
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncryptItem>().HasKey(t => new { t.method, t.str, t.key});      //组合主键
            modelBuilder.Entity<DecryptItem>().HasKey(t => new { t.method, t.str, t.key });
            modelBuilder.Entity<BreakItem>().HasKey(t => new { t.method, t.str });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EncryptItem> EncryptItems { get; set; }
        public DbSet<DecryptItem> DecryptItems { get; set; }
        public DbSet<BreakItem> BreakItems { get; set; }
    }
}