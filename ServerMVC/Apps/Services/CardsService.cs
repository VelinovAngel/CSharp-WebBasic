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

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Keyword = input.Keyword,
            };
            db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()=> 
            db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
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

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x=>x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId
            });

            this.db.SaveChanges();
        }
        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
