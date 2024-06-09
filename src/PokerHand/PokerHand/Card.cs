using PokerHand.Enum;

namespace PokerHand
{
	public class Card
	{
		public Value Value { get; private set; }
		public Suit Suit { get; private set; }

		public Card(Value value, Suit suit)
		{
			Value = value;
			Suit = suit;
		}
	}
}
