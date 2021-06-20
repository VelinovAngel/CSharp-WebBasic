namespace CarShop.Controllers
{
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly ICarService carService;

        public IIssueService IssueService { get; }

        public IssuesController(IIssueService issueService, ICarService carService)
        {
            IssueService = issueService;
            this.carService = carService;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!carService.IsMechanic(this.User.Id))
            {
                if (!IssueService.UserOwnsCar(carId, this.User.Id))
                {
                    return this.Error("You don't have access to this car!");
                }
            }

            var issues = this.IssueService.GetAllIssues(carId);
            if (issues == null)
            {
                return this.Error($"Car with ID '{carId}' does not exists!");
            }
            return this.View(issues);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(string carId, string description)
        {
            this.IssueService.AddIssue(carId, description);
            return this.View();
        }

        [Authorize]
        public HttpResponse Fix(string issueId)
        {
            if (!this.carService.IsMechanic(this.User.Id))
            {
                return this.Error("You are not mechanic!");
            }
            this.IssueService.FixIssue(issueId);
            return this.Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.carService.IsMechanic(this.User.Id))
            {
                return this.Error("You are not mechanic!");
            }
            this.IssueService.DeleteIssue(issueId, carId);
            return this.Redirect("/Cars/All");
        }
    }
}
