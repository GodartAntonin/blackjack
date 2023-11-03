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

        static bool DoesUserReplay()
        {
            string answer = "";
            while (answer != "O" && answer != "N")
            {
                Console.WriteLine("Voulez-vous rejouer ? Appuyez sur O pour Oui et N pour Non");
                answer = Console.ReadLine() ?? "";
            }

            return answer == "O";
        }

        static void Main()
        {
            Random random = new Random();

            while (true)
            {
                playerStoppedDrawing = false;
                croupierStoppedDrawing = false;
                playerScore = 0;
                croupierScore = 0;
                playerCards.Clear();
                croupierCards.Clear();
                Console.Clear();

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
                                Console.WriteLine("Le croupier a sauté, il avait " + croupierScore + " Points. Vous avez gagné !");
                                break;
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
                        }
                        else
                        {
                            playerScore += playerCard;
                        }

                        Console.WriteLine("Vous avez donc un total de " + playerScore + " Points");

                        if (playerScore > 21)
                        {
                            Console.WriteLine("Vous avez sauté avec " + playerScore + " Points. Le croupier avait " + croupierScore + " Points.");
                            break;
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

                if (playerScore == croupierScore)
                {
                    Console.WriteLine("Vous avez fait ex aequos avec le croupier pour un total de " + playerScore + " Points. Vous gardez votre mise du départ.");
                }
                else if (playerScore > croupierScore && playerScore <= 21)
                {
                    if(playerCards.Count <= 3 && playerScore == 21)
                    {
                        Console.WriteLine("Vous avez gagné avec " + playerScore + " Points alors que le croupier n'avait que " + croupierScore + " Points. Vous gagnez 20 euros car vous avez fait un Blackjack en "+ playerCards.Count +" cartes, vous êtes sur la route de la richesse.");
                    } else
                    {
                        Console.WriteLine("Vous avez gagné avec " + playerScore + " Points alors que le croupier n'avait que " + croupierScore + " Points. Vous gagnez 10 euros, vous êtes sur la route de la richesse.");
                    }
                }
                else if (croupierScore > playerScore && croupierScore <= 21)
                {
                    Console.WriteLine("Vous avez perdu avec " + playerScore + " Points alors que le croupier avait  " + croupierScore + " Points. Vous perdez alors 10 euros, Faites attention tout de même a ne pas finir pauvre.");
                }

                if(!DoesUserReplay())
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
