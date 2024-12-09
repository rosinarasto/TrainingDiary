using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Account : BaseEntity
    {
        public int OwnerID { get; set; }

        [ForeignKey(nameof(OwnerID))]
        public virtual User? Owner { get; set; }

        public virtual IEnumerable<User>? RestrictedUsers { get; set; }
    }
}
