namespace BattleCards.Services
{
    using System;

    using BattleCards.Data;

    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCard()
        {
            throw new NotImplementedException();
        }

        public void GetAllCards()
        {
            throw new NotImplementedException();
        }

        public void RemoveCard()
        {
            throw new NotImplementedException();
        }
    }
}
