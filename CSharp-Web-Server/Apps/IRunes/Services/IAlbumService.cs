namespace IRunes.Services
{
    using IRunes.ViewModels.Albums;
    using System.Collections.Generic;


    public interface IAlbumService
    {
        void Create(AlbumsInputModel model);

        IEnumerable<AlbumsInputModel> GetAllAlbum();

        AlbumDetailsModel AlbumDetailsModel(string id);
    }
}
