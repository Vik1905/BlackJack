namespace BlackJack
{
    public enum Name
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades,
    }

    internal class Card
    {

        public Name CardName { get; private set; }
        public Suit CardSuit { get; private set; }
        public int CardRank { get; private set; }

        public int RankOfCard(Name cardName)
        {
            CardRank = (int)CardName;
            if (cardName == Name.Jack || cardName == Name.Queen || cardName == Name.King)
                CardRank = 10;
            else if (cardName == Name.Ace)
                CardRank = 11;
            return CardRank;
        }

        public Card(Name cardName, Suit cardSuit)
        {
            CardName = cardName;
            CardSuit = cardSuit;
            RankOfCard(cardName);
        }

        public override string ToString()
        {
            return $"Card: {CardName} - {CardSuit}. CardRank = {CardRank}";
        }
    }
}
