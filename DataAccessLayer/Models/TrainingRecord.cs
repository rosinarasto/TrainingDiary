using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class TrainingRecord : BaseEntity
    {
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual User? Owner { get; set; }

        public virtual IEnumerable<RecordField>? RecordFields { get; set; }
    }
}
