namespace BlackJack
{
    public enum CardsDeckType
    {
        Small = 36,
        Full = 52
    }

    internal class Deck
    {
        public List<Card> CardsList { get; private set; } = new List<Card>();
        public CardsDeckType DeckType { get; private set; }
        public Random Random { get; private set; }

        public Deck()
        {
            DeckType = CardsDeckType.Full;
            Random = new Random();
            FillDeck(DeckType);
        }
        public Deck(CardsDeckType deckType)
        {
            DeckType = deckType;
            Random = new Random();
            FillDeck(DeckType);
        }

        private void FillDeck(CardsDeckType deckType)
        {
            int juniorPlayingCard;
            if (deckType == CardsDeckType.Full)
                juniorPlayingCard = 2;
            else juniorPlayingCard = 6;

            CardsList.Clear();
            for (int nameId = juniorPlayingCard; nameId <= 14; nameId++)
            {
                for (int suitId = 0; suitId <= 3; suitId++)
                {
                    Card card = new Card((Name)nameId, (Suit)suitId);
                    CardsList.Add(card);
                }
            }
        }

        public Card GetCard()
        {
            var id = Random.Next(0, CardsList.Count);
            Card card;

            if (CardsList.Count == 0)
            {
                Console.WriteLine("Сards are over!");
                return null;
            }
            else
            {
                card = CardsList[id];
                CardsList.Remove(card);
            }
            return card;
        }

        public int CardsCount()
        {
            return CardsList.Count;
        }

        public void CompareCards(Card card1, Card card2)
        {
            int Card1 = card1.CardRank;
            Console.WriteLine($"1st card is:\t {card1}");
            int Card2 = card2.CardRank;
            Console.WriteLine($"2nd card is:\t {card2}");
            if (Card1 > Card2)
            {
                Console.WriteLine("1st card rank is higher");
            }
            else if (Card1 < Card2)
            {
                Console.WriteLine("2nd card rank is higher");
            }
            else
            {
                Console.WriteLine("Cards have the same rank");
            }
        }
    }
}
