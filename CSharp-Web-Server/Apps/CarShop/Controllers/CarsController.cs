namespace CarShop.Controllers
{
    using System;
    using MyWebServer.Http;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using CarShop.ViewModels.Cars;
    using System.Text.RegularExpressions;

    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        public HttpResponse All()
        {
            var userId = this.User.Id;
            if (this.carService.IsMechanic(userId))
            {
                var allCarsWithIssues = this.carService.GetAllCarsWithIssues(userId);
                return this.View(allCarsWithIssues);
            }
            else
            {
                var allCars = this.carService.GetAllCars(userId);
                return this.View(allCars);
            }
        }

        [Authorize]
        public HttpResponse Add()
        {
            var userId = this.User.Id;
            var isMachanic = carService.IsMechanic(userId);
            if (isMachanic)
            {
                return this.Unauthorized();
            }
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarsViewModel model)
        {
            var userId = this.User.Id;
            var isMachanic = carService.IsMechanic(userId);
            if (isMachanic)
            {
                return this.Unauthorized();
            }

            if (string.IsNullOrWhiteSpace(model.Model) || model.Model.Length < 5 || model.Model.Length > 20)
            {
                return this.Error("Invalid model");
            }
            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                return this.Error("Invalid plate number");
            }

            Uri uriResult;
            bool result = Uri.TryCreate(model.Image, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            if (result)
            {
                return this.Error("Invalid url address");
            }
            this.carService.AddCars(model, userId);
            return this.Redirect("/Cars/All");
        }
    }
}
