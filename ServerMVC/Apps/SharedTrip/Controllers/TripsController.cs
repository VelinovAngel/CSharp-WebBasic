using SharedTrip.ViewModels;
using SUS.Http;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripsViewModel model)
        {
            return this.View();
        }
    }
}
