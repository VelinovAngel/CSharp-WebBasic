namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public bool  IsPublic { get; set; }
        public string Owner { get; init; }
        public string CreatedOn { get; init; }
        public int Commits { get; init; }
    }
}
