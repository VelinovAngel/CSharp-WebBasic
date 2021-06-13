namespace Suls.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Suls.Data;
    using Suls.ViewModels.Problems;


    public class ProblemService : IProblemService
    {
        private readonly DbApplicationContext db;

        public ProblemService(DbApplicationContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageViewModel> GetAll()
                 => db.Problems.Select(x => new HomePageViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Count = x.Submissions.Count()
                 })
            .ToList();

        public string GetNameById(string id)
            => this.db.Problems.FirstOrDefault(x => x.Id == id)?.Name;


        public ProblemViewModel GetById(string id)
            => this.db.Problems.Where(x => x.Id == id)
                               .Select(x => new ProblemViewModel
                               {
                                   Name = x.Name,
                                   Submissions = x.Submissions.Select(s => new SubmissionViewModel
                                   {
                                       CreatedOn = s.CreatedOn,
                                       SubmissionId = s.Id,
                                       AchievedResult = s.AchievedResult,
                                       Username = s.User.Username,
                                       MaxPoints = s.Problem.Points,
                                       Percentage = $"{(s.AchievedResult / (1.0 * s.Problem.Points)) * 100.00:F2}".ToString()
                                   })
                               })
                               .FirstOrDefault();
    }
}
