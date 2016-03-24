using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(UnitController))]
public class UnitControllerEditor : Editor
{
	
	UnitController unitTemplate;	
	
	private void OnEnable ()
	{
		unitTemplate = (UnitController)target;
	
	
		if (unitTemplate.unit != null && !EditorApplication.isPlaying)
		{
			unitTemplate.initalize ();
		}
	
	
	}

	public override void OnInspectorGUI ()
	{
	
		DrawDefaultInspector ();
	
		if (unitTemplate.unit != null)
		{
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("-- Unit State Values --");
			EditorGUILayout.LabelField ("");
				
			EditorGUILayout.LabelField ("Display Name:", unitTemplate.unit.DisplayName);
			EditorGUILayout.LabelField ("Designation:", unitTemplate.unit.Designation);
			EditorGUILayout.LabelField ("Faction:", unitTemplate.unit.Faction.FactionName);
			EditorGUILayout.LabelField ("Action Points:", unitTemplate.unit.ActionPoints.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Health:", unitTemplate.unit.Health.ToString ());
			EditorGUILayout.LabelField ("Movement:", unitTemplate.unit.MovementRange.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Initiative:", unitTemplate.unit.Initiative.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Evasion:", unitTemplate.unit.Evasion.ToString ());
			if (unitTemplate.baseEnginesHealth > 0) 
				EditorGUILayout.LabelField ("Engines Health: ", unitTemplate.unit.EnginesHealth.ToString ());
			EditorGUILayout.LabelField ("");
			if (unitTemplate.baseWeaponsHealth > 0)
				EditorGUILayout.LabelField ("Weapons Health:", unitTemplate.unit.WeaponsHealth.ToString ());
	
		}

		if(GUILayout.Button("Initalize Ship Class"))
		{
			unitTemplate.initalize ();
		}




//
//		if(GUILayout.Button("Damage Health by 10"))
//		{
//			_Controller.state.TakeHealthDamage (10f);
//		}
	}



}
