using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Game : MonoBehaviour
{
	
	public static Game Manager = null;
	public UnitRegister UnitRegister;
	public FactionRegister FactionRegister;
	public List<Player> Players;




	void Awake ()
	{
		if (Manager == null)
			Manager = this;
		else if (Manager != this)
			Destroy (gameObject);    
            

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

		InitGame ();
	}


	void InitGame ()
	{
		return;
	}

	public List<string> getfactionNameList()
	{ 
		var result = new List<string> (); 
		foreach (var faction in FactionRegister.factionList)
		{
			result.Add (faction.FactionName);
		}

		return result;
	}

	public Faction getFaction(int index)
	{
		if (index <= FactionRegister.factionList.Count () && index > -1)
		{
			return FactionRegister.factionList [index];
		}
		else
		{
			Debug.Log("Faction not Found!");
			return FactionRegister.factionList [0];
		}
	}


	public static void SaveUnitState(List<Unit> units)
		{
			BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/units.dat", FileMode.OpenOrCreate);
		Debug.Log ("FilePath " + Application.persistentDataPath + "/units.dat");
	
			bf.Serialize (file, units);
			file.Close();
	
	
		}

	public static List<Unit> LoadUnitState()
	{
		List<Unit> result =  new List<Unit>();

		if(File.Exists(Application.persistentDataPath + "/units.dat"))
		{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/units.dat", FileMode.Open);
		result = (List<Unit>) bf.Deserialize(file);
		file.Close();
		return result;
		}
		Debug.Log("No File Found");
		return result;
		
	}

	public void addPlayer()
	{
		if (Players.Count < 7)
		{
			if (Players.Count < 1)
			{	
				var defaultFaction = FactionRegister.factionList [0];
				var player = new Player (defaultFaction.FactionName);
				player.PlayerName = ("Player " + (Players.Count + 1).ToString ());
				Players.Add (player);
			}
			else
			{
				var defaultFaction = FactionRegister.factionList [0];
				var player = new Player (defaultFaction.FactionName);
				player.playerType = PlayerType.Computer;
				player.PlayerName = ("Player " + (Players.Count + 1).ToString ());
				Players.Add (player);
			}
		}
	}


	public void SavePlayersState()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/Players.dat", FileMode.OpenOrCreate);
		Debug.Log ("FilePath " + Application.persistentDataPath + "/Players.dat");

		bf.Serialize (file, Players);
		file.Close();


	}

	public void LoadBattle()
	{
		SceneManager.LoadScene ("Main");
	}


}
