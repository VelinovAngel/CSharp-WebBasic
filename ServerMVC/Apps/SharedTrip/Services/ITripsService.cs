using SharedTrip.ViewModels;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void AddTrip(TripsViewModel model, string userId);
    }
}
