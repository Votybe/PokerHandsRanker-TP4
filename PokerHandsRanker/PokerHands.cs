using System;
using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class PokerHands : IPokerHands
    {
        private readonly IDeckService _deckService;
        private readonly IHandPrinterService _handPrinterService;
        private readonly IHandRankerService _handRankerService;

        public PokerHands(IHandPrinterService handPrinterService,
            IDeckService deckService,
            IHandRankerService handRankerService)
        {
            _handPrinterService = handPrinterService;
            _deckService = deckService;
            _handRankerService = handRankerService;
        }

        public void Rank()
        {
            int amountOfPlayer = AskForANumber(8, " -- Choose the number of players -- ");
            int amountOfDeck = AskForANumber(4, " -- Choose the number of deck of cards -- ");
            var handPlayers = new List<List<string>>();


            var gameOver = false;
            while (!gameOver)
            {
                handPlayers.Clear();
                for (int i = 0; i < amountOfPlayer; i++)
                    handPlayers.Add(new List<string>());

                var deck = _deckService.InitDeck(amountOfDeck);
                Console.WriteLine(amountOfDeck + " decks of cards (" + deck.Count + " cards)");
                for (int i = 0; i < 5; i++)
                    foreach (var handP in handPlayers)
                        _deckService.DrawCard(handP, deck);


                for (int i = 0; i < handPlayers.Count; i++)
                {
                    var handP = handPlayers[i];
                    var rankHandP = _handRankerService.RankHand(handP);
                    _handPrinterService.PrintHand(i + 1, handP, rankHandP);
                }

                var listOfPlayerTie = new List<int>();
                int winner = victoryDetection(listOfPlayerTie, handPlayers);

                if (winner == -1)
                {
                    Console.Write("It's a tie ! Between ");
                    for (var i = 0; i < listOfPlayerTie.Count - 1; i++)
                        Console.Write($"P{listOfPlayerTie[i] + 1},");
                    Console.WriteLine($"P{listOfPlayerTie[listOfPlayerTie.Count - 1] + 1}");
                }
                else
                    Console.WriteLine($"Player {winner + 1} won this round !");

                Console.WriteLine("Play another hand ? Or press 'q' to quit...");

                if (Console.ReadKey().KeyChar.Equals('q'))
                    gameOver = true;

                Console.Clear();
            }
        }

        /**
         * <summary>Detect the winner or the tied players.</summary>
         * <param name="listOfPlayerTie">A list that will contain the tied players, in case of a tie</param>
         * <param name="handPlayers">A list that contain all players' hands</param>
         * <returns>Returns -1 if it's a tie, returns the winner otherwise</returns>
         */
        public int victoryDetection(List<int> listOfPlayerTie, List<List<string>> handPlayers)
        {
            var winner = 0;
            for (int i = 1; i < handPlayers.Count; i++)
            {
                var compare = _handRankerService.RankHands(handPlayers[winner], handPlayers[i]);
                if (compare == 0)
                {
                    if (!listOfPlayerTie.Contains(winner))
                        listOfPlayerTie.Add(winner);
                    listOfPlayerTie.Add(i);
                }
                else
                {
                    if (listOfPlayerTie.Count != 0)
                        listOfPlayerTie.Clear();
                    winner = compare == 1 ? winner : i;
                }
            }

            return listOfPlayerTie.Count != 0 ? -1 : winner;
        }

        public int AskForANumber(int max, string message)
        {
            Console.WriteLine(message);
            int result;
            do
            {
                Console.WriteLine($"Please write a number between 1 and {max}, and press enter :");
                int.TryParse(Console.ReadLine(), out result);
            } while (result < 1 || max < result);

            return result;
        }
    }
}