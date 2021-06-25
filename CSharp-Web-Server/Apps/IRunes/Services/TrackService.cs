namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.ViewModels;

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
            this.db.Tracks.Add(tracks);
            this.db.SaveChanges();
        }
    }
}
