using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(UnitRegister))]
public class UnitRegisterEditor : Editor 
{
	UnitRegister unitRegister;


	private void OnEnable ()
	{
		unitRegister = (UnitRegister)target;

	}


	public override void OnInspectorGUI ()
	{

		DrawDefaultInspector ();

		EditorGUILayout.LabelField ("");

		if(GUILayout.Button("Update Unit Lookup"))
		{
			unitRegister.UpdateLookup ();
		}

		EditorGUILayout.LabelField ("");
		EditorGUILayout.LabelField ("-- Unit Lookup Values --");
		EditorGUILayout.LabelField ("");

		foreach(var unit in unitRegister.RegisteredUnits)
		{
			EditorGUILayout.LabelField ("Unit Designation: " + unit);
		}

	}



}
