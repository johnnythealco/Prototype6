using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class JKTesting : MonoBehaviour {

	public List<Unit> testUnits;

	public List<UnitState> testUnitStates;

	void Awake ()
	{
		testUnitStates = new List<UnitState> ();
		foreach(var unit in testUnits)
		{
			testUnitStates.Add (unit.state);
		}

		testUnits.Clear ();



	}

	public void DeployFromUnitStateList()
	{
		var points = Sector.getDeploymentArea (Sector.centerSpawn, testUnitStates.Count);

		for( int i = 0; i < testUnitStates.Count; i++)
		{
			testUnitStates [i].deployUnit (points [i]);
		}
	}


	
	
	

	
//	    public static string GetUniqueID(){
//         string key = "ID";
// 
//         var random = new System.Random();                     
//         DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
//         double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
//         
//         string uniqueID = Application.systemLanguage                            //Language
//				+"-"+Application.platform                                            //Device    
//                 +"-"+String.Format("{0:X}", Convert.ToInt32(timestamp))                //Time
//                 +"-"+String.Format("{0:X}", Convert.ToInt32(Time.time*1000000))        //Time in game
//                 +"-"+String.Format("{0:X}", random.Next(1000000000));                //random number
//         
//         Debug.Log("Generated Unique ID: "+uniqueID);
//         
//         if(PlayerPrefs.HasKey(key)){
//             uniqueID = PlayerPrefs.GetString(key);            
//         } else {            
//             PlayerPrefs.SetString(key, uniqueID);
//             PlayerPrefs.Save();    
//         }
//         
//         return uniqueID;
//     }
}
