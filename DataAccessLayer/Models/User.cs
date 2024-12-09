using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace DataAccessLayer.Models
{
    public class User : BaseEntity
    {
        [MinLength(1)]
        [MaxLength(255)]
        public required string UserName { get; set; }

        [MinLength(4)]
        [MaxLength(60)]
        public required string Email { get; set; }

        public required string HashedPassword { get; set; }

        public required string Salt { get; set; }

        public virtual Account? OwnedAccount { get; set; }

        public virtual IEnumerable<Account>? RestrictedAccounts { get; set; }

        public virtual IEnumerable<TrainingRecord>? TrainingRecords { get; set; }
    }
}
