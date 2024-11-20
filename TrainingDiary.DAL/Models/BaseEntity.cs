using System.ComponentModel.DataAnnotations;

namespace TrainingDiary.DAL.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
