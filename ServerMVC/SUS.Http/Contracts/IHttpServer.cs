namespace SUS.Http.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface IHttpServer
    {
        void AddRoute(string path, Func<HttpRequest, HttpResponse> action);

        Task StartAsync(int port);
    }
}
