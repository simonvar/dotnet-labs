using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class LogisticDbContext : DbContext {
        public DbSet<StorageEntity> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=logistic.db");
    }
}