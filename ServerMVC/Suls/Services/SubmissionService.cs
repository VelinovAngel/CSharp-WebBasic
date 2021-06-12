namespace Suls.Services
{
    using Suls.Data;
    using System;
    using System.Linq;

    public class SubmissionService : ISubmissionService
    {
        private readonly DbApplicationContext db;
        private readonly Random random;

        public SubmissionService(DbApplicationContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoint = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            var submission = new Submission

            {
                ProblemId = problemId,
                Code = code,
                UserId = userId,
                CreatedOn = DateTime.Now,
                AchievedResult = this.random.Next(0, problemMaxPoint + 1)
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
    }
}
