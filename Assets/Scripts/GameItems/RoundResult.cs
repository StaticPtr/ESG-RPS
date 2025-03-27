public record RoundResult(
	HandChoice PlayerHand,
	HandChoice OpponentHand,
	GameResult PlayerResult,
	decimal PlayerMoneyChange
);