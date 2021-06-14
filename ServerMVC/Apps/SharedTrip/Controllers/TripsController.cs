using SUS.Http;
using SUS.MvcFramework;
using SharedTrip.ViewModels;
using SharedTrip.Services;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Register");
            }
            var trips = tripsService.GetAllTrips();
            return this.View(trips);
        }

        
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Register");
            }
            var details = tripsService.GetAllDetails(tripId);
            return this.View(details);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Register");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripsViewModel model)
        {
            
            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.Error("Invalid seats!");
            }
            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > 80)
            {
                return this.Error("Invalid description!");
            }
            if (string.IsNullOrEmpty(model.StartPoint) || string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Error("StatPoint and EndPoint are required!");
            }

            tripsService.AddTrip(model);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.HasAvailabeSeats(tripId))
            {
                return this.Error("No available seats!");
            }

            var userId = this.GetUserId();
            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse RemoveUserFromTrip(string tripId)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }


            return this.Redirect("/Trips/All");
        }

        public HttpResponse Passengers(string tripId)
        {
            var model = this.tripsService.GetAllPassengers(tripId);
            return this.View(model);
        }
    }
}
