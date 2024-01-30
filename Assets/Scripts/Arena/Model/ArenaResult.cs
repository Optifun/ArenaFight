namespace Arena.Model
{
    public class ArenaResult
    {
        public bool Victory { get; }
        public int EarnedGold { get; }
        public int EarnedXP { get; }

        public ArenaResult(bool victory, int earnedGold, int earnedXp)
        {
            Victory = victory;
            EarnedGold = earnedGold;
            EarnedXP = earnedXp;
        }
    }
}