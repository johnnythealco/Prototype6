using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Faction))]
public class FactionEditor : Editor {

	Faction faction;


	private void OnEnable ()
	{
		faction = (Faction)target;

	}


	public override void OnInspectorGUI ()
	{

		DrawDefaultInspector ();

		EditorGUILayout.LabelField ("");
		EditorGUILayout.LabelField ("Registered Units");
		EditorGUILayout.LabelField ("----------------------");
		EditorGUILayout.LabelField ("");

		foreach(var unit in faction.FactionUnits)
		{
			EditorGUILayout.LabelField (unit.DisplayName);
			EditorGUILayout.LabelField (unit.Designation);
			EditorGUILayout.LabelField ("");
		}


	}



}
