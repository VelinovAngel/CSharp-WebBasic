using Suls.Data;

namespace Suls.Services
{
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

        public string GetProblemId(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
