namespace Andrey.Services
{
    using Andrey.Data.Models;
    using Andrey.ViewModels.Products;
    using System.Collections.Generic;
    public interface IProducService
    {
        IEnumerable<Product> GetAll();

        void Add(AllProductInputModel model);

    }
}
