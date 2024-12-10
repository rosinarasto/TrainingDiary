using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class RecordField : BaseEntity
    {
        public int RecordID { get; set; }

        [ForeignKey(nameof(RecordID))]
        public virtual TrainingRecord? TrainingRecord { get; set; }

        [MinLength(1)]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MinLength(1)]
        [MaxLength(4096)]
        public required string Description { get; set; }
    }
}
