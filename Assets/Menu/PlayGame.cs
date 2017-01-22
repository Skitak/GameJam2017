using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayGame : MonoBehaviour {
	private GameObject ButtonsMenu;
    private GameObject EscapeObj;
    private GameObject ButtonsSelection;
    private GameObject ChxDM;
    private GameObject ChxF;

    void Start () {
		ButtonsMenu = GetComponentInParent<ShipManager> ().ButtonsMenu;
		ButtonsSelection = GetComponentInParent<ShipManager> ().ButtonsSelection;
		EscapeObj = GetComponentInParent<ShipManager> ().EscapeObj;
        ChxDM = GetComponentInParent<ShipManager>().ChxDM;
        ChxF = GetComponentInParent<ShipManager>().ChxF;
    }
	
	void Update () {
	}

    public void RunGame()
    {
        ButtonsMenu.SetActive(false);
        EscapeObj.SetActive(true);
        ButtonsSelection.SetActive(true);
        ChxF.SetActive(false);
        ChxDM.SetActive(false);
    }
		
}
