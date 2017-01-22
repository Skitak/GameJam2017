using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DMatch : MonoBehaviour {

    private GameObject ButtonsMenu;
    private GameObject EscapeObj;
    private GameObject ButtonsSelection;
    private GameObject ChxDM;
    private GameObject ChxF;

    void Start () {
        ButtonsMenu = GetComponentInParent<ShipManager>().ButtonsMenu;
        ButtonsSelection = GetComponentInParent<ShipManager>().ButtonsSelection;
        EscapeObj = GetComponentInParent<ShipManager>().EscapeObj;
        ChxDM = GetComponentInParent<ShipManager>().ChxDM;
        ChxF = GetComponentInParent<ShipManager>().ChxF;
    }
	

	void Update () {
        if (Input.GetButton("Cancel"))
        {
            ButtonsMenu.SetActive(true);
            ButtonsSelection.SetActive(false);
            ChxDM.SetActive(false);
            ChxF.SetActive(false);
            EscapeObj.SetActive(false);
        }
    }

	public void RunDeathMatch()
	{
        ButtonsMenu.SetActive(false);
        EscapeObj.SetActive(true);
        ButtonsSelection.SetActive(false);
        ChxF.SetActive(false);
        ChxDM.SetActive(true);
    }

	
}
