using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {
	public GameObject ButtonsMenu;
	public GameObject EscapeObj;
	public GameObject ButtonsSelection;

	void Start () {
		ButtonsMenu = GetComponentInParent<ShipManager> ().ButtonsMenu;
		ButtonsSelection = GetComponentInParent<ShipManager> ().ButtonsSelection;
		EscapeObj = GetComponentInParent<ShipManager> ().EscapeObj;
	}
	
	void Update () {
		if (Input.GetButton("Cancel"))
		{
			ButtonsMenu.SetActive (true);
			EscapeObj.SetActive (false);
			ButtonsSelection.SetActive (false);
		}
	}

    public void RunGame()
    {
		ButtonsMenu.SetActive (false);
		EscapeObj.SetActive(true);
		ButtonsSelection.SetActive (true);
    }
		
}
