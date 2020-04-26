using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class LogisticDbContext : DbContext {
        public DbSet<StockEntity> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
        }
    }
}