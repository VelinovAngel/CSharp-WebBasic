namespace CarShop.Services
{
    using System.Linq;
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.ViewModels.Cars;
    using System.Collections.Generic;

    public class CarService : ICarService
    {
        private readonly AppDbContext db;

        public CarService(AppDbContext db)
        {
            this.db = db;
        }
        public void AddCars(AddCarsViewModel model, string userId)
        {
            var car = new Car
            {
                Model = model.Model,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.Image,
                Year = model.Year,
                OwnerId = userId,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public ICollection<AllCarsViewModel> GetAllCars(string userId)
            => this.db.Cars.Where(x => x.OwnerId == userId)
            .Select(x => new AllCarsViewModel
            {
                Model = x.Model,
                Image = x.PictureUrl,
                PlateNumber = x.PlateNumber,
                FixedIssues = x.Issues.Where(f => f.IsFixed).Count(),
                RemainingIssues = x.Issues.Where(r => !r.IsFixed).Count(),
            })
            .ToList();

        public bool IsMechanic(string userId)
            => this.db.Users.Any(x => x.Id == userId && x.IsMechanic);
    }
}
