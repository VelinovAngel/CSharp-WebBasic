using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void AddTrip(TripsViewModel model, string userId);

        public IEnumerable<AllTripsVIewModel> GetAllTrips();

        TripsViewModel GetAllDetails(string id);
    }
}
