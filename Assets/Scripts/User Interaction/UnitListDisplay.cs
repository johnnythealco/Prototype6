using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* A Class to display a List of UnitStates
 * When primed it will create a unitDisplay for each unit in the list
 * and subscribe to the OnClick event of each unitDisplay created
 * It povides an onListItemClick event that can be subscribed to
 */
public class UnitListDisplay : MonoBehaviour
{
	// Target should be a Vertical Layout Group
	public Transform targetTransform;
	public UnitDisplay unitDisplayPrefab;

	public delegate void UnitListDisplayDelegate (Unit _unit);

	public event UnitListDisplayDelegate onListItemClick;

	//List to record what unitDisplays have been created
	//This is to enabel each to be unscuscribed from when this is destroyed
	private List<UnitDisplay> unitDisplays;

	void Awake ()
	{
		unitDisplays = new List<UnitDisplay> ();
	}


	public void Prime (List<Unit> units)
	{
		clearDisplays ();
		foreach (var unit in units)
		{
			UnitDisplay display = (UnitDisplay)Instantiate (unitDisplayPrefab);
			display.transform.SetParent (targetTransform, false);
			display.Prime (unit);
			display.onClick += Display_onClick;
			unitDisplays.Add (display);
		}
	}

	void OnDestroy ()
	{
		foreach (var _display in unitDisplays)
		{		
			Debug.Log (" Unsigned-up for onClick " + _display.displayName.text);
			_display.onClick -= Display_onClick; 
		}
	}

	void Display_onClick (Unit _unit)
	{

		if (onListItemClick != null)
		{
			onListItemClick.Invoke (_unit);
		} 
	}
	
	void clearDisplays()
	{
				foreach(var item in unitDisplays)
		{
			item.onClick -= Display_onClick;
		}

		for (int i = 0; i < targetTransform.childCount; i++)
		{
			Destroy (targetTransform.GetChild (i).gameObject);
		}
	}
}
