using PokerHand.Enum;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
	public class Hand
	{
		public List<Card> Cards { get; }

		public Hand(List<Card> cards)
		{
			Cards = cards;
		}

		public IOrderedEnumerable<IGrouping<Value, Card>> GroupByValues()
		{
			return Cards.GroupBy(c => c.Value).OrderByDescending(g => g.Key);
		}

		public bool IsFlush()
		{
			return Cards.All(c => c.Suit == Cards.First().Suit);
		}
	}
}
