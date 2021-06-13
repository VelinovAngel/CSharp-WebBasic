namespace Suls.ViewModels.Problems
{
    using System;


    public class SubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public int MaxPoints { get; set; }

        public string Percentage { get; set; }
    }
}
