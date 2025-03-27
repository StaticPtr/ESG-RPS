using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{
	private readonly CancellationTokenSource _cancellationTokenSource = new();
	
	public Text PlayerHandLabel = null!;
	public Text OpponentHandLabel = null!;
	public Text PlayerNameLabel = null!;
	public Text PlayerMoneyLabel = null!;

	private Player? _player;

	private async void Start()
	{
		PlayerInfoLoader playerInfoLoader = new MockPlayerInfoLoader(MockConstants.PLAYER_INFO_RESOURCE);
		IPlayerInfo playerInfo = await playerInfoLoader.Load(_cancellationTokenSource.Token);
		_player = new(playerInfo);
	}

	private void OnDestroy()
	{
		_cancellationTokenSource.Cancel();
	}

	private void Update()
	{
		if (_player is null)
			return;
		
		UpdateHud();
	}

	private void UpdateHud()
	{
		if (_player is null)
			throw new ArgumentNullException(nameof(_player));
		
		PlayerNameLabel.text = $"Name: {_player.Name}";
		PlayerMoneyLabel.text = $"Money: {_player.Money:C2}";
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
		if (_player is null)
			throw new ArgumentNullException(nameof(_player));
		
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