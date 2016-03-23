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

//	public GameState state;
//	public Player player;
	public Unit testUnit;

//	public List<Faction> factionList;
//
//
//	private BattleState battleLoadState;
//	public BattleState BattleLoadState{get{return battleLoadState;}}




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

//	public List<string> getfactionNameList()
//	{ 
//		var result = new List<string> (); 
//		foreach (var faction in factionList)
//		{
//			result.Add (faction.FactionName);
//		}
//
//		return result;
//	}
//
//	public Faction getFaction(int index)
//	{
//		if (index <= factionList.Count () && index > -1)
//		{
//			return factionList [index];
//		}
//		else
//		{
//			Debug.Log("Faction not Found!");
//			return factionList [0];
//		}
//			
//
//	}
//
//	public void LoadBattle(Dictionary<FleetState, int> _fleets_SpawnPoints, int _sectorSize, string _sectorName)
//	{
//		battleLoadState = new BattleState( _fleets_SpawnPoints, _sectorSize,_sectorName); 
//		SceneManager.LoadScene ("TestBattle"); 
//
//	}
//
//	public void SaveBattleState()
//	{
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Open (Application.persistentDataPath + "/gamefile.dat", FileMode.OpenOrCreate);
//		Debug.Log ("FilePath " + Application.persistentDataPath + "/gamefile.dat");
//
//		bf.Serialize (file, Battle.Manager.state);
//		file.Close();
//
//
//	}
//
//	public void SaveUnitState()
//	{
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Open (Application.persistentDataPath + "/gamefile.dat", FileMode.OpenOrCreate);
//		Debug.Log ("FilePath " + Application.persistentDataPath + "/gamefile.dat");
//
//		bf.Serialize (file, testUnit.state);
//		file.Close();
//
//
//	}


}
