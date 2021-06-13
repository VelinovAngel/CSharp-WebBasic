namespace Suls.ViewModels.Problems
{
    using System.Collections.Generic;


    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
