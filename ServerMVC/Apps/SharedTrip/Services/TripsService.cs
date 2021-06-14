using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

using SharedTrip.Data;
using SharedTrip.ViewModels;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddTrip(TripsViewModel model)
        {
            db.Trips.Add(new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
            });

            db.SaveChanges();
        }

        public IEnumerable<AllTripsVIewModel> GetAllTrips()
                => db.Trips.Select(x => new AllTripsVIewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = x.Seats - x.UserTrips.Count()
                })
            .ToList();

        public TripsViewModel GetAllDetails(string id)
            => db.Trips.Where(x => x.Id == id)
            .Select(x => new TripsViewModel
            {
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = x.Description,
                EndPoint = x.EndPoint,
                Id = x.Id,
                ImagePath = x.ImagePath,
                Seats = x.Seats - x.UserTrips.Count(),
                StartPoint = x.StartPoint,
            })
            .FirstOrDefault();

        public void AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };
            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public bool HasAvailabeSeats(string tripId)
        {
            var tripSeats = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new
                {
                    x.Seats,
                    TakenSeats = x.UserTrips.Count()
                })
                .FirstOrDefault();
            var availableSeats = tripSeats.Seats - tripSeats.TakenSeats;
            return availableSeats > 0;
        }

        public IEnumerable<PassengersViewModel> GetAllPassengers(string tripId)
            => this.db.UserTrips.Where(x => x.TripId == tripId)
            .Select(x => new PassengersViewModel
            {
                Name = x.User.Username,
                Email = x.User.Email,
                ImagePath = x.Trip.ImagePath,
            })
            .ToList();

        public void RemoveUserFromTrip(string tripId, string userId)
        {
            var userInTrip = this.db.UserTrips
                .FirstOrDefault(x => x.TripId == tripId && x.UserId == userId);

            if (userInTrip == null)
            {
                return;
            }

            this.db.UserTrips.Remove(userInTrip);
            this.db.SaveChanges();
        }
    }
}
