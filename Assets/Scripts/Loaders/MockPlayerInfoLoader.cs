using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MockPlayerInfoLoader : PlayerInfoLoader
{
	public readonly string ResourcePath;

	public MockPlayerInfoLoader(string resourcePath)
	{
		ResourcePath = resourcePath;
	}

	public override async Task<IPlayerInfo> Load(CancellationToken cancellationToken)
	{
		//Simulate a delay
		await Task.Delay(1000, cancellationToken);

		cancellationToken.ThrowIfCancellationRequested();
		
		return Resources.Load<MockPlayerInfo>(ResourcePath);
	}
}