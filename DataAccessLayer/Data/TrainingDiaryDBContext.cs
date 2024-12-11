﻿using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public class TrainingDiaryDBContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AccountUser> accountUsers { get; set; }
        public virtual DbSet<TrainingRecord> TrainingRecords { get; set; }
        public virtual DbSet<RecordField> RecordFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUser>()
                .HasKey(au => new { au.AccountId, au.UserId });

            modelBuilder.Entity<AccountUser>()
                .HasOne(a => a.Account)
                .WithMany(a => a.RestrictedUsers)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountUser>()
                .HasOne(a => a.User)
                .WithMany(a => a.RestrictedAccounts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.OwnedAccount)
                .WithOne(a => a.Owner)
                .HasForeignKey<Account>(a => a.Id)
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
