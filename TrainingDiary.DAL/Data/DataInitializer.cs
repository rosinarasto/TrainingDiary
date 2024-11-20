using Microsoft.EntityFrameworkCore;
using TrainingDiary.DAL.Models;

namespace TrainingDiary.DAL.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = PrepareUserModels();
            var accounts = PrepareAccountModels();
            var trainingRecords = PrepairTrainingRecordModels();
            var recordFields = PrepairRecordFieldModels();

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<Account>()
                .HasData(accounts);

            modelBuilder.Entity<TrainingRecord>()
                .HasData(trainingRecords);

            modelBuilder.Entity<RecordField>()
                .HasData(recordFields);
        }

        private static List<RecordField> PrepairRecordFieldModels()
        {
            throw new NotImplementedException();
        }

        private static List<TrainingRecord> PrepairTrainingRecordModels()
        {
            throw new NotImplementedException();
        }

        private static List<Account> PrepareAccountModels()
        {
            throw new NotImplementedException();
        }

        private static List<User> PrepareUserModels()
        {
            throw new NotImplementedException();
        }
    }
}
