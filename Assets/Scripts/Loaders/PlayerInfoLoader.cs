using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Threading.Tasks;

public abstract class PlayerInfoLoader
{
	public abstract Task<IPlayerInfo> Load(CancellationToken cancellationToken);
}