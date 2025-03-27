using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Mock/Player Info")]
public class MockPlayerInfo : ScriptableObject, IPlayerInfo
{
	[SerializeField] private string _userID = string.Empty;
	[SerializeField] private string _name = string.Empty;
	[SerializeField] private float _money;

	public string UserID => _userID;
	public string Name => _name;
	public decimal Money => (decimal)_money;
}