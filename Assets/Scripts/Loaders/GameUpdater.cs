using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Threading.Tasks;

public abstract class GameUpdater
{
	public abstract Task<RoundResult> SubmitPlayerHand(HandChoice playerHand, CancellationToken cancellationToken);
}