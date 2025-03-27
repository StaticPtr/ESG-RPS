using UnityEngine;
using System.Collections;

public enum GameResult
{
	Won,
	Lost,
	Draw
}

public static class RockPaperScissorsUtility
{
	public static GameResult GetResult(HandChoice playerHand, HandChoice opponent)
	{
		if (IsHandStronger(playerHand, opponent))
		{
			return GameResult.Won;
		}
		else if (IsHandStronger(opponent, playerHand))
		{
			return GameResult.Lost;
		}
		else
		{
			return GameResult.Draw;
		}
	}

	private static bool IsHandStronger (HandChoice firstHand, HandChoice secondHand)
	{
		switch (firstHand)
		{
			case HandChoice.Rock:
			{
				switch (secondHand)
				{
					case HandChoice.Scissors:
						return true;
					case HandChoice.Paper:
						return false;
				}
				break;
			}
			case HandChoice.Paper:
			{
				switch (secondHand)
				{
					case HandChoice.Rock:
						return true;
					case HandChoice.Scissors:
						return false;
				}
				break;
			}
			case HandChoice.Scissors:
			{
				switch (secondHand)
				{
					case HandChoice.Paper:
						return true;
					case HandChoice.Rock:
						return false;
				}
				break;
			}
		}

		return false;
	}
}