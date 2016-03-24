using UnityEngine;
using System.Collections;
using System;


[System.Serializable]
public class Unit : System.Object
{
	
	#region Variables
	private String displayName;
	private UnitClass shipClass;
	public string Designation; 

	public GridPos coordinates; 

	private string faction;
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

	public Faction Faction{get{return Game.Manager.FactionRegister.findFactionByName(faction);}}

	public int 		ActionPoints{ get { return actionPoints; } }

	public float		Initiative{ get { return initiative; } }

	public float		Health{ get { return health; } }

	public float		Evasion{ get { return evasion; } }

	public float		EnginesHealth{ get { return enginesHealth; } }

	public float		WeaponsHealth{ get { return weaponsHealth; } }

	public float		MovementRange{ get { return movementRange; } }


	#endregion

	#region Constructors



	public Unit (UnitController _template)
	{
		this.Designation = _template.Designation;
		this.shipClass = _template.shipClass;
		this.displayName = _template.displayName;
		this.faction = _template.faction.FactionName;
		this.actionPoints = _template.baseActionPoints;
		this.initiative = _template.baseInitiative;
		this.health = _template.baseHealth;
		this.evasion = _template.baseEvasion;
		this.enginesHealth = _template.baseMovementRange;
		this.weaponsHealth = _template.baseEnginesHealth;
		this.movementRange = _template.baseWeaponsHealth; 
	}

	public Unit ()
	{
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


	public void deployUnit(Vector3 point)
	{

		Sector.CreateUnit (this, Sector.Map [point]);



	}

	public void deployUnit()
	{
		Sector.CreateUnit (this, Sector.getPoint(coordinates));
	}


}

[System.Serializable]
public class GridPos : System.Object
{
	public int x,y;
}
