namespace BattleCards.Services
{
    using System.Collections.Generic;

    using BattleCards.ViewModels.Cards;

    public interface ICardsService
    {
        void AddCard(AddCardInputModel input);
        public IEnumerable<CardViewModel> GetAll();
        public IEnumerable<CardViewModel> GetByUserId(string userId);
        void RemoveCard();
    }
}
