namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.ViewModels;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly AppDbContext db;

        public TrackService(AppDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateInputModel model)
        {
            var tracks = new Track
            {
                AlbumId = model.AlbumId,
                Name = model.Name,
                Link = model.Link,
                Price = model.Price
            };

            var allTrackPricesSum = this.db.Tracks
                .Where(x => x.AlbumId == model.AlbumId)
                .Sum(x => x.Price) + model.Price;
            var album = this.db.Albums.Find(model.AlbumId);
            album.Price = allTrackPricesSum * 0.87M;

            this.db.Tracks.Add(tracks);
            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string trackId)
        {
            var track = this.db.Tracks.Where(x => x.Id == trackId)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Link = x.Link,
                    AlbumId = x.AlbumId,
                    Price = x.Price,
                }).FirstOrDefault();

            return track;
        }
    }
}
