namespace Suls.Services
{
    using Suls.ViewModels.Problems;
    using System.Collections.Generic;


    public interface IProblemService
    {
        void CreateProblem(string name, int points);

        IEnumerable<HomePageViewModel> GetAll();

        string GetNameById(string id);

        public ProblemViewModel GetById(string id);
    }
}
