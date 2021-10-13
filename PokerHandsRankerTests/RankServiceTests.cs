using NFluent;
using NUnit.Framework;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;
using PokerHandsRanker;

namespace PokerHandsRankerTests
{
    public class RankServiceTests
    {
        private IRankService _rankService;

        private readonly List<Rank> _allHandsListed = new List<Rank>
        {
            new Rank(10, ""), // "Royal Flush"
            new Rank(9, ""),  // "Straight Flush"
            new Rank(8, ""),  // "Four of a Kind"
            new Rank(7, ""),  // "Full House"
            new Rank(6, ""),  // "Flush"
            new Rank(5, ""),  // "Straight"
            new Rank(4, ""),  // "Three of a Kind"
            new Rank(3, ""),  // "Two Pairs"
            new Rank(2, ""),  // "Pair"
            new Rank(1, ""),  // "High Card"
        };
        
        [SetUp]
        public void SetUp()
        {
            _rankService = new RankService();
        }

        [Test]
        public void Should_Return_Correct_Royal_Flush()
        {
            var hand = new List<string> { "AC", "KC", "QC", "JC", "TC" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[0].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Straight_Flush()
        {
            var hand = new List<string> { "TC", "9C", "8C", "7C", "6C" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[1].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Four_Of_A_Kind()
        {
            var hand = new List<string> { "QC", "QH", "QS", "QD", "5D" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[2].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Full_House()
        {
            var hand = new List<string> { "AD", "AS", "AH", "7C", "7D" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[3].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Flush()
        {
            var hand = new List<string> { "AD", "JD", "8D", "5D", "7D" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[4].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Straight()
        {
            var hand = new List<string> { "TH", "9S", "8D", "7C", "6S" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[5].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Three_Of_A_Kind()
        {
            var hand = new List<string> { "QH", "QS", "QD", "7C", "6S" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[6].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Two_Pairs()
        {
            var hand = new List<string> { "JH", "JC", "9D", "9C", "2S" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[7].RankValue);
        }

        [Test]
        public void Should_Return_Correct_Pair()
        {
            var hand = new List<string> { "QH", "QC", "4D", "8C", "2S" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[8].RankValue);
        }

        [Test]
        public void Should_Return_Correct_High_Card()
        {
            var hand = new List<string> { "AH", "QC", "4D", "8C", "2S" };
            var rank = _rankService.GetRankFromHand(hand);
            Check.That(rank.RankValue).IsEqualTo(_allHandsListed[9].RankValue);
        }
    }
}
