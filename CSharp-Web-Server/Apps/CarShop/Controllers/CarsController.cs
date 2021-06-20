namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
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
            var allCars = this.carService.GetAllCars(userId);
            return this.View(allCars);
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

            if (string.IsNullOrWhiteSpace(model.Model) || model.Model.Length < 5 || model.Model.Length>20)
            {
                return this.Error("Invalid model");
            }
            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                return this.Error("Invalid plate number");
            }
            if (Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                return this.Error("Invalid url address");
            }
            this.carService.AddCars(model, userId);
            return this.Redirect("/Cars/All");
        }
    }
}
