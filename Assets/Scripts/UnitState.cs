using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class UnitState : System.Object
{
	
	#region Variables
	private String displayName;
	private UnitClass shipClass;

	public int actionPoints;
	private float initiative;
	private float health;
	private float evasion;
	private float enginesHealth;
	private float weaponsHealth;
	private float movementRange;

	#endregion

	#region Properties


	public bool initalized{ get; set; }


	public String	DisplayName{ get { return displayName; } }

	public UnitClass ShipClass{ get{ return shipClass;}}

	public int 		ActionPoints{ get { return actionPoints; } }

	public float		Initiative{ get { return initiative; } }

	public float		Health{ get { return health; } }

	public float		Evasion{ get { return evasion; } }

	public float		EnginesHealth{ get { return enginesHealth; } }

	public float		WeaponsHealth{ get { return weaponsHealth; } }

	public float		MovementRange{ get { return movementRange; } }


	#endregion

	#region Constructors



	public UnitState (Unit _template)
	{

		this.shipClass = _template.shipClass;
		this.displayName = _template.displayName;
		this.actionPoints = _template.baseActionPoints;
		this.initiative = _template.baseInitiative;
		this.health = _template.baseHealth;
		this.evasion = _template.baseEvasion;
		this.enginesHealth = _template.baseMovementRange;
		this.weaponsHealth = _template.baseEnginesHealth;
		this.movementRange = _template.baseWeaponsHealth; 
	}


	#endregion

	public bool TakeHealthDamage (float _dmg)
	{
		health = health - _dmg;

		if (health <= 0)
			return true;
		else
			return false;


	}


}
