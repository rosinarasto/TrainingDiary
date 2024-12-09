using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Account : BaseEntity
    {
        [ForeignKey(nameof(Id))]
        public virtual User? Owner { get; set; }

        public virtual IEnumerable<AccountUser>? RestrictedUsers { get; set; }
    }
}
