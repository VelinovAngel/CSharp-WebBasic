using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void AddTrip(TripsViewModel model);

        public IEnumerable<AllTripsVIewModel> GetAllTrips();

        TripsViewModel GetAllDetails(string id);

        void AddUserToTrip(string userId, string tripId);

        void RemoveUserFromTrip(string tripId);

        public IEnumerable<PassengersViewModel> GetAllPassengers(string tripId);

        bool HasAvailabeSeats(string tripId);
    }
}
