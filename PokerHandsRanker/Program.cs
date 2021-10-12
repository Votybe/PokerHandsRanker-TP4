using System;
using Ninject;
using PokerHandsRanker.Injection;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public static class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            var kernel = new StandardKernel(new PhrInjectionModule());
            var service = kernel.Get<IPokerHands>();
            service.Rank();
        }
    }
}
