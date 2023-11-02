using System;

namespace Blackjack
{
    internal class Program
    {
        static void Main()
        {
            int playerScore = 0;
            int croupierScore = 0;
            int playerCard;
            int croupierCard;
            Random random = new Random();

            // First turn
            Console.WriteLine("Le Croupier pioche une carte");
            croupierCard = random.Next(1, 11);
            if (croupierCard == 1 && croupierScore <= 11)
            {
                croupierScore += 11;
            }
            else
            {
                croupierScore += 1;
            }

            Console.WriteLine("A votre tour de piocher une carte");
            playerCard = random.Next(1, 11);
            Console.WriteLine("Votre carte est " + playerCard);
            if (playerCard == 1)
            {
                string answer = "";
                while (answer != "1" && answer != "11")
                {
                    Console.WriteLine("Vous avez pioché un as, souhaitez-vous 1 ou 11 points ? ");
                    answer = Console.ReadLine() ?? "";
                }
                playerScore += Int32.Parse(answer);
                Console.WriteLine("Vous avez donc un total de " + playerScore + " points");
            }
            else
            {
                playerScore += playerCard;
            }

            // Second turn
            Console.WriteLine("Le croupier repioche ");
            croupierCard = random.Next(1, 11);
            if (croupierCard == 1 && croupierScore <= 11)
            {
                croupierScore += 11;
            }
            else
            {
                croupierScore += 1;
            }
            if (croupierScore > 22)
            {
                Console.WriteLine("Le Croupier a sauté vous avez gagné! Voulez-vous rejouer? Appuyer sur O pour Oui et N pour Non");
            }
            else
            {
                Environment.Exit(0);
            }
            Console.WriteLine("A votre tour de piocher une carte");
            playerCard = random.Next(1, 11);
            Console.WriteLine("Votre carte est " + playerCard);
            if (playerCard == 1)
            {
                string answer = "";
                while (answer != "1" && answer != "11")
                {
                    Console.WriteLine("Vous avez pioché un as, souhaitez-vous 1 ou 11 points ? ");
                    answer = Console.ReadLine() ?? "";
                }
                playerScore += Int32.Parse(answer);
                Console.WriteLine("Vous avez donc un total de " + playerScore + " points");
            }
            else
            {
                playerScore += playerCard;
            }
            if (playerScore >= 22)
            {
                Console.WriteLine("Vous avez sauté, pas de chance. Voulez-Vous recommencer ? Si oui appuyer sur O et sinon appuyer sur N");
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}