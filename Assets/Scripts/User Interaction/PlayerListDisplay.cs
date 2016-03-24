using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerListDisplay : MonoBehaviour {

	// Target should be a Vertical Layout Group
	public Transform targetTransform;
	public PlayerSetupDisplay playerDisplayPrefab;

	public delegate void PlayerListDisplayDelegate (Player _Player);
	public event PlayerListDisplayDelegate onListItemClick;

	private List<PlayerSetupDisplay> playerdisplays;

	void Awake()
	{
		playerdisplays = new List<PlayerSetupDisplay> ();
	}

	void OnDestroy()
	{
		foreach(var _playerDisplay in playerdisplays)
		{
			_playerDisplay.onClick -= Display_onClick;
		}
	}


	public void Prime (List<Player> players)
	{
		clearDisplays ();
		foreach (var player in players)
		{
			PlayerSetupDisplay display = (PlayerSetupDisplay)Instantiate (playerDisplayPrefab);
			display.transform.SetParent (targetTransform, false);
			display.Prime (player);
			display.onClick += Display_onClick;

			playerdisplays.Add (display);
		}
	}

	void Display_onClick (Player _Player)
	{
		if (onListItemClick != null)
			onListItemClick.Invoke (_Player);
		
	}

	void clearDisplays()
	{
		foreach(var item in playerdisplays)
		{
			item.onClick -= Display_onClick;
		}

		for (int i = 0; i < targetTransform.childCount; i++)
		{
			Destroy (targetTransform.GetChild (i).gameObject);
		}
	}

}
