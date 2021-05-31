﻿namespace BattleCards.Controllers
{
    using System.Linq;

    using SUS.Http;
    using SUS.MvcFramework;

    using BattleCards.Data;
    using BattleCards.ViewModels;


    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            var db = new ApplicationDbContext();
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Type = x.Keyword,
            })
                .ToList();

            return this.View(cardsViewModel);
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var dbContext = new ApplicationDbContext();

            dbContext.Cards.Add(new Card
            {
                Attack = int.Parse(this.Request.FromData["attack"]),
                Health = int.Parse(this.Request.FromData["health"]),
                Description = this.Request.FromData["description"],
                Name = this.Request.FromData["name"],
                ImageUrl = this.Request.FromData["image"],
                Keyword = this.Request.FromData["keyword"],
            });

            dbContext.SaveChanges();

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
