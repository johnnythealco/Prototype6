using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UnitRegister : ScriptableObject 
{
	public List<Unit> AllUnits;
	private Dictionary<string, Unit> lookup; 

	public List<string> RegisteredUnits{ get{ return lookup.Keys.ToList();}}

	void OnEnable()
	{
		Debug.Log ("Unit Register was Enabled");
		UpdateLookup ();


	}

	public void UpdateLookup()
	{
		if(lookup == null)
		{
			lookup = new Dictionary<string, Unit> ();
		}

		lookup.Clear ();
		foreach (var unit in AllUnits)
		{
			lookup.Add (unit.Designation, unit);
		}
		Debug.Log ("Unit Register was Updated");
	}

	public Unit Lookup(string key)
	{
		return lookup [key];
	}
}
