using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class AccountUser : BaseEntity
    {
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
