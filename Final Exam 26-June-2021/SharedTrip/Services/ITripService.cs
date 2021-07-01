namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.ViewModels.Trips;

    public interface ITripService
    {
        void AddTrip(TripsViewModel model);

        public IEnumerable<AllTripsViewModel> GetAllTrips();

        TripsViewModel GetAllDetails(string id);

        void AddUserToTrip(string userId, string tripId);

        bool HasAvailabeSeats(string tripId);
    }
}
