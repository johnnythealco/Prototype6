using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player : System.Object {

	public PlayerType playerType;
	public string PlayerName;
	public string faction;
	public List<Unit> fleet;



	public Player(string _faction)
	{
		fleet = new List<Unit> ();
		playerType = PlayerType.Human;
		faction = _faction;

	}

	public Faction getFaction()
	{
		return Game.Manager.FactionRegister.findFactionByName (faction);
	}

}

public enum PlayerType { Human, Computer}
