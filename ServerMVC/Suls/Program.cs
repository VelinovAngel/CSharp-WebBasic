namespace Suls
{
    using SUS.MvcFramework;

    using System.Threading.Tasks;

    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
