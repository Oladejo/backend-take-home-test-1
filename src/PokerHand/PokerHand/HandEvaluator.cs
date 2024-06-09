using System.Linq;

namespace PokerHand
{
	public class HandEvaluator
	{

		private readonly HandRanker _handRanker;

		public HandEvaluator(HandRanker handRanker)
		{
			_handRanker = handRanker;
		}

		public string CompareHands(Hand blackHand, Hand whiteHand)
		{
			var blackRank = _handRanker.DetermineRank(blackHand);
			var whiteRank = _handRanker.DetermineRank(whiteHand);

			if (blackRank > whiteRank)
			{
				return "BLACK WINS";
			}
			if (whiteRank > blackRank)
			{
				return "WHITE WINS";
			}

			return CompareByHighCard(blackHand, whiteHand);
		}

		private static string CompareByHighCard(Hand blackHand, Hand whiteHand)
		{
			var blackValues = blackHand.Cards.OrderByDescending(c => c.Value).ToList();
			var whiteValues = whiteHand.Cards.OrderByDescending(c => c.Value).ToList();

			for (int i = 0; i < blackValues.Count; i++)
			{
				if (blackValues[i].Value > whiteValues[i].Value)
				{
					return "BLACK WINS";
				}
				if (whiteValues[i].Value > blackValues[i].Value)
				{
					return "WHITE WINS";
				}
			}

			return "TIE";
		}
	}

}
