using CarShop.ViewModels.Cars;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface ICarService
    {
        void AddCars(AddCarsViewModel model, string userId);

        bool IsMechanic(string userId);

        ICollection<AllCarsViewModel> GetAllCars(string userId);

        ICollection<AllCarsViewModel> GetAllCarsWithIssues(string userId);
    }
}
