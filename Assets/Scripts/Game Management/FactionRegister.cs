using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class FactionRegister : ScriptableObject {
	public List<Faction> factionList;

	private Dictionary<string, Faction> lookup;

	public Faction findFactionByName(string name)
	{
		UpdateLookup ();
		var result = lookup [name];
		Debug.Log ("Faction Returned :" + result.FactionName);
		return result;

	}

	public void UpdateLookup()
	{
		if(lookup == null)
		{
			lookup = new Dictionary<string, Faction> ();
		}

		lookup.Clear ();
		foreach (var faction in factionList)
		{
			lookup.Add (faction.FactionName, faction);
		}
		Debug.Log ("Faction Register was Updated");
	}
}
