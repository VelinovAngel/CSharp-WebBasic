namespace IRunes.Services
{
    using IRunes.ViewModels;

    public interface ITrackService
    {
        void Create(CreateInputModel model);

        public DetailsViewModel GetDetails(string trackId);
    }
}
