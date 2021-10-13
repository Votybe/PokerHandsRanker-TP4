using System;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;

namespace PokerHandsRankerTests
{
    public class HandRankerServiceTests
    {
        private IHandRankerService _handRankerService;
        private IRankService _rankService;

        [SetUp]
        public void SetUp()
        {
            _rankService = new RankService();
            _handRankerService = new HandRankerService(_rankService);
        }

        [Test]
        public void Should_Call_IRankService_When_Ranking_Hands()
        {
            // Royal Flush
            var handP1 = new List<string>(){ "AC", "KC", "QC", "JC", "TC" };
            IRank rank = _handRankerService.RankHand(handP1);
            Check.That(rank).IsNotNull();
        }

        [Test]
        public void Should_Have_Player1_Win_If_His_Hand_Is_Better()
        {
            // Royal Flush
            var handP1 = new List<string>() { "AC", "KC", "QC", "JC", "TC" };
            // Flush
            var handP2 = new List<string>() { "AD", "JD", "8D", "5D", "7D" };
            var winner = _handRankerService.RankHands(handP1, handP2);
            Check.That(winner).IsEqualTo(1);
        }

        [Test]
        public void Should_Have_Player2_Win_If_His_Hand_Is_Better()
        {
            // Straight
            var handP1 = new List<string>() { "TH", "9S", "8D", "7C", "6S" };
            // Royal Flush
            var handP2 = new List<string>() { "AC", "KC", "QC", "JC", "TC" };
            var winner = _handRankerService.RankHands(handP1, handP2);
            Check.That(winner).IsEqualTo(2);
        }


        [Test]
        public void Should_Have_A_Tie_If_Hands_Are_Equal()
        {
            var handP1 = new List<string>() {"AD", "JD", "8D", "5D", "7D"};
            var handP2 = new List<string>() {"AD", "JD", "8D", "5D", "7D"};
            var winner = _handRankerService.RankHands(handP1, handP2);
            Check.That(winner).IsEqualTo(0);
        }
    }
}