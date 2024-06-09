using PokerHand.Enum;
using System.Linq;

namespace PokerHand
{
	public class HandRanker
	{
		public HandRank DetermineRank(Hand hand)
		{
			if (hand.IsFlush())
			{
				return HandRank.Flush;
			}

			var groupedValues = hand.GroupByValues();

			if (groupedValues.Any(g => g.Count() == 3))
			{
				return HandRank.ThreeOfAKind;
			}

			if (groupedValues.Count(g => g.Count() == 2) == 2)
			{
				return HandRank.TwoPair;
			}

			if (groupedValues.Any(g => g.Count() == 2))
			{
				return HandRank.Pair;
			}

			return HandRank.HighCard;
		}
	}
}
