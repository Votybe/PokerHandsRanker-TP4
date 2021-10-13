using System.Collections.Generic;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRankerTests
{
    public class RankTests
    {
        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Higher()
        {
            IRank rankHandP1 = new Rank(10, "AC");
            IRank rankHandP2 = new Rank(6, "AC");
            Check.That(rankHandP1).IsNotNull();
            Check.That(rankHandP2).IsNotNull();
            Check.That(rankHandP1.RankValue).IsStrictlyGreaterThan(rankHandP2.RankValue);
            Check.That(rankHandP1.IsBetterRank(rankHandP2)).IsEqualTo(true);
        }

        [Test]
        public void Should_Have_Rank2_Better_Than_Rank1_When_Lower()
        {
            IRank rankHandP1 = new Rank(6, "AC");
            IRank rankHandP2 = new Rank(10, "AC");
            ;
            Check.That(rankHandP1).IsNotNull();
            Check.That(rankHandP2).IsNotNull();
            Check.That(rankHandP1.RankValue).IsStrictlyLessThan(rankHandP2.RankValue);
            Check.That(rankHandP1.IsBetterRank(rankHandP2)).IsEqualTo(false);
        }

        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Same_Rank_But_Higher_Card()
        {
            IRank rankHandP1 = new Rank(1, "AC");
            IRank rankHandP2 = new Rank(1, "TD");
            Check.That(rankHandP1).IsNotNull();
            Check.That(rankHandP2).IsNotNull();
            Check.That(rankHandP1.RankValue).IsEqualTo(rankHandP2.RankValue);
            Check.That(rankHandP1.IsBetterRank(rankHandP2)).IsEqualTo(true);
        }

        [Test]
        public void Should_Have_A_Tie_When_Ranks_Are_The_Same()
        {
            IRank rankHandP1 = new Rank(1, "AC");
            IRank rankHandP2 = new Rank(1, "AC");
            Check.That(rankHandP1).IsNotNull();
            Check.That(rankHandP2).IsNotNull();
            Check.That(rankHandP2.RankValue).IsEqualTo(rankHandP1.RankValue);
            Check.That(rankHandP1.IsBetterRank(rankHandP2)).IsNull();
        }
    }
}