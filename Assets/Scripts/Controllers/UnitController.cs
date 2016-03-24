using UnityEngine;
using System.Collections;
using System;

public class UnitController : MonoBehaviour 
{
	public String	displayName;
	public UnitClass shipClass;
	public Faction faction;
	public string Designation; 
	[SerializeField]
	public Unit unit; 

	#region Base Attributes
	public int baseActionPoints;
	public float baseInitiative;
	public float baseHealth;
	public float baseEvasion;
	public float baseMovementRange;
	public float baseEnginesHealth;
	public float baseWeaponsHealth;
	#endregion


	public void initalize()
	{
		unit = new Unit (this);
	}



}

public enum UnitClass { Fighter, Bomber, Destroyer, Frigate, Cruiser, Carrier}
