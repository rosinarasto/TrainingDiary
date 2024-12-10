using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = PrepareUserModels();
            var accounts = PrepareAccountModels();
            var accountsUsers = PrepareAccountUserModels();
            var trainingRecords = PrepareTrainingRecordModels();
            var recordFields = PrepareRecordFieldModels();

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<Account>()
                .HasData(accounts);

            modelBuilder.Entity<AccountUser>()
                .HasData(accountsUsers);

            modelBuilder.Entity<TrainingRecord>()
                .HasData(trainingRecords);

            modelBuilder.Entity<RecordField>()
                .HasData(recordFields);
        }

        private static List<RecordField> PrepareRecordFieldModels()
        {
            return
                [
                    new RecordField
                    {
                        RecordID = 1,
                        Name = "Record 1 Name",
                        Description = "Description for Record 1"
                    },
                    new RecordField
                    {
                        RecordID = 2,
                        Name = "Record 2 Name",
                        Description = "Description for Record 2"
                    },
                    new RecordField
                    {
                        RecordID = 2,
                        Name = "Record 3 Name",
                        Description = "Description for Record 3"
                    },
                    new RecordField
                    {
                        RecordID = 3,
                        Name = "Record 4 Name",
                        Description = "Description for Record 4"
                    },
                    new RecordField
                    {
                        RecordID = 4,
                        Name = "Record 5 Name",
                        Description = "Description for Record 5"
                    },
                    new RecordField
                    {
                        RecordID = 4,
                        Name = "Record 6 Name",
                        Description = "Description for Record 6"
                    },
                ];
        }

        private static List<TrainingRecord> PrepareTrainingRecordModels()
        {
            return
                [
                    new TrainingRecord
                    {
                        OwnerId = 1,
                    },
                    new TrainingRecord
                    {
                        OwnerId = 2,
                    },
                    new TrainingRecord
                    {
                        OwnerId = 3,
                    },
                    new TrainingRecord
                    {
                        OwnerId = 4,
                    },
                    new TrainingRecord
                    {
                        OwnerId = 5,
                    },
                ];
        }

        private static List<AccountUser> PrepareAccountUserModels()
        {
            return
                [
                    new AccountUser
                    {
                        AccountId = 1,
                        UserId = 2,
                    },
                    new AccountUser
                    {
                        AccountId = 1,
                        UserId = 3,
                    }
                ];
        }

        private static List<Account> PrepareAccountModels()
        {
            return
                [
                    new Account
                    {
                        Id = 1,
                    },
                    new Account
                    {
                        Id = 2,
                    },
                    new Account
                    {
                        Id = 3,
                    },
                    new Account
                    {
                        Id = 4,
                    },
                    new Account
                    {
                        Id = 5,
                    },
                ];
        }

        private static List<User> PrepareUserModels()
        {
            return
                [
                    new User
                    {
                        Id = 1,
                        UserName = "john_doe123",
                        Email = "john.doe@example.com",
                        HashedPassword = "c8f03cbe8b4d321c601a18b2a46ee83ccf7ac684e8768c6a46648cb45a8ec504",
                        Salt = "a3bcd4f1e6b1c2d4",
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "jane_smith456",
                        Email = "jane.smith@example.com",
                        HashedPassword = "9efcbedb2b6328e3384b207e49cd42428c77ad8f4b34c637d3b8bfa91fc4f76e",
                        Salt = "f4ac0a5bda6723b8",
                    },
                    new User
                    {
                        Id = 3,
                        UserName = "charlie_brown789",
                        Email = "charlie.brown@example.com",
                        HashedPassword = "02bbf3c177953e24b5a49848b1bb7794b225225226f5acb628ed5e7a564264cb",
                        Salt = "d1e5f4c9b3a7e9c2",
                    },
                    new User
                    {
                        Id = 4,
                        UserName = "alice_wonder123",
                        Email = "alice.wonder@example.com",
                        HashedPassword = "4d7505d99f81fcb6b4f56b9350b47e03354b859fd4ea6b92c9a1b0e602f7c72f",
                        Salt = "ab2f8b79a3b5c1d2",
                    },
                    new User
                    {
                        Id = 5,
                        UserName = "bob_builder567",
                        Email = "bob.builder@example.com",
                        HashedPassword = "f0533b863a32d8c7c7e213869874f3ab25f436ae77c3da522dc11e619e4bb92b",
                        Salt = "2c6f8b9a7f3d2e19",
                    },
                ];
        }
    }
}
