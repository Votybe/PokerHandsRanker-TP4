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
            _rankService = Substitute.For<IRankService>();
            _handRankerService = new HandRankerService(_rankService);
        }

        [Test]
        public void Should_Call_IRankService_When_Ranking_Hands()
        {
            // TODO
        }

        [Test]
        public void Should_Have_Player1_Win_If_His_Hand_Is_Better()
        {
            // TODO
        }


        [Test]
        public void Should_Have_Player2_Win_If_His_Hand_Is_Better()
        {
            // TODO
        }


        [Test]
        public void Should_Have_A_Tie_If_Hands_Are_Equal()
        {
            // TODO
        }
    }
}
