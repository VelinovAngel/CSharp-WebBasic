using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public TripsViewModel GetAllDetails(string id)
            => db.Trips.Where(x => x.Id == id)
            .Select(x => new TripsViewModel
            {
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = x.Description,
                EndPoint = x.EndPoint,
                Id = x.Id,
                ImagePath = x.ImagePath,
                Seats = x.Seats,
                StartPoint = x.StartPoint,
                UsedSeats = x.UserTrips.Count(),
            })
            .FirstOrDefault();

        public IEnumerable<AllTripsVIewModel> GetAllTrips()
                => db.Trips.Select(x => new AllTripsVIewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = x.Seats
                })
            .ToList();
    }
}
