using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UnitRegister : ScriptableObject 
{
	public List<UnitController> AllUnits;
	private Dictionary<string, UnitController> lookup; 

	public List<string> RegisteredUnits{ get{ return lookup.Keys.ToList();}}

	void OnEnable()
	{

		UpdateLookup ();
		initalizeAllTemplates ();
	}

	public void UpdateLookup()
	{
		if(lookup == null)
		{
			lookup = new Dictionary<string, UnitController> ();
		}

		lookup.Clear ();
		foreach (var unit in AllUnits)
		{
			lookup.Add (unit.Designation, unit);
		}
//		Debug.Log ("Unit Register was Updated");
	}

	public UnitController Lookup(string key)
	{
		return lookup [key];
	}


	public List<Unit> factionLookUp(Faction faction)
	{
		var result = new List<Unit> (); 
		foreach (var unit in AllUnits)
		{
			if (unit.faction == faction)
			{
				result.Add (unit.unit);
			}
		}
		return result;
	}

	void initalizeAllTemplates()
	{
		foreach(var unit in AllUnits)
		{
			unit.initalize ();
		}
	}
}
