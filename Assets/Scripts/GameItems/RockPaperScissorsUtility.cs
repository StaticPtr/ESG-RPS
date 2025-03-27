using System;
using UnityEngine;
using System.Collections;

public static class RockPaperScissorsUtility
{
	public static GameResult CompareHands(HandChoice playerHand, HandChoice opponent)
	{
		if (IsHandStronger(playerHand, opponent))
		{
			return GameResult.Won;
		}

		if (IsHandStronger(opponent, playerHand))
		{
			return GameResult.Lost;
		}

		return GameResult.Draw;
	}

	/// <summary>
	/// Returns true if the provided hand is a usable rock, paper, or scissors hand.
	/// </summary>
	public static bool IsUsableHand(HandChoice hand)
	{
		return hand is HandChoice.Rock or HandChoice.Paper or HandChoice.Scissors;
	}
	
	/// <summary>
	/// Returns true if the first hand is stronger than the second hand
	/// </summary>
	/// <exception cref="ArgumentException">One of the hands is not rock, paper, or scissors.</exception>
	public static bool IsHandStronger (HandChoice firstHand, HandChoice secondHand)
	{
		if (!IsUsableHand(firstHand))
			throw new ArgumentException("Hand is not usable in a game", nameof(firstHand));
		
		if (!IsUsableHand(secondHand))
			throw new ArgumentException("Hand is not usable in a game", nameof(secondHand));
		
		switch (firstHand)
		{
			case HandChoice.Paper:
				return secondHand is HandChoice.Rock;
			case HandChoice.Rock:
				return secondHand is HandChoice.Scissors;
			case HandChoice.Scissors:
				return secondHand is HandChoice.Paper;
		}

		//Will never reach
		throw new Exception();
	}
}