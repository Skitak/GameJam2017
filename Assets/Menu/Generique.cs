using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generique : MonoBehaviour {
    public static bool IsClick = false;
    public GameObject ButtonsMenu;
    public GameObject EscapeObj;
    public GameObject ButtonsSelection;
    public GameObject ChxDM;
    public GameObject ChxF;
    private GameObject gen;

    void Start () {
		ButtonsMenu = GetComponentInParent<ShipManager> ().ButtonsMenu;
		ButtonsSelection = GetComponentInParent<ShipManager> ().ButtonsSelection;
		EscapeObj = GetComponentInParent<ShipManager> ().EscapeObj;
        ChxDM = GetComponentInParent<ShipManager>().ChxDM;
        ChxF = GetComponentInParent<ShipManager>().ChxF;
        gen = GetComponentInParent<ShipManager>().gen;
        
    }

	void Update () {
        if(ShipManager.IsClick)
            gen.transform.position = new Vector3(gen.transform.position.x, gen.transform.position.y * 0.2f, gen.transform.position.z);
	}

	public void RunGeneric()
	{
        ShipManager.IsClick = true;
        gen.SetActive(true);
        ButtonsMenu.SetActive(false);
        ButtonsSelection.SetActive(false);
        ChxDM.SetActive(false);
        ChxF.SetActive(false);
        EscapeObj.SetActive(true);
    }
}
