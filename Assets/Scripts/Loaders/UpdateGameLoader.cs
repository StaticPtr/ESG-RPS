using UnityEngine;
using System.Collections;
using System;

public class UpdateGameLoader
{
	public delegate void OnLoadedAction(Hashtable gameUpdateData);
	public event OnLoadedAction? OnLoaded;

	private HandChoice _choice;

	public UpdateGameLoader(HandChoice playerChoice)
	{
		_choice = playerChoice;
	}

	public void Load()
	{
		HandChoice opponentHand = (HandChoice)Enum.GetValues(typeof(HandChoice)).GetValue(UnityEngine.Random.Range(0, 4));

		Hashtable mockGameUpdate = new Hashtable();
		mockGameUpdate["resultPlayer"] = _choice;
		mockGameUpdate["resultOpponent"] = opponentHand;
		mockGameUpdate["coinsAmountChange"] = GetPlayerMoneyChange(_choice, opponentHand);
		
		OnLoaded?.Invoke(mockGameUpdate);
	}

	private int GetPlayerMoneyChange (HandChoice playerHand, HandChoice opponentHand)
	{
		GameResult gameResult = RockPaperScissorsUtility.GetResult(playerHand, opponentHand);

		if (gameResult.Equals (GameResult.Won))
		{
			return 10;
		}
		else if (gameResult.Equals (GameResult.Lost))
		{
			return -10;
		}
		else
		{
			return 0;
		}

		return 0;
	}
}