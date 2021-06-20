namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Issues;
    using System.Collections.Generic;
    using System.Linq;


    public class IssueService : IIssueService
    {
        private readonly AppDbContext db;

        public IssueService(AppDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(string carId, string description)
        {
            var issue = new Issue
            {
                CarId = carId,
                Description = description,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public void DeleteIssue(string issueId, string carId)
        {
            var issue = this.db.Issues
                .FirstOrDefault(x => x.Id == issueId && x.CarId == carId);

            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
        }

        public void FixIssue(string issueId)
        {
            var issue = this.db.Issues
                .FirstOrDefault(x => x.Id == issueId);

            issue.IsFixed = true;
            this.db.SaveChanges();
        }

        public CarIssuesViewModel GetAllIssues(string carId)
            => this.db.Cars
            .Where(i => i.Id == carId)
            .Select(x => new CarIssuesViewModel
            {
                Id = carId,
                Model = x.Model,
                Year = x.Year,
                Issues = x.Issues.Select(i=> new AllIssuesViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed,
                })
            })
            .FirstOrDefault();

        public bool UserOwnsCar(string carId, string userId)
            => this.db.Cars.Any(x => x.Id == carId && x.OwnerId == userId);


    }
}
