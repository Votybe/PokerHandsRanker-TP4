namespace PokerHandsRanker.Interfaces
{
    public interface IRank
    {
        int RankValue { get; }
        string Card { get; }
        bool? IsBetterRank(IRank other);
    }
}