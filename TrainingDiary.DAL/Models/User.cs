using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingDiary.DAL.Models
{
    public class User : BaseEntity
    {
        [MinLength(1)]
        [MaxLength(255)]
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string HashedPassword { get; set; }

        public required string Salt { get; set; }


        public virtual IEnumerable<TrainingRecord>? TrainingRecords { get; set; }

        public int OwnAccountId { get; set; }

        [ForeignKey(nameof(OwnAccountId))]
        public virtual Account? OwnAccount { get; set; }

        public virtual IEnumerable<Account>? ContributorAccounts { get; set; }
    }
}
