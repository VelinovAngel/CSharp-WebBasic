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

        public HttpResponse Create(string albumId)
        {
            var viewModel = new CreateViewModel { AlbumId = albumId, Id = albumId };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel model)
        {

            //var model = new CreateInputModel
            //{
            //    AlbumId = albumId,
            //    Name = name,
            //    Link = link,
            //    Price = price
            //};
            this.trackService.Create(model);
            return this.View();
        }
    }
}
