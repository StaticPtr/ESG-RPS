using UnityEngine;
using System.Collections;
using System;

public class Player : IPlayerInfo
{
	public string UserID { get; private set; }
	public string Name { get; private set; }
	public decimal Money { get; private set; }

	public Player(IPlayerInfo initialInfo)
	{
		UserID = initialInfo.UserID;
		Name = initialInfo.Name;
		Money = initialInfo.Money;
	}

	public void AddMoney(decimal delta)
	{
		Money += delta;
	}
}