namespace TrainingDiary.DAL.Models
{
    public class Account : BaseEntity
    {
        public int OwnerId { get; set; }

        public virtual User? Owner { get; set; }

        public virtual IEnumerable<User>? Contributors { get; set; }
    }
}
