using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
	public Text PlayerHandLabel = null!;
	public Text OpponentHandLabel = null!;
	public Text PlayerNameLabel = null!;
	public Text PlayerMoneyLabel = null!;

	private Player _player = null!;

	private void Start()
	{
		PlayerInfoLoader playerInfoLoader = new PlayerInfoLoader();
		playerInfoLoader.OnLoaded += OnPlayerInfoLoaded;
		playerInfoLoader.Load();
	}

	private void Update()
	{
		UpdateHud();
	}

	private void OnPlayerInfoLoaded(Hashtable playerData)
	{
		_player = new Player(playerData);
	}

	public void UpdateHud()
	{
		PlayerNameLabel.text = $"Name: {_player.GetName()}";
		PlayerMoneyLabel.text = $"Money: ${_player.GetMoney()}";
	}

	public void HandlePlayerInput(int choice)
	{
		HandChoice playerChoice = HandChoice.None;

		switch (choice)
		{
			case 1:
				playerChoice = HandChoice.Rock;
				break;
			case 2:
				playerChoice = HandChoice.Paper;
				break;
			case 3:
				playerChoice = HandChoice.Scissors;
				break;
		}

		UpdateGame(playerChoice);
	}

	private void UpdateGame(HandChoice playerChoice)
	{
		UpdateGameLoader updateGameLoader = new UpdateGameLoader(playerChoice);
		updateGameLoader.OnLoaded += OnGameUpdated;
		updateGameLoader.Load();
	}

	public void OnGameUpdated(Hashtable gameUpdateData)
	{
		PlayerHandLabel.text = HandChoiceToString((HandChoice)gameUpdateData["resultPlayer"]);
		OpponentHandLabel.text = HandChoiceToString((HandChoice)gameUpdateData["resultOpponent"]);

		_player.AddMoney((int)gameUpdateData["coinsAmountChange"]);
	}

	private string HandChoiceToString (HandChoice result)
	{
		//In the future this can go through some sort of localizer.
		//But the version provided to me could be simplified as:
		return result.ToString();
	}
}