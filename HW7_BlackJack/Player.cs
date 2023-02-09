using static System.Formats.Asn1.AsnWriter;

namespace BlackJack
{
    internal class Player
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        public int GetScore()
        {
            int score = 0;
            foreach (Card card in Cards)
            {
                score += (int)card.CardRank;
            }
            return score;
        }
        public void ShowCard()
        {
            foreach (Card card in Cards)
            {
                string CardSiutName = card.CardSuit.ToString();
                string CardName = card.CardName.ToString();
                char CardSuitSign = '0';
                             
                switch ((int)card.CardSuit)
                {
                    case 0:
                        CardSuitSign = '\x3';
                        break;
                    case 1:
                        CardSuitSign = '\x4';
                        break;
                    case 2:
                        CardSuitSign = '\x5';
                        break;
                    case 3:
                        CardSuitSign = '\x6';
                        break;
                }

                char c = CardSuitSign;
                if (c == '\x3' || c == '\x4')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (c == '\x5' || c == '\x6')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                switch ((int)card.CardName)
                {

                    case 2:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __2__\n|- - -|\n|- {c} -|\n|- - -|\n|- {c} -|\n|- - -|\n|__2__| \n");
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __3__\n|- - -|\n|- {c} -|\n|- {c} -|\n|- {c} -|\n|- - -|\n|__3__| \n");
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __4__\n|{c} - {c}|\n|- - -|\n|- - -|\n|- - -|\n|{c} - {c}|\n|__4__| \n");
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __5__\n|{c} - {c}|\n|- - -|\n|- {c} -|\n|- - -|\n|{c} - {c}|\n|__5__| \n");
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __6__\n|{c} - {c}|\n|- - -|\n|{c} - {c}|\n|- - -|\n|{c} - {c}|\n|__6__| \n");
                        Console.ResetColor();
                        break;
                    case 7:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __7__\n|{c} - {c}|\n|- - -|\n|{c} {c} {c}|\n|- - -|\n|{c} - {c}|\n|__7__| \n");
                        Console.ResetColor();
                        break;
                    case 8:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __8__\n|{c} - {c}|\n|- {c} -|\n|{c} - {c}|\n|- {c} -|\n|{c} - {c}|\n|__8__| \n");
                        Console.ResetColor();
                        break;
                    case 9:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __9__\n|{c} - {c}|\n|- {c} -|\n|{c} {c} {c}|\n|- {c} -|\n|{c} - {c}|\n|__9__| \n");
                        Console.ResetColor();
                        break;
                    case 10:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n  _10_ \n| {c} - {c} |\n| {c} - {c} |\n| {c} - {c} |\n| {c} - {c} |\n| {c} - {c} |\n| __10__| \n");
                        Console.ResetColor();
                        break;
                    case 11:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __J__\n|- - -|\n|- {c} -|\n|- J -|\n|- {c} -|\n|- - -|\n|__J__| \n");
                        Console.ResetColor();
                        break;
                    case 12:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __Q__\n|- - -|\n|- {c} -|\n|- Q -|\n|- {c} -|\n|- - -|\n|__Q__| \n");
                        Console.ResetColor();
                        break;
                    case 13:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __K__\n|- - -|\n|- {c} -|\n|- K -|\n|- {c} -|\n|- - -|\n|__K__| \n"); ;
                        Console.ResetColor();
                        break;
                    case 14:
                        Console.WriteLine($"{CardName} of {CardSiutName}\n __A__\n|- - -|\n|- {c} -|\n|- A -|\n|- {c} -|\n|- - -|\n|__A__| \n"); ;
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
