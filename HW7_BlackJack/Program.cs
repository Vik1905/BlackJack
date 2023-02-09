namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int deckSize;
            Console.WriteLine("Welcome to the BlackJack game!\nThe minimum bet in the game is $5");
            Thread.Sleep(2000);
            Console.WriteLine("Select deck size to start a game: 36 or 52");
            deckSize = Convert.ToInt32(Console.ReadLine());
            
            var dealer = new Player();
            var player = new Player();
            int playerBank = 100;
            int minBet = 5;
            int playerBet = 0;
            var option = "1";

            while (playerBank >= minBet && option == "1")
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Make your bet!");
                    playerBet = int.Parse(Console.ReadLine());
                    if (playerBet < minBet)
                    {
                        Console.WriteLine($"Minimum bet is {minBet}. Your bet must be at least {minBet}.\nTry again!");
                    }
                    else if (playerBet > playerBank)
                    {
                        Console.WriteLine($"You don't have enough money. Your balance is {playerBank}.\nTry again!");
                    }
                    else
                    {
                        Console.WriteLine($"Your bet is {playerBet}");
                        Thread.Sleep(2000);
                        break;
                    }
                }

                Console.Clear();
                Console.WriteLine("The game has begun. Wait for your cards!");
                Thread.Sleep(3000);
                var deck = new Deck((CardsDeckType)deckSize);

                dealer.AddCard(deck.GetCard());
                dealer.AddCard(deck.GetCard());

                player.AddCard(deck.GetCard());
                player.AddCard(deck.GetCard());

                bool dealerFlag = false;
                bool playerFlag = false;
                while (true)
                {
                    if (!dealerFlag)
                    {
                        if (dealer.GetScore() >= 15)
                        {
                            dealerFlag = true;
                        }
                        else
                        {
                            dealer.AddCard(deck.GetCard());
                        }
                    }
                    if (!playerFlag && player.GetScore() <= 21)
                    {
                        Console.Clear();
                        Console.WriteLine("Your cards:");
                        player.ShowCard();
                        Thread.Sleep(2000);
                        Console.WriteLine("Do you want to take one more card ?\n1 - Yes\n2 - No");
                        var playerChoose = Console.ReadLine();
                        if (playerChoose == "1")
                        {
                            Thread.Sleep(1000);
                            player.AddCard(deck.GetCard());
                            Console.Clear();
                            //Console.WriteLine("Your cards:");
                            //player.ShowCard();
                        }
                        else if (playerChoose == "2")
                        {
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("Your cards:");
                            player.ShowCard();
                            Console.WriteLine($"\nYour score: {player.GetScore()}");
                            Thread.Sleep(2000);
                            Console.WriteLine("\nDealer's cards:");
                            dealer.ShowCard();
                            Console.WriteLine($"\nDealer's score: {dealer.GetScore()}");
                            playerFlag = true;
                        }
                        else
                        {
                            Console.WriteLine("Your choice is wrong!");
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Your cards:");
                        player.ShowCard();
                        Console.WriteLine($"\nYour score: {player.GetScore()}");
                        Thread.Sleep(1000);
                        Console.WriteLine("\nDealer's cards:");
                        dealer.ShowCard();
                        Console.WriteLine($"\nDealer's score: {dealer.GetScore()}");
                        Thread.Sleep(2000);
                        playerFlag = true;
                    }
                    if (dealerFlag && playerFlag)
                    {
                        break;
                    }
                }

                if (dealer.GetScore() <= 21)
                {
                    if (player.GetScore() > 21)
                    {
                        Console.WriteLine("\nDealer wins!");
                        playerBank -= playerBet;
                    }
                    else
                    {
                        if (dealer.GetScore() > player.GetScore())
                        {
                            Console.WriteLine("Dealer wins!");
                            playerBank -= playerBet;
                        }
                        else if (dealer.GetScore() < player.GetScore())
                        {
                            Console.WriteLine("You win!");
                            playerBank += (playerBet*2);
                        }
                        else
                        {
                            Console.WriteLine("Drow");
                        }
                    }
                }
                else
                {
                    if (player.GetScore() > 21)
                    {
                        Console.WriteLine("Drow");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                        playerBank += (playerBet * 2);
                    }
                }

                Thread.Sleep(1000);
                Console.WriteLine($"\nYour money: ${playerBank}");
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nDo you want to play again?\n1 - Yes\n2 - No");
                    option = Console.ReadLine();
                    if (option == "1")
                    {
                        dealer.Cards.Clear();
                        player.Cards.Clear();
                        break;
                    }
                    else if (option == "2")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your choice is wrong!");
                    }
                }
            }
            Thread.Sleep(2000);
            Console.Clear();
            if (playerBank < minBet) Console.WriteLine("You don't have enough money");
            Console.WriteLine("Thanks for the game!");
        }
    }
}