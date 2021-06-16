namespace MyWebServer.App.Data.Models
{
    using System;
    using System.Collections.Generic;


    public class  Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
        }
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; }
    }
}
