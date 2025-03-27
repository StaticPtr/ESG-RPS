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
	public Selectable[] Interactables = Array.Empty<Selectable>();

	private Player? _player;
	private readonly GameUpdater _gameUpdater = new MockGameUpdater();

	private async void Start()
	{
		SetInteractability(false);
		
		PlayerInfoLoader playerInfoLoader = new MockPlayerInfoLoader(MockConstants.PLAYER_INFO_RESOURCE);
		IPlayerInfo playerInfo = await playerInfoLoader.Load(_cancellationTokenSource.Token);
		_player = new(playerInfo);
		OnPlayerLoaded();
	}

	private void OnDestroy()
	{
		_cancellationTokenSource.Cancel();
	}

	private void OnPlayerLoaded()
	{
		PlayerNameLabel.text = $"Name: {_player!.Name}";
		OnPlayerMoneyUpdated();
		SetInteractability(true);
	}
	
	private void OnPlayerMoneyUpdated()
	{
		PlayerMoneyLabel.text = $"Money: {_player!.Money:C2}";
	}

	public void HandlePlayerInput(int choice)
	{
		if (!Enum.IsDefined(typeof(HandChoice), choice))
			throw new InvalidOperationException("Invalid cast to choice");
		
		HandlePlayerInput((HandChoice)choice);
	}

	private async void HandlePlayerInput(HandChoice playerChoice)
	{
		if (playerChoice is HandChoice.None)
			throw new InvalidOperationException("Invalid choice");

		SetInteractability(false);
		RoundResult result = await _gameUpdater.SubmitPlayerHand(playerChoice, _cancellationTokenSource.Token);
		OnGameRoundCompleted(result);
	}

	private void OnGameRoundCompleted(RoundResult roundResult)
	{
		if (_player is null)
			throw new ArgumentNullException(nameof(_player));
		
		PlayerHandLabel.text = HandChoiceToString(roundResult.PlayerHand);
		OpponentHandLabel.text = HandChoiceToString(roundResult.OpponentHand);

		_player.AddMoney(roundResult.PlayerMoneyChange);
		OnPlayerMoneyUpdated();
		SetInteractability(true);
	}

	private string HandChoiceToString (HandChoice result)
	{
		//In the future this can go through some sort of localizer.
		//But the version provided to me could be simplified as:
		return result.ToString();
	}

	private void SetInteractability(bool isInteractable)
	{
		foreach (Selectable interactable in Interactables)
		{
			interactable.interactable = isInteractable;
		}
	}
}