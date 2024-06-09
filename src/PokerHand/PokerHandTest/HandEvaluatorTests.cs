using PokerHand;
using PokerHand.Enum;

namespace PokerHandTest
{

	public class HandEvaluatorTests
	{
		private readonly HandEvaluator _handEvaluator;

		public HandEvaluatorTests()
		{
			_handEvaluator = new HandEvaluator(new HandRanker());
		}

		[Theory]
		[InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "WHITE WINS")]
		[InlineData("2C 2S AS JC 4C", "AH AD 2H 3S 6S", "WHITE WINS")]
		[InlineData("2H 4S 4C 3D 4H", "2S 8S AS QS 3S", "WHITE WINS")]
		[InlineData("3C 7C 6C JC 4C", "2S 8S 4S QS 3S", "WHITE WINS")]
		[InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C KH", "BLACK WINS")]
		[InlineData("2H 3D 5S 9C KD", "2D 3H 5C 9S KH", "TIE")]
		[InlineData("2H 3D 5S 10C KD", "2C 3H 4S 8C AH", "WHITE WINS")]
		[InlineData("2H 3D 5S 10C KD", "2D 3H 5C 9S KH", "BLACK WINS")]
		public void CompareHands_WhenGivenSpecificHands_ReturnsExpectedResult(string blackHandInput, string whiteHandInput, string expectedResult)
		{
			var blackHand = new Hand(ParseHandInput(blackHandInput));
			var whiteHand = new Hand(ParseHandInput(whiteHandInput));

			var result = _handEvaluator.CompareHands(blackHand, whiteHand);

			Assert.Equal(expectedResult, result);
		}

		private static List<Card> ParseHandInput(string input)
		{
			Value value;
			Suit suit;

			var cards = new List<Card>();
			var cardStrings = input.Split(' ');
			foreach (var cardString in cardStrings)
			{
				if (cardString.Length == 3 && cardString.StartsWith("10")) // Handle "10" case
				{
					value = Value.Ten;
					suit = GetSuitFromChar(cardString[2]);
				}
				else
				{
					value = GetValueFromChar(cardString[0]);
					suit = GetSuitFromChar(cardString[1]);
				}

				cards.Add(new Card(value, suit));
			}
			return cards;
		}

		private static Value GetValueFromChar(char valueChar)
		{
			return valueChar switch
			{
				'2' => Value.Two,
				'3' => Value.Three,
				'4' => Value.Four,
				'5' => Value.Five,
				'6' => Value.Six,
				'7' => Value.Seven,
				'8' => Value.Eight,
				'9' => Value.Nine,
				'J' => Value.Jack,
				'Q' => Value.Queen,
				'K' => Value.King,
				'A' => Value.Ace,
				_ => throw new ArgumentException("Invalid card value character.")
			};
		}

		private static Suit GetSuitFromChar(char suitChar)
		{
			return suitChar switch
			{
				'C' => Suit.Clubs,
				'D' => Suit.Diamonds,
				'H' => Suit.Hearts,
				'S' => Suit.Spades,
				_ => throw new ArgumentException("Invalid card suit character.")
			};
		}
	}

}
