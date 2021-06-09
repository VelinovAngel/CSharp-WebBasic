namespace Suls.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        [MaxLength(300)]
        public int ArchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public Problem Problem { get; set; }

        public User User { get; set; }
    }
}
