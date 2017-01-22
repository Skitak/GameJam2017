using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generique : MonoBehaviour {
	public GameObject ButtonsMenu;
	public GameObject EscapeObj;
	public GameObject ButtonsSelection;

	void Start () {
		ButtonsMenu = GetComponentInParent<ShipManager> ().ButtonsMenu;
		ButtonsSelection = GetComponentInParent<ShipManager> ().ButtonsSelection;
		EscapeObj = GetComponentInParent<ShipManager> ().EscapeObj;
	}

	void Update () {

	}

	public void RunGeneric()
	{
		ButtonsMenu.SetActive (false);
		EscapeObj.SetActive(true);
		ButtonsSelection.SetActive (false);
	}
}
