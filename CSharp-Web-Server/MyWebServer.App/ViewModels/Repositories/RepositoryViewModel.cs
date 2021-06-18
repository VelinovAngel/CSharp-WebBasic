﻿namespace MyWebServer.App.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public string Owner { get; init; }

        public string CreatedOn { get; init; }

        public int CommitsCout { get; init; }
    }
}
