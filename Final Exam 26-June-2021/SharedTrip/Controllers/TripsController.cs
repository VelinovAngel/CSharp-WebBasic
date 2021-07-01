namespace SharedTrip.Controllers
{
    using MyWebServer.Http;
    using SharedTrip.Services;
    using MyWebServer.Controllers;
    using SharedTrip.ViewModels.Trips;

    public class TripsController : Controller
    {
        private const string TripsAdd = "/Trips/Add";
        private const string RedirectUserRegister = "/Users/Register";

        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }
        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect(RedirectUserRegister);
            }
            var trips = tripService.GetAllTrips();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect(RedirectUserRegister);
            }
            var details = tripService.GetAllDetails(tripId);
            return this.View(details);
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect(RedirectUserRegister);
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripsViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.Redirect(TripsAdd);
                //return this.Error("Invalid seats!");
            }
            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > 80)
            {
                return this.Redirect(TripsAdd);
                //return this.Error("Invalid description!");
            }
            if (string.IsNullOrEmpty(model.StartPoint) || string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Redirect(TripsAdd);
                //return this.Error("StatPoint and EndPoint are required!");
            }

            tripService.AddTrip(model);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripService.HasAvailabeSeats(tripId))
            {
                return this.Error("No available seats!");
            }

            var userId = this.User.Id;
            this.tripService.AddUserToTrip(userId, tripId);

            return this.Redirect("/");
        }
    }
}
