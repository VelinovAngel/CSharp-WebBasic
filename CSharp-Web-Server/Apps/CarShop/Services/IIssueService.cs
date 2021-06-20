namespace CarShop.Services
{
    using CarShop.ViewModels.Issues;


    public interface IIssueService
    {
        bool UserOwnsCar(string carId, string userId);

        CarIssuesViewModel GetAllIssues(string carId);

        void AddIssue(string carId, string description);

        void FixIssue(string issueId);

        void DeleteIssue(string issueId, string carId);
    }
}
