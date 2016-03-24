using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Faction : ScriptableObject 
{
	public string FactionName;
	public UnitRegister unitRegister;
	public List<Unit> FactionUnits{get{return unitRegister.factionLookUp (this);}}



}
