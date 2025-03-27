using UnityEngine;
using System.Collections;
using System;

public class Player
{
	private int _userId;
	private string _name;
	private int _money;

	public Player(Hashtable playerData)
	{
		_userId = (int)playerData["userId"];
		_name = playerData["name"].ToString (); 
		_money = (int)playerData["coins"];
	}
	
	public int GetUserID()
	{
		return _userId;
	}
	
	public string GetName()
	{
		return _name;
	}

	public int GetMoney()
	{
		return _money;
	}

	public void AddMoney(int delta)
	{
		_money += delta;
	}
}