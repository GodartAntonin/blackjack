using System;

namespace Blackjack
{
    internal class Program
    {
        static bool playerStoppedDrawing = false;
        static bool croupierStoppedDrawing = false;
        static int playerScore = 0;
        static int croupierScore = 0;
        static List<int> playerCards = new List<int>();
        static List<int> croupierCards = new List<int>();

        static void ResetGame()
        {
            playerStoppedDrawing = false;
            croupierStoppedDrawing = false;
            playerScore = 0;
            croupierScore = 0;
            playerCards = new List<int>();
            croupierCards = new List<int>();
        }

        static void Main()
        {
            Random random = new Random();

            while ((!playerStoppedDrawing || !croupierStoppedDrawing) && playerCards.Count < 5)
            {
                if (!croupierStoppedDrawing)
                {
                    Console.WriteLine("Le Croupier pioche une carte.");
                    int croupierCard = random.Next(1, 11);
                    croupierCards.Add(croupierCard);
                    if (croupierCard == 1)
                    {
                        if (croupierScore <= 11)
                        {
                            croupierScore += 11;
                        }
                        else
                        {
                            croupierScore += 1;
                        }
                    }
                    else
                    {
                        croupierScore += croupierCard;
                    }

                    if (croupierScore > 16)
                    {
                        croupierStoppedDrawing = true;
                        if (croupierScore > 21)
                        {
                            croupierStoppedDrawing = true;
                            playerStoppedDrawing = true;
                            string replayAnswer = "";
                            while (replayAnswer != "O" && replayAnswer != "N")
                            {
                                Console.WriteLine("Le croupier a sauté avec " + croupierScore + " Points. Vous avez gagné. Voulez-vous rejouer ? Appuyez sur O pour Oui et N pour Non");
                                replayAnswer = Console.ReadLine() ?? "";
                            }
                            if (replayAnswer == "O")
                            {
                                ResetGame();
                                break;
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                }

                if (!playerStoppedDrawing)
                {
                    Console.WriteLine("A votre tour de piocher une carte.");
                    int playerCard = random.Next(1, 11);
                    playerCards.Add(playerCard);
                    Console.WriteLine("Votre carte est " + playerCard);
                    if (playerCard == 1)
                    {
                        string aceAnswer = "";
                        while (aceAnswer != "1" && aceAnswer != "11")
                        {
                            Console.WriteLine("Vous avez pioché un as, souhaitez-vous 1 ou 11 Points ? ");
                            aceAnswer = Console.ReadLine() ?? "";
                        }
                        playerScore += Int32.Parse(aceAnswer);
                        Console.WriteLine("Vous avez donc un total de " + playerScore + " Points");
                    }
                    else
                    {
                        playerScore += playerCard;
                        Console.WriteLine("Vous avez donc un total de " + playerScore + " Points");
                    }
                    if (playerScore > 21)
                    {
                        croupierStoppedDrawing = true;
                        playerStoppedDrawing = true;
                        string replayAnswer = "";
                        while (replayAnswer != "O" && replayAnswer != "N")
                        {
                            Console.WriteLine("Vous avez sauté, le croupier a gagné, il avait " + croupierScore + " Points. Voulez-vous rejouer ? Appuyer sur O pour Oui et N pour Non");
                            replayAnswer = Console.ReadLine() ?? "";
                        }
                        if (replayAnswer == "O")
                        {
                            ResetGame();
                            break;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }

                    }
                    string drawAnswer = "";
                    while (drawAnswer != "O" && drawAnswer != "N")
                    {
                        Console.WriteLine("Voulez-vous piocher au prochain tour ? O pour Oui et N pour Non");
                        drawAnswer = Console.ReadLine() ?? "";
                    }
                    if (drawAnswer == "N")
                    {
                        playerStoppedDrawing = true;
                    }
                }
            }
        }
    }
}