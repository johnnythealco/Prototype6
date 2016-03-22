using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour 
{
	public String	displayName;
	public UnitClass shipClass;
	[SerializeField]
	public UnitState state; 

	#region Base Attributes
	public int baseActionPoints;
	public float baseInitiative;
	public float baseHealth;
	public float baseEvasion;
	public float baseMovementRange;
	public float baseEnginesHealth;
	public float baseWeaponsHealth;
	#endregion


	void Start()
	{
		state = new UnitState (this);
	}

}

public enum UnitClass { Fighter, Bomber, Destroyer, Frigate, Cruiser, Carrier}
