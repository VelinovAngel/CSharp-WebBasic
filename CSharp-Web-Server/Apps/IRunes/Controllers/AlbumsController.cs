namespace IRunes.Controllers
{
    using IRunes.Services;
    using IRunes.ViewModels.Albums;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public HttpResponse All()
        {
            var albums = this.albumService.GetAllAlbum();
            return this.View(albums);
        }

        [Authorize]
        public HttpResponse Create() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(AlbumsInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Redirect("/Albums/Create");
            }
            if (string.IsNullOrWhiteSpace(model.Cover))
            {
                return this.Redirect("/Albums/Create");
            }

            this.albumService.Create(model);
            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            var model = this.albumService.AlbumDetailsModel(id);
            return this.View(model);
        }

    }
}
