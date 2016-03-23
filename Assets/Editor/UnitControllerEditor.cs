using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Unit))]
public class UnitControllerEditor : Editor
{
	
	Unit _unit;

	
	
	
	private void OnEnable ()
	{
		_unit = (Unit)target;
	
	
		if (_unit.state != null && !EditorApplication.isPlaying)
		{
			_unit.initalize ();
		}
	
	
	}

	public override void OnInspectorGUI ()
	{
	
		DrawDefaultInspector ();
	
		if (_unit.state != null)
		{
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("-- Unit State Values --");
			EditorGUILayout.LabelField ("");
				
			EditorGUILayout.LabelField ("Display Name:", _unit.state.DisplayName);
			EditorGUILayout.LabelField ("Designation:", _unit.state.Designation);
			EditorGUILayout.LabelField ("Action Points:", _unit.state.ActionPoints.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Health:", _unit.state.Health.ToString ());
			EditorGUILayout.LabelField ("Movement:", _unit.state.MovementRange.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Initiative:", _unit.state.Initiative.ToString ());
			EditorGUILayout.LabelField ("");
			EditorGUILayout.LabelField ("Evasion:", _unit.state.Evasion.ToString ());
			if (_unit.baseEnginesHealth > 0) 
				EditorGUILayout.LabelField ("Engines Health: ", _unit.state.EnginesHealth.ToString ());
			EditorGUILayout.LabelField ("");
			if (_unit.baseWeaponsHealth > 0)
				EditorGUILayout.LabelField ("Weapons Health:", _unit.state.WeaponsHealth.ToString ());
	
		}

		if(GUILayout.Button("Initalize Ship Class"))
		{
			_unit.initalize ();
		}

		if(GUILayout.Button("Add Unit to Register"))
		{
			_unit.addUnitToRegister (); 
		}


//
//		if(GUILayout.Button("Damage Health by 10"))
//		{
//			_Controller.state.TakeHealthDamage (10f);
//		}
	}



}
