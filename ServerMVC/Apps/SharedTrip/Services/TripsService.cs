using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Globalization;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddTrip(TripsViewModel model , string userId)
        {
            db.UserTrips.Add(new UserTrip
            {
                UserId = userId,
                Trip = new Trip
                {
                    StartPoint = model.StartPoint,
                    EndPoint = model.EndPoint,
                    ImagePath = model.ImagePath,
                    Seats = model.Seats,
                    Description = model.Description,
                    DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
                }
            });

            db.SaveChanges();
        }
    }
}
