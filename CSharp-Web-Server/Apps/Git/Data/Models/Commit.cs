namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class  Commit
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
