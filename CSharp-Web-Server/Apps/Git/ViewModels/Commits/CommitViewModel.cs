namespace Git.ViewModels.Commits
{
    public class CommitViewModel
    {
        public string Id { get; set; }

        public string Repository { get; init; }

        public string Description { get; init; }

        public string CreatedOn { get; init; }
    }
}

