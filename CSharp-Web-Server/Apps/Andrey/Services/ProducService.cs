namespace Andrey.Services
{
    using System.Linq;
    using System;
    using Andrey.Data;
    using System.Collections.Generic;
    using Andrey.Data.Models;
    using Andrey.ViewModels.Products;
    using Andrey.Data.Enum;

    public class ProducService : IProducService
    {
        private readonly AppDbContext db;

        public ProducService(AppDbContext db)
        {
            this.db = db;
        }

        public void Add(AllProductInputModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender)
            };
            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
            => this.db.Products.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            })
            .ToList();


    }
}
