namespace IRunes.Controllers
{
    using IRunes.Services;
    using IRunes.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;

        public TracksController(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        [Authorize]
        public HttpResponse Create(string albumId)
        {
            var viewModel = new CreateViewModel { AlbumId = albumId, Id = albumId };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Redirect("/Tracks/Create");
            }

            this.trackService.Create(model);
            return this.Redirect($"/Albums/Details?id={model.AlbumId}");
        }

        [Authorize]
        public HttpResponse Details(string trackId)
        {
            var viewModel = this.trackService.GetDetails(trackId);
            if (viewModel == null)
            {
                return this.Error("Track not found.");
            }

            return this.View(viewModel);
        }
    }
}
