namespace BattleCards.ViewModels.Cards
{
    public class AddCardInputModel
    {
        //int attack, int health , string description, string name, string imageUrl, string keyword
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Keyword { get; set; }
    }
}
