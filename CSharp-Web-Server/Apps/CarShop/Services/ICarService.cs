using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface ICarService
    {
        void AddCars(AddCarsViewModel model, string userId);
    }
}
