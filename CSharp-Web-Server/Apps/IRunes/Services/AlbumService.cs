namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.ViewModels;
    using IRunes.ViewModels.Albums;
    using System.Collections.Generic;
    using System.Linq;


    public class AlbumService : IAlbumService
    {
        private readonly AppDbContext db;

        public AlbumService(AppDbContext db)
        {
            this.db = db;
        }

        public AlbumDetailsModel AlbumDetailsModel(string id)
            => this.db.Albums.Where(x=>x.Id == id)
            .Select(x => new AlbumDetailsModel
            {
                Id = x.Id,
                Name = x.Name,
                Cover = x.Cover,
                Price = x.Price,
                Tracks = x.Tracks.Select(a => new TracksInfoModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Link = a.Link,
                    Price = a.Price
                }).ToList()
            })
            .FirstOrDefault();

        public void Create(AlbumsInputModel model)
        {
            var album = new Album
            {
                Name = model.Name,
                Cover = model.Cover
            };
            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumsInputModel> GetAllAlbum()
            => this.db.Albums
            .Select(x => new AlbumsInputModel
            {
                Id = x.Id,
                Cover = x.Cover,
                Name = x.Name
            })
            .ToList();
    }
}
