using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MockGameUpdater : GameUpdater
{
	public decimal Ante { get; init; } = 10m;
	
	public override async Task<RoundResult> SubmitPlayerHand(HandChoice playerHand, CancellationToken cancellationToken)
	{
		//Simulate a delay
		await Task.Delay(1000, cancellationToken);
		
		cancellationToken.ThrowIfCancellationRequested();

		HandChoice opponentHand = GetRandomOpponentChoice();
		GameResult playerResult = RockPaperScissorsUtility.GetResult(playerHand, opponentHand);

		return new RoundResult(
			playerHand,
			opponentHand,
			playerResult,
			GetPlayerMoneyChange(playerResult)	
		);
	}

	private HandChoice GetRandomOpponentChoice()
	{
		int randomResult = Random.Range((int)HandChoice.None + 1, (int)HandChoice.Count);
		return (HandChoice)randomResult;
	}

	private decimal GetPlayerMoneyChange(GameResult gameResult)
	{
		return gameResult switch
		{
			GameResult.Won => Ante,
			GameResult.Lost => -Ante,
			_ => 0.0m,
		};
	}
}