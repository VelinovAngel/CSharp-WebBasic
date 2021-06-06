namespace BattleCards.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BattleCards.Data;
    using BattleCards.ViewModels.Cards;

    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(AddCardInputModel input)
        {

            db.Cards.Add(new Card
            {
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Keyword = input.Keyword,
            });

            db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()=> 
            db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Type = x.Keyword,
            }).ToList();

        public IEnumerable<CardViewModel> GetByUserId(string userId)=>
            db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Attack = x.Card.Attack,
                    Description = x.Card.Description,
                    Name = x.Card.Name,
                    Health = x.Card.Health,
                    ImageUrl = x.Card.ImageUrl,
                    Type = x.Card.Keyword,
                    Id = x.CardId,
                })
                .ToList();

        public void RemoveCard()
        {
            throw new NotImplementedException();
        }
    }
}
