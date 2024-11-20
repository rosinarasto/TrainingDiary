using Microsoft.EntityFrameworkCore;
using TrainingDiary.DAL.Models;

namespace TrainingDiary.DAL.Data
{
    public class TrainingDiaryDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingRecord> TrainingRecords { get; set; }
        public DbSet<RecordField> RecordFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.RestrictedUsers)
                .WithMany(u => u.RestrictedAccounts)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountStudent",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserID"),
                    j => j.HasOne<Account>().WithMany().HasForeignKey("AccountID"));

            modelBuilder.Entity<User>()
                .HasOne(u => u.OwnedAccount)
                .WithOne(a => a.Owner)
                .HasForeignKey<Account>(a => a.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingRecord>()
                .HasOne(d => d.Owner)
                .WithMany(o => o.TrainingRecords)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecordField>()
                .HasOne(f => f.TrainingRecord)
                .WithMany(r => r.RecordFields)
                .HasForeignKey(f => f.RecordID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
